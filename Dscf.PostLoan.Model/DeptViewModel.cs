﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class DeptViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 签约地址
        /// </summary>
        public string SignAddress { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        public string SignCity { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string AgreeNum { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal AgreeAmount { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
