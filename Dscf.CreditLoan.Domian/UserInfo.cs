using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class UserInfo
    {
        public int UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        public string PassedName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public int? CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// IDCardState
        /// </summary>
        public int? IDCardState { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// PhoneState
        /// </summary>
        public int? PhoneState { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool? Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 最高学历
        /// </summary>
        public int? Education { get; set; }

        /// <summary>
        /// 毕业院校
        /// </summary>
        public string University { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int? Marital { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// AddressState
        /// </summary>
        public int? AddressState { get; set; }

        /// <summary>
        /// 居住邮编
        /// </summary>
        public string AddressZipCode { get; set; }

        /// <summary>
        /// 居住地电话
        /// </summary>
        public string AddressTel { get; set; }

        /// <summary>
        /// AddressTelState
        /// </summary>
        public int? AddressTelState { get; set; }

        /// <summary>
        /// 年收入
        /// </summary>
        public decimal? YearIncome { get; set; }

        /// <summary>
        /// 信用卡最高额度
        /// </summary>
        public decimal? CreditMaxAmount { get; set; }

        /// <summary>
        /// 共同居住者
        /// </summary>
        public int? CommonOccupants { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public int? NativePlace { get; set; }

        /// <summary>
        /// 户口所在地
        /// </summary>
        public int? RegPlace { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 账户级别
        /// </summary>
        public int? AccountGradeId { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 首次创建人
        /// </summary>
        public int? CreateOperateId { get; set; }

        /// <summary>
        /// 大地金融的用户Id
        /// </summary>
        public int? ddUserId { get; set; }

        /// <summary>
        /// 交接人ID
        /// </summary>
        public int? TransferId { get; set; }

        /// <summary>
        /// 工资是否打卡 0是 1不是
        /// </summary>
        public int? IsLocal { get; set; }

        /// <summary>
        /// 有无子女 0有 1没有
        /// </summary>
        public int? IsChildren { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// PosiTime
        /// </summary>
        public string PosiTime { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }

        /// <summary>
        /// NowAddress
        /// </summary>
        public string NowAddress { get; set; }

        /// <summary>
        /// NowAddressBeginTime
        /// </summary>
        public string NowAddressBeginTime { get; set; }

        /// <summary>
        /// IDCardValidity
        /// </summary>
        public string IDCardValidity { get; set; }

        /// <summary>
        /// UserSourceId
        /// </summary>
        public int? UserSourceId { get; set; }

        /// <summary>
        /// IdCardAddress
        /// </summary>
        public string IdCardAddress { get; set; }

        /// <summary>
        /// ResideType
        /// </summary>
        public int? ResideType { get; set; }

        /// <summary>
        /// CaId
        /// </summary>
        public string CaId { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public int? DepId { get; set; }

        /// <summary>
        /// ResideMemo
        /// </summary>
        public string ResideMemo { get; set; }

        /// <summary>
        /// 导航属性-家庭信息
        /// </summary>
        [ForeignKey("UserId")]
        public virtual UserFamilyInfo UserFamilyInfo { get; set; }

        /// <summary>
        /// 导航属性-工作信息
        /// </summary>
        [ForeignKey("UserId")]
        public virtual UserWorkInfo UserWorkInfo { get; set; }

    }
}
