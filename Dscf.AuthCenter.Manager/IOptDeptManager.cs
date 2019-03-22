using Dscf.AuthCenter.Domain;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Manager
{
    public interface IOptDeptManager:IGenericManager<OptDept>
    {
        /// <summary>
        /// 更新指定催收人员负责的城市列表
        /// </summary>
        /// <param name="optId">催收人员ID</param>
        /// <param name="deptIdList">营业部主键ID列表</param>
        /// <returns></returns>
        bool UpdateCollectorSupportCityList(int optId, int[] deptIdList,int sourceType);
       
    }
}
