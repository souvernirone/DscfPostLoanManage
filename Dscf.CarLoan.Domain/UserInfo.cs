using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class UserInfo
    {

        /// <summary>
        /// UserInfoId
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        public string PassedName { get; set; }

        /// <summary>
        /// IDCard
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 身份证有效期
        /// </summary>
        public string IDCardValidity { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public bool? Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 最高学历
        /// </summary>
        public int? Education { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int? Marital { get; set; }

        /// <summary>
        /// 现住址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 现住址邮编
        /// </summary>
        public string AddressZipCode { get; set; }

        /// <summary>
        /// 现住址电话
        /// </summary>
        public string AddressTel { get; set; }

        /// <summary>
        /// 年收入
        /// </summary>
        public int? YearIncome { get; set; }

        /// <summary>
        /// 信用卡最高额度
        /// </summary>
        public int? CreditMaxAmount { get; set; }

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
        /// CaId
        /// </summary>
        public string CaId { get; set; }

        /// <summary>
        /// 现住址开始居住时间
        /// </summary>
        public string NowAddressBeginTime { get; set; }

        /// <summary>
        /// UserSourceId
        /// </summary>
        public int? UserSourceId { get; set; }

        /// <summary>
        /// 户籍地址
        /// </summary>
        public string IdCardAddress { get; set; }

        /// <summary>
        /// 住房类型
        /// </summary>
        public int? ResideType { get; set; }

        /// <summary>
        /// 其他住房类型
        /// </summary>
        public string ResideMemo { get; set; }

        /// <summary>
        /// IFRECrate
        /// </summary>
        public string IFRECrate { get; set; }

        /// <summary>
        /// IFREWyChance
        /// </summary>
        public string IFREWyChance { get; set; }

        /// <summary>
        /// IFREScore
        /// </summary>
        public string IFREScore { get; set; }

        /// <summary>
        /// 子女数量
        /// </summary>
        public string ChildCount { get; set; }

        /// <summary>
        /// 赡养父母数量
        /// </summary>
        public int? ParentCount { get; set; }

        /// <summary>
        /// 赡养父母情况
        /// </summary>
        public string ParentMemo { get; set; }

        /// <summary>
        /// StatusId
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 同住人数
        /// </summary>
        public string ResidentsCount { get; set; }

        /// <summary>
        /// 其他同住人
        /// </summary>
        public string OtherResidents { get; set; }

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
        /// 导航属性-工作信息
        /// </summary>
        [ForeignKey("UserId")]
        public virtual UserWorkInfo UserWorkInfo { get; set; }

    }
}
