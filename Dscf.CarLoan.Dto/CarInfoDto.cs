using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //车辆信息
    [DataContract]
    public class CarInfoDto
    {
        /// <summary>
        /// CarInfoId
        /// </summary>
        [DataMember]
        public int CarInfoId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [DataMember]
        public string LicensePlate { get; set; }

        /// <summary>
        /// 品牌型号
        /// </summary>
        [DataMember]
        public string VehicleBrands { get; set; }

        /// <summary>
        /// 权属证书编号
        /// </summary>
        [DataMember]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 保险期限
        /// </summary>
        [DataMember]
        public string TermInsurance { get; set; }

        /// <summary>
        /// 车辆违章情况说明
        /// </summary>
        [DataMember]
        public string ViolateComment { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        [DataMember]
        public string ChassisNumber { get; set; }

        /// <summary>
        /// 出场日期
        /// </summary>
        [DataMember]
        public DateTime? ManufactureDate { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        [DataMember]
        public DateTime? RegistDate { get; set; }

        /// <summary>
        /// 排量
        /// </summary>
        [DataMember]
        public string Displacement { get; set; }

        /// <summary>
        /// 行驶里程数
        /// </summary>
        [DataMember]
        public int? Distance { get; set; }

        /// <summary>
        /// 变数器（手动/自动）
        /// </summary>
        [DataMember]
        public int? Gearbox { get; set; }

        /// <summary>
        /// 是否改装
        /// </summary>
        [DataMember]
        public int? IsModify { get; set; }

        /// <summary>
        /// 改装情况
        /// </summary>
        [DataMember]
        public string ModifyMemo { get; set; }

        /// <summary>
        /// 同类市场价格
        /// </summary>
        [DataMember]
        public decimal? SimilarMarketPrice { get; set; }

        /// <summary>
        /// 开票价
        /// </summary>
        [DataMember]
        public decimal? OpenFare { get; set; }

        /// <summary>
        /// 过户次数
        /// </summary>
        [DataMember]
        public int? OwnershipNum { get; set; }

        /// <summary>
        /// 座位数
        /// </summary>
        [DataMember]
        public int? CarSeats { get; set; }

        /// <summary>
        /// 天窗类型
        /// </summary>
        [DataMember]
        public int? Dormer { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

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
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

        /// <summary>
        /// MTypeName
        /// </summary>
        [DataMember]
        public string MTypeName { get; set; }

        /// <summary>
        /// EngineNumber
        /// </summary>
        [DataMember]
        public string EngineNumber { get; set; }


    }
}
