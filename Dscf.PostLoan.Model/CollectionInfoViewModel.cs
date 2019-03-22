using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dscf.PostLoan.Model
{
    /// <summary>
    /// 催收信息ViewModel
    /// </summary>
    public class CollectionInfoViewModel
    {
        /// <summary>
        /// 催收主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 借款订单编号
        /// </summary>
        [Required]
        public int? OrderId { get; set; }

        /// <summary>
        /// 借款订单类型
        /// </summary>
        [Required]
        public int? OrderType { get; set; }

        /// <summary>
        /// 催收状态
        /// </summary>
        [DisplayName("催收状态：")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "催收状态不能为空")]
        public int? CollectionStatus { get; set; }

        /// <summary>
        /// 外访地址
        /// </summary>
        [DisplayName("外访地址：")]
        [Required(ErrorMessage = "外访地址不能为空")]
        public string OutboundAddress { get; set; }

        /// <summary>
        /// 联络人类型
        /// </summary>
        [DisplayName("联络人：")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "联络人不能为空")]
        public int? LinkPersonType { get; set; }

        /// <summary>
        /// 催收记录
        /// </summary>
        [DisplayName("催收记录：")]
        [Required(ErrorMessage = "催收记录不能为空")]
        public string CollectionRecord { get; set; }

        /// <summary>
        /// 催收上传资料
        /// </summary>
        [DisplayName("上传材料：")]
        [Required(ErrorMessage = "上传材料不能为空")]
        public List<HttpPostedFileBase> CollectionFileList { get; set; }

    }
}
