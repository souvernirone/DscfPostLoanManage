using Dscf.PostLoan.Model.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dscf.PostLoan.Model
{
    public class DeductPayApplyViewModel
    {
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// 借款订单类型 1-信用借款 2-车辆借款
        /// </summary>
        [Required]
        public int OrderType { get; set; }

        /// <summary>
        /// 本次减免金额
        /// </summary>
        [Required(ErrorMessage = "减免金额不能为空")]
        public decimal ReliefAmount { get; set; }

        /// <summary>
        /// 本次还款金额
        /// </summary>
        [Required(ErrorMessage = "还款金额不能为空")]
        public decimal RepayAmount { get; set; }

        /// <summary>
        /// 还款支付方式
        /// </summary>
        [Required]
        public int PayWay { get; set; }

        public string Remark { get; set; }

        [Required(ErrorMessage = "上传材料不能为空")]
        [ValidateImageFile]
        public HttpPostedFileBase PayImage { get; set; }
    }
}
