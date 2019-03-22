using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Dscf.Global.Unionpay.Model
{

    /// <summary>
    /// 提交银联的信息
    /// </summary>
    [Serializable, DataContract]
    [KnownType("GetSubTypes")]
    public class UnionpaySubmitModel
    {

        /// <summary>
        /// 第三方支付类型
        /// </summary>
        [DataMember]
        public PaymentType PaymentType
        {
            get;
            set;
        }


        /// <summary>
        /// 中金支付操作类型
        /// </summary>
        [DataMember]
        public ChinaPayMentType ChinaPayMentType
        {
            get;
            set;
        }


        /// <summary>
        /// 银联操作类型（银联）
        /// </summary>
        [DataMember]
        public EUnionPayType UnionPayType
        {
            get;
            set;
        }

        /// <summary>
        /// 业务代码（银联）
        /// </summary>
        [DataMember]
        public string BUSINESS_CODE { get; set; }

        /// <summary>
        /// 商户代码（银联）
        /// </summary>
        [DataMember]
        public string MERCHANT_ID { get; set; }

        /// <summary>
        /// 总金额（中金）
        /// </summary>
        [DataMember]
        public string TOTAL_SUM { get; set; }


        /// <summary>
        /// 提交时间（中金）
        /// </summary> 
        [DataMember]
        public string SubmitTime { get; set; }

        /// <summary>
        /// 总数量（中金）
        /// </summary>
        [DataMember]
        public string TOTAL_ITEM { get; set; }



        /// <summary>
        /// 划扣类型 , 普通划扣:0，预约划扣:1（银联）
        /// </summary>
        [DataMember]
        public string DEDUCT_TYPE { get; set; }


        /// <summary>
        /// 操作信息 ： 划扣或划付详细信息（中金）
        /// </summary>
        [DataMember]
        public IList<UnionpayOperateModel> PayList { get; set; }


        /// <summary>
        /// 流水号 随机数（银联）
        /// </summary>
        [DataMember]
        public string RandomStr { get; set; }


        /// <summary>
        /// 中金批次号（中金）
        /// </summary>
        [DataMember]
        public string ZBatchNo { get; set; }


        /// <summary>
        /// 备注（中金）
        /// </summary>
        [DataMember]
        public string ZRemark { get; set; }

        /// <summary>
        /// 代付标识  0:普通代付 1:支付账户余额代付 （中金）
        /// </summary>
        [DataMember]
        public string ZPaymentFlag { get; set; }

        /// <summary>
        /// 响应地址（银生宝）
        /// </summary>
        [DataMember]
        public string ResponseUrl { get; set; }
        /// <summary>
        /// 商户号（银生宝）
        /// </summary>
        [DataMember]
        public string AaccountId { get; set; }

        /// <summary>
        /// 身份证号（银生宝）
        /// </summary>
        [DataMember]
        public string IdCardNo { get; set; }
        /// <summary>
        /// 用户姓名（银生宝）
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 银行卡号（银生宝）
        /// </summary>
        [DataMember]
        public string CardNo { get; set; }

        /// <summary>
        /// 手机号（银生宝）
        /// </summary>
        [DataMember]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 商户生成的唯一订单号（银生宝）
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }

        /// <summary>
        /// 订单的订单号（银生宝）
        /// </summary>
        [DataMember]
        public int? DscfOrderId { get; set; }

        /// <summary>
        /// 付款目的（银生宝）
        /// </summary>
        [DataMember]
        public string Purpose { get; set; }

        /// <summary>
        ///  金额（银生宝）
        /// </summary>
        [DataMember]
        public string Amount { get; set; }

        /// <summary>
        /// 数字签名（银生宝）
        /// </summary>
        [DataMember]
        public string Mac { get; set; }

        /// <summary>
        /// 保证金余额（银生宝）
        /// </summary>
        [DataMember]
        public string BailBalance { get; set; }

        /// <summary>
        /// 账户余额（银生宝）
        /// </summary>
        [DataMember]
        public string Balance { get; set; }

        /// <summary>
        /// 密钥（银生宝）
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// 子协议开始时间（银生宝）
        /// </summary>
        [DataMember]
        public string StartDate { get; set; }

        /// <summary>
        /// 子协议结束时间（银生宝）
        /// </summary>
        [DataMember]
        public string EndDate { get; set; }

        /// <summary>
        /// 扣款频率 1、每年 2、每月 3、每日（银生宝）
        /// </summary>
        [DataMember]
        public string Cycle { get; set; }

        /// <summary>
        /// 扣款次数限制（银生宝）
        /// </summary>
        [DataMember]
        public string TriesLimit { get; set; }

        /// <summary>
        /// 商户协议编号（银生宝）
        /// </summary>
        [DataMember]
        public string ContractId { get; set; }

        /// <summary>
        /// 子协议编号（银生宝）
        /// </summary>
        [DataMember]
        public string SubContractId { get; set; }
        
        /// <summary>
        /// 操作备注（银生宝）
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 期数id
        /// </summary>
        [DataMember]
        public int? RepayId { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        [DataMember]
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// 划付日期（划扣日期）
        /// </summary>
        [DataMember]
        public DateTime? DepositTime { get; set; }

    }
}
