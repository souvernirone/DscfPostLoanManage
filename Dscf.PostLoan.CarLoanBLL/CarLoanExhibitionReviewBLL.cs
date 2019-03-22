/*******************************************************
*类名称：CarLoanExhibitionReviewBLL
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 11:58:22
*说明：
*更新备注：
**********************************************************/

using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanExhibitionReviewBLL
    {
        public bool InsertExhibitionReview(ExhibitionViewModel vm, out ExhibitionReviewDto dto, int opertaterId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new CarLoanContractClient())
            {
                var listReview = client.GetExhibitionReviewlist(vm.OrderId);
                var review = listReview.OrderByDescending(item => item.Id).FirstOrDefault();

                //如果不是展期复议退回,修改原数据,否则重新添加
                var dtoReview = (review != null && review.StatusId != 3002) ? review : new ExhibitionReviewDto();

                dtoReview.LoanOrderId = vm.OrderId;
                dtoReview.Memo = vm.StoreOption;
                dtoReview.UserId = vm.UserId;
                dtoReview.CarExtensionId = vm.LobbyLoanExtensionId;
                dtoReview.IsDelete = 0;
                dtoReview.IsEnable = 1;
                dtoReview.StatusId = 2002;//展期复议保存

                if (review != null && review.StatusId != 3002)
                {
                    dtoReview.LastUpdateTime = DateTime.Now;
                    dtoReview.LastOperateId = opertaterId;
                    return client.UpdateExhibitionReview(dtoReview, out dto);
                }
                else
                {
                    dtoReview.CreateTime = DateTime.Now;
                    dtoReview.OperateId = opertaterId;
                    return client.InsertExhibitionReview(dtoReview, out dto);
                }

            }

        }

        /// <summary>
        /// 展期复议提交
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool SubmitExhibitionReview(ExhibitionViewModel vm, out ExhibitionReviewDto dto, int opertaterId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new CarLoanContractClient())
            {
                var listReview = client.GetExhibitionReviewlist(vm.OrderId);
                var review = listReview.OrderByDescending(item => item.Id).FirstOrDefault();

                //如果不是展期复议退回,修改原数据,否则重新添加
                var dtoReview = (review != null && review.StatusId != 3002) ? review : new ExhibitionReviewDto();

                dtoReview.LoanOrderId = vm.OrderId;
                dtoReview.Memo = vm.StoreOption;
                dtoReview.UserId = vm.UserId;
                dtoReview.CarExtensionId = vm.LobbyLoanExtensionId;
                dtoReview.IsDelete = 0;
                dtoReview.IsEnable = 1;


                var orderDto = client.GetLoanProductOrderSingleById(vm.OrderId);

                if (review != null && review.StatusId != 3002)
                {
                    orderDto.ReconsiderationStatusId = 2003;
                }
                else
                {
                    orderDto.ReconsiderationStatusId = 2004;
                }

                orderDto.IsExtension = 1;

                var success = client.UpdateLoanProductOrder(orderDto);

                if (!success)
                {
                    throw new Exception("插入展期复议时更新借款订单信息失败!");
                }

                if (review != null && review.StatusId != 3002)
                {
                    dtoReview.StatusId = 2003;//展期复议提交
                    dtoReview.LastUpdateTime = DateTime.Now;
                    dtoReview.LastOperateId = opertaterId;
                    return client.UpdateExhibitionReview(dtoReview, out dto);
                }
                else
                {
                    dtoReview.StatusId = 2004;//展期复议-重新提交
                    dtoReview.CreateTime = DateTime.Now;
                    dtoReview.OperateId = opertaterId;
                    return client.InsertExhibitionReview(dtoReview, out dto);
                }
            }
        }
        public ExhibitionReviewDto GetExhibitionReviewDto(int orderId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.GetExhibitionReviewlist(orderId).OrderByDescending(item => item.Id).FirstOrDefault();
            }
        }
    }
}
