/*******************************************************
*类名称：数据字典表
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:43:16
*说明：
*更新备注：
**********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class Dictionary
    {
        public int DictId { get; set; }

        public int? Parent { get; set; }
        public string DictKey { get; set; }

        public int? DictValue { get; set; }

        public string DictMemo { get; set; }

        public int? Sort { get; set; }

        public DateTime CreateTime { get; set; }

        public int? OperateId { get; set; }

        public int? LastOperateId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? IsEnable { get; set; }

        public int? IsDelete { get; set; }
    }
}
