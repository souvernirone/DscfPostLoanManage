using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //车辆信息
    public class CarInfo
    {
        /// <summary>
        /// CarInfoId
        /// </summary>
        public int CarInfoId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// 品牌型号
        /// </summary>
        public string VehicleBrands { get; set; }

        /// <summary>
        /// 权属证书编号
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 保险期限
        /// </summary>
        public string TermInsurance { get; set; }

        /// <summary>
        /// 车辆违章情况说明
        /// </summary>
        public string ViolateComment { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string ChassisNumber { get; set; }

        /// <summary>
        /// 出场日期
        /// </summary>
        public DateTime? ManufactureDate { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? RegistDate { get; set; }

        /// <summary>
        /// 排量
        /// </summary>
        public string Displacement { get; set; }

        /// <summary>
        /// 行驶里程数
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// 变数器（手动/自动）
        /// </summary>
        public int? Gearbox { get; set; }

        /// <summary>
        /// 是否改装
        /// </summary>
        public int? IsModify { get; set; }

        /// <summary>
        /// 改装情况
        /// </summary>
        public string ModifyMemo { get; set; }

        /// <summary>
        /// 同类市场价格
        /// </summary>
        public decimal? SimilarMarketPrice { get; set; }

        /// <summary>
        /// 开票价
        /// </summary>
        public decimal? OpenFare { get; set; }

        /// <summary>
        /// 过户次数
        /// </summary>
        public int? OwnershipNum { get; set; }

        /// <summary>
        /// 座位数
        /// </summary>
        public int? CarSeats { get; set; }

        /// <summary>
        /// 天窗类型
        /// </summary>
        public int? Dormer { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// MTypeName
        /// </summary>
        public string MTypeName { get; set; }

        /// <summary>
        /// EngineNumber
        /// </summary>
        public string EngineNumber { get; set; }


    }
}
