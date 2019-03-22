using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //面签信息
    [DataContract]
    public class SignedInfoDto
    {
        /// <summary>
        /// SignId
        /// </summary>
        [DataMember]
        public int SignId { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [DataMember]
        public string CovenantNo { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [DataMember]
        public DateTime? SigningDate { get; set; }

        /// <summary>
        /// 客户银行信息编号
        /// </summary>
        [DataMember]
        public int? UserBankInfoId { get; set; }

        /// <summary>
        /// 面签状态
        /// </summary>
        [DataMember]
        public int? StatusId { get; set; }

        /// <summary>
        /// 大堂ID
        /// </summary>
        [DataMember]
        public int? LobbyId { get; set; }

        /// <summary>
        /// SignMemo
        /// </summary>
        [DataMember]
        public string SignMemo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 合同开始日期
        /// </summary>
        [DataMember]
        public DateTime? CovenantStartDate { get; set; }

        /// <summary>
        /// GPS序列号，多个用逗号分隔
        /// </summary>
        [DataMember]
        public string GPSNumber { get; set; }

        /// <summary>
        /// 身份证原件true为原价，false为复印件
        /// </summary>
        [DataMember]
        public bool IdCardType { get; set; }

        /// <summary>
        /// 身份证是否交付
        /// </summary>
        [DataMember]
        public bool IdCardPass { get; set; }

        /// <summary>
        /// 发票
        /// </summary>
        [DataMember]
        public bool InvoicePass { get; set; }

        /// <summary>
        /// 过户购置税
        /// </summary>
        [DataMember]
        public bool TransferPass { get; set; }

        /// <summary>
        /// 暂住证
        /// </summary>
        [DataMember]
        public bool TemporaryPass { get; set; }

        /// <summary>
        /// 钥匙
        /// </summary>
        [DataMember]
        public bool KeyPass { get; set; }

        /// <summary>
        /// 交强险
        /// </summary>
        [DataMember]
        public bool StronginsurancePass { get; set; }

        /// <summary>
        /// 完税证明
        /// </summary>
        [DataMember]
        public bool TCCPass { get; set; }

        /// <summary>
        /// 登记证
        /// </summary>
        [DataMember]
        public bool RegistrationCertificatePass { get; set; }

        /// <summary>
        /// 行驶证
        /// </summary>
        [DataMember]
        public bool DrivingLicensePass { get; set; }

        /// <summary>
        /// 商业保险单
        /// </summary>
        [DataMember]
        public bool CommercialInsurancePass { get; set; }

        /// <summary>
        /// 进口车相关文件
        /// </summary>
        [DataMember]
        public bool ImportVehiclePass { get; set; }

        /// <summary>
        /// 车钥匙数量
        /// </summary>
        [DataMember]
        public int? KeyNumber { get; set; }

        /// <summary>
        /// 车辆交接时间
        /// </summary>
        [DataMember]
        public DateTime? VehicleHandoverTime { get; set; }

        /// <summary>
        /// 其他说明
        /// </summary>
        [DataMember]
        public string OtherMemo { get; set; }

        /// <summary>
        /// 签署地
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// ProvinceId
        /// </summary>
        [DataMember]
        public int? ProvinceId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        [DataMember]
        public int? CityId { get; set; }    
    }
}
