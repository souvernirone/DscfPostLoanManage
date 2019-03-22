using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class UserInfoDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DataMember]
        public int? Age { get; set; }


        /// <summary>
        /// 证件号码
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone { get; set; }


        /// <summary>
        /// 居住地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 居住邮编
        /// </summary>
        [DataMember]
        public string AddressZipCode { get; set; }

        /// <summary>
        /// 居住地电话
        /// </summary>
        [DataMember]
        public string AddressTel { get; set; }

        /// <summary>
        /// 户籍地址
        /// </summary>
        [DataMember]
        public string IdCardAddress { get; set; }

        /// <summary>
        /// 现住址开始居住时间
        /// </summary>
        [DataMember]
        public DateTime? NowAddressBeginTime { get; set; }

        /// <summary>
        /// 用户工作信息
        /// </summary>
        [DataMember]
        public UserWorkInfoDto UserWorkInfo { get; set; }

        /// <summary>
        /// 学历文本
        /// </summary>
        [DataMember]
        public string EducationText { get; set; }


        /// <summary>
        /// 婚姻状况
        /// </summary>
        [DataMember]
        public string MaritalTypeText { get; set; }

        /// <summary>
        /// 本市居住情况
        /// </summary>
        [DataMember]
        public string ResideTypeText { get; set; }

    }
}
