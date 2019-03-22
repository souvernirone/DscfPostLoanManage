using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    public class ResultMessage
    {
        #region 构造函数
        public ResultMessage()
        { }

        public ResultMessage(bool returnType)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnType ? "操作成功" : "操作失败";
        }

        public ResultMessage(bool returnType, string returnMsg)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
        }

        public ResultMessage(bool returnType, string returnMsg, object returnData)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnData = returnData;
        }

        public ResultMessage(bool returnType, string returnMsg, int returnCount)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnCount = returnCount;
        }

        public ResultMessage(bool returnType, string returnMsg, int returnCount, object returnData)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnCount = returnCount;
            this.ReturnData = returnData;
        }
        #endregion

        /// <summary>
        /// 返回是否成功的类型
        /// </summary>
        public bool ReturnType { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object ReturnData { get; set; }

        /// <summary>
        /// 返回的数据记录总数
        /// </summary>
        public int ReturnCount { get; set; }
    }
}
