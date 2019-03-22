using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    /// <summary>
    /// 提交银联的信息
    /// </summary>
    [Serializable, DataContract]
    [KnownType("GetSubTypes")]
    public class UnionpayOperateModel
    {
        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public string AMOUNT
        {
            get;
            set;
        }

        /// <summary>
        /// 银行代码
        /// </summary>
        [DataMember]
        public string BANK_CODE { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [DataMember]
        public string BANK_NAME { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [DataMember]
        public string ACCOUNT_NO
        {
            get;
            set;
        }

        /// <summary>
        /// 开户人名称
        /// </summary>
        [DataMember]
        public string ACCOUNT_NAME { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 身份类型
        /// </summary>
        [DataMember]
        public string ID_TYPE { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string SN { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [DataMember]
        public string ContractNo { get; set; }


        /// <summary>
        /// 操作备注
        /// </summary>
        [DataMember]
        public string REMARK { get; set; }


        /// <summary>
        /// 扩展字段：借款Orderid
        /// </summary>
        [DataMember]
        public int? LoanOrderId { get; set; }


        /// <summary>
        /// 扩展字段：借款期数
        /// </summary>
        [DataMember]
        public int? RepayPeriod { get; set; }

        /// <summary>
        /// 扩展字段：期数Id
        /// </summary>
        [DataMember]
        public int? RepayId { get; set; }


        /// <summary>
        /// 中金唯一标识
        /// </summary>
        [DataMember]
        public string ZItemNo { get; set; }

        /// <summary>
        /// 中金账户类型 11:个人账户 12：企业账户
        /// </summary>
        [DataMember]
        public string ZAccountType { get; set; }

        /// <summary>
        /// 中金开户行支行
        /// </summary>
        [DataMember]
        public string ZBranchName { get; set; }


        /// <summary>
        /// 中金省份
        /// </summary>
        [DataMember]
        public string ZProvince { get; set; }

        /// <summary>
        /// 中金城市
        /// </summary>
        [DataMember]
        public string ZCity { get; set; }


        [DataMember]
        public string ZNote { get; set; }
        [DataMember]
        public string ZContractNo { get; set; }
        [DataMember]
        public string ZContractUserID { get; set; }
        [DataMember]
        public string ZPhoneNumber { get; set; }
        [DataMember]
        public string ZEmail { get; set; }

        

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
        /// 借款期数（银生宝）
        /// </summary>
        [DataMember]
        public int PeriodOrder { get; set; }

        /// <summary>
        /// 操作备注（银生宝）
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
