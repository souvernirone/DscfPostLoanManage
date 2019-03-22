using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //面签信息
    public class SignedInfo
    {
        /// <summary>
        /// SignId
        /// </summary>
        public int SignId { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string CovenantNo { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime? SigningDate { get; set; }

        /// <summary>
        /// 客户银行信息编号
        /// </summary>
        public int? UserBankInfoId { get; set; }

        /// <summary>
        /// 面签状态
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 大堂ID
        /// </summary>
        public int? LobbyId { get; set; }

        /// <summary>
        /// SignMemo
        /// </summary>
        public string SignMemo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 合同开始日期
        /// </summary>
        public DateTime? CovenantStartDate { get; set; }

        /// <summary>
        /// GPS序列号，多个用逗号分隔
        /// </summary>
        public string GPSNumber { get; set; }

        /// <summary>
        /// 身份证原件true为原价，false为复印件
        /// </summary>
        public bool? IdCardType { get; set; }

        /// <summary>
        /// 身份证是否交付
        /// </summary>
        public bool? IdCardPass { get; set; }

        /// <summary>
        /// 发票
        /// </summary>
        public bool? InvoicePass { get; set; }

        /// <summary>
        /// 过户购置税
        /// </summary>
        public bool? TransferPass { get; set; }

        /// <summary>
        /// 暂住证
        /// </summary>
        public bool? TemporaryPass { get; set; }

        /// <summary>
        /// 钥匙
        /// </summary>
        public bool? KeyPass { get; set; }

        /// <summary>
        /// 交强险
        /// </summary>
        public bool? StronginsurancePass { get; set; }

        /// <summary>
        /// 完税证明
        /// </summary>
        public bool? TCCPass { get; set; }

        /// <summary>
        /// 登记证
        /// </summary>
        public bool? RegistrationCertificatePass { get; set; }

        /// <summary>
        /// 行驶证
        /// </summary>
        public bool? DrivingLicensePass { get; set; }

        /// <summary>
        /// 商业保险单
        /// </summary>
        public bool? CommercialInsurancePass { get; set; }

        /// <summary>
        /// 进口车相关文件
        /// </summary>
        public bool? ImportVehiclePass { get; set; }

        /// <summary>
        /// 车钥匙数量
        /// </summary>
        public int? KeyNumber { get; set; }

        /// <summary>
        /// 车辆交接时间
        /// </summary>
        public DateTime? VehicleHandoverTime { get; set; }

        /// <summary>
        /// 其他说明
        /// </summary>
        public string OtherMemo { get; set; }

        /// <summary>
        /// 签署地
        /// </summary>
        public string SignCity { get; set; }

        /// <summary>
        /// ProvinceId
        /// </summary>
        public int? ProvinceId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        public int? CityId { get; set; }    
    }
}
