using Dscf.Common.Manager.Implement;
using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Dao;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Dto.DscfACService;
using Dscf.LoanAfter.Dto.DscfCarLoanService;
using Dscf.LoanAfter.Dto.DscfCreditLoanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager.Implement
{
    //T_RepayRemind
    public class RepayRemindManager : GenericManagerBase<RepayRemind>, IRepayRemindManager
    {
        public RepayRemindDto[] GetRepayRemindListByKey(int repayId, int orderType)
        {
            IList<RepayRemindDto> dtoList = new List<RepayRemindDto>();

            Dto.DscfACService.OperaterInfoDto[] optDtoArray;

            var remindList = this.CurrentRepository.Entities.Where(r => r.RepayId == repayId && r.OrderType == orderType && r.IsDeleted == false).ToList();

            var optIdArray = remindList.Select(remind => remind.CreateOptId.HasValue ? remind.CreateOptId.Value : -1).Distinct().ToArray();

            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                optDtoArray = client.GetOperaterInfoList(optIdArray);
            }

            foreach (var remind in remindList)
            {
                RepayRemindDto remindDto = remind.ToModel();
                if (remind.CreateOptId.HasValue && optDtoArray != null)
                {
                    Dto.DscfACService.OperaterInfoDto optDto = optDtoArray.Where(dto => dto.Id == remind.CreateOptId.Value).FirstOrDefault();
                    if (optDto != null)
                    {
                        remindDto.OptName = optDto.Name;
                    }
                }
                dtoList.Add(remindDto);
            }

            return dtoList.ToArray();
        }
        public RemindExcleDto[] GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd)
        {
            IList<RemindExcleDto> dtoList = new List<RemindExcleDto>();
            List<RepayRemindDto> remindList = new List<RepayRemindDto>();
            CreditRemindListDto[] creditRemindList = null;
            CarRemindListDto[] caritRemindList = null;
            DictionaryDto[] repayRemindTypeList = null;

            #region 获取已提醒数据

            if (this.CurrentRepository is IRepayRemindRepository)
            {
                var repository = (IRepayRemindRepository)this.CurrentRepository;
                remindList = repository.GetRepayRemindListByKeys(productName, timeBegin, timeEnd);
            }
            Dto.DscfACService.OperaterInfoDto[] optDtoArray;

            var optIdArray = remindList.Select(remind => remind.CreateOptId.HasValue ? remind.CreateOptId.Value : -1).Distinct().ToArray();

            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                optDtoArray = client.GetOperaterInfoList(optIdArray);
            }

            foreach (var remind in remindList)
            {
                if (remind.CreateOptId.HasValue && optDtoArray != null)
                {
                    Dto.DscfACService.OperaterInfoDto optDto = optDtoArray.Where(dto => dto.Id == remind.CreateOptId.Value).FirstOrDefault();
                    if (optDto != null)
                    {
                        remind.OptName = optDto.Name;
                    }
                }
            }
            string reepayIdArray = "";
            for (int i = 0; i < remindList.Count; i++)
            {
                if (i == remindList.Count - 1)
                {
                    reepayIdArray += remindList[i].RepayId;
                }
                else
                {
                    reepayIdArray += remindList[i].RepayId + ",";
                }
            }

            #endregion

            #region 贷款提醒记录
            if (productName == 1 || productName == 0)
            {
                #region 信贷提醒

                using (Dto.DscfCreditLoanService.CreditLoanContractClient client = new Dto.DscfCreditLoanService.CreditLoanContractClient())
                {
                    creditRemindList = client.GetRepayRemindList(reepayIdArray);
                }
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    repayRemindTypeList = client.GetDictListByKey(DictUtil.RemindTypeKey);
                }
                foreach (var remind in remindList)
                {
                    DictionaryDto dicDto = repayRemindTypeList.Where(dic => dic.DictValue == remind.RemindType).FirstOrDefault();
                    if (dicDto != null)
                    {
                        remind.RemindTypeName = dicDto.DictMemo;
                    }
                }
                foreach (var remind in remindList)
                {
                    RemindExcleDto remindDto = null;

                    if (remind.RepayId.HasValue && reepayIdArray != null)
                    {
                        CreditRemindListDto optDto = creditRemindList.Where(dto => dto.OrderId == remind.RepayId.Value).FirstOrDefault();
                        if (optDto != null)
                        {
                            remindDto = new RemindExcleDto();
                            remindDto.RemindText = remind.RemindTypeName;
                            remindDto.PersonName = remind.OptName;
                            remindDto.SignCity = optDto.SignCity;
                            remindDto.UserName = optDto.UserName;
                            remindDto.UserPhone = optDto.UserPhone;
                            remindDto.ProductName = optDto.ProductName;
                            remindDto.CreateTime = remind.CreateTime;
                            remindDto.RemindContent = remind.RemindContent;
                            dtoList.Add(remindDto);
                        }
                    }

                }

                #endregion

            }
            if (productName == 2 || productName == 0)
            {
                #region 车贷提醒

                using (Dto.DscfCarLoanService.CarLoanContractClient client = new Dto.DscfCarLoanService.CarLoanContractClient())
                {
                    caritRemindList = client.GetRepayRemindList(reepayIdArray);
                }
                foreach (var remind in remindList)
                {
                    RemindExcleDto remindDto = null;

                    if (remind.RepayId.HasValue && reepayIdArray != null)
                    {
                        CarRemindListDto optDto = caritRemindList.Where(dto => dto.RepayId == remind.RepayId.Value).FirstOrDefault();
                        if (optDto != null)
                        {
                            remindDto = new RemindExcleDto();
                            remindDto.RemindText = optDto.RemindText;
                            remindDto.PersonName = remind.OptName;
                            remindDto.SignCity = optDto.SignCity;
                            remindDto.UserName = optDto.UserName;
                            remindDto.UserPhone = optDto.UserPhone;
                            remindDto.ProductName = optDto.ProductName;
                            remindDto.CreateTime = remind.CreateTime;
                            remindDto.RemindContent = remind.RemindContent;
                            dtoList.Add(remindDto);
                        }
                    }
                }

                #endregion
            }
            #endregion

            return dtoList.ToArray();
        }
        public bool AddRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto)
        {
            var repayRemind = repayRemindDto.ToEntity();
            repayRemind.IsDeleted = false;
            repayRemind.CreateTime = DateTime.Now;
            var boolean = this.CurrentRepository.Insert(repayRemind) > 0 ? true : false;
            dto = repayRemind.ToModel();
            return boolean;
        }
        public bool EditRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto)
        {
            var entity = this.CurrentRepository.Entities.Where(u => u.RemindId == repayRemindDto.RemindId).FirstOrDefault();
            entity.RemindContent = repayRemindDto.RemindContent;
            entity.RemindType = repayRemindDto.RemindType;
            entity.LastOperateId = repayRemindDto.LastOperateId;
            entity.LastUpdateTime = repayRemindDto.LastUpdateTime;
            var boolean = this.CurrentRepository.Update(entity) > 0 ? true : false;
            dto = entity.ToModel();
            return boolean;
        }
        public bool DelRepayMindByDto(RepayRemindDto repayRemindDto)
        {
            var entity = this.CurrentRepository.Entities.Where(u => u.RemindId == repayRemindDto.RemindId).FirstOrDefault();
            entity.IsDeleted = true;
            entity.LastOperateId = repayRemindDto.LastOperateId;
            entity.LastUpdateTime = repayRemindDto.LastUpdateTime;
            return (this.CurrentRepository.Update(entity) > 0 ? true : false);
        }
    }
}
