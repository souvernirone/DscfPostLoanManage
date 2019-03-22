/*******************************************************
*类名称：CarLoanService
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 11:38:10
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.CarLoan.Dto.Extension;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public IExhibitionReviewManager ExhibitionReviewManager { get; set; }

        public ExhibitionReviewDto[] GetExhibitionReviewlist(int? orderId)
        {
            var list = this.ExhibitionReviewManager.Entities.Where(review => review.LoanOrderId == orderId).OrderByDescending(review => review.Id).ToList();
            return list.Select(review => review.ToModel()).ToArray();
        }

        public bool InsertExhibitionReview(ExhibitionReviewDto reviewDto, out ExhibitionReviewDto dto)
        {
            var entity = reviewDto.ToEntity();
            var rowCount = this.ExhibitionReviewManager.Insert(entity);
            dto = entity.ToModel();
            return rowCount > 0 ? true : false;

        }


        public bool UpdateExhibitionReview(ExhibitionReviewDto reviewDto, out ExhibitionReviewDto dto)
        {
            var entity = reviewDto.ToEntity();
            var rowCount = this.ExhibitionReviewManager.Update(entity);
            dto = entity.ToModel();
            return rowCount > 0 ? true : false;
        }

    }
}
