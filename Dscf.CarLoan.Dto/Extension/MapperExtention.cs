using AutoMapper;
using Dscf.CarLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto.Extension
{
    /// <summary>
    /// AutoMapper映射扩展
    /// </summary>
    public static class MapperExtention
    {

        #region LoanProductOrder
        public static CarLoanOrderDetailDto ToModel(this LoanProductOrder entity)
        {
            return Mapper.Map<LoanProductOrder, CarLoanOrderDetailDto>(entity);
        }
        #endregion

        #region LoanMonthRepay
        public static LoanMonthRepayDto ToModel(this LoanMonthRepay entity)
        {
            return Mapper.Map<LoanMonthRepay, LoanMonthRepayDto>(entity);
        }
        #endregion

        #region CarLoanExtensionApply
        public static CarLoanExtensionApplyDto ToModel(this CarLoanExtensionApply entity)
        {
            return Mapper.Map<CarLoanExtensionApply, CarLoanExtensionApplyDto>(entity);
        }

        public static CarLoanExtensionApply ToEntity(this CarLoanExtensionApplyDto model)
        {
            return Mapper.Map<CarLoanExtensionApplyDto, CarLoanExtensionApply>(model);
        }
        #endregion

        #region ExhibitionReview
        public static ExhibitionReviewDto ToModel(this ExhibitionReview entity)
        {
            return Mapper.Map<ExhibitionReview, ExhibitionReviewDto>(entity);
        }

        public static ExhibitionReview ToEntity(this ExhibitionReviewDto model)
        {
            return Mapper.Map<ExhibitionReviewDto, ExhibitionReview>(model);
        }
        #endregion

        #region Images-文件图片
        public static ImagesDto ToModel(this Images entity)
        {
            return Mapper.Map<Images, ImagesDto>(entity);
        }

        public static Images ToEntity(this ImagesDto model)
        {
            return Mapper.Map<ImagesDto, Images>(model);
        }
        #endregion
        public static DeductProgressDto ToModel(this DeductProgress entity)
        {
            return Mapper.Map<DeductProgress, DeductProgressDto>(entity);
        }
    }
}
