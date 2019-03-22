using Dscf.AuthCenter.Domain;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Manager.Implement
{
    public class OptDeptManager : GenericManagerBase<OptDept>, IOptDeptManager
    {
        public bool UpdateCollectorSupportCityList(int optId, int[] deptIdList, int sourceType)
        {
            //删除之前支持城市列表
            this.CurrentRepository.Delete(od => od.OptId == optId, false);

            if (deptIdList != null && deptIdList.Length > 0)
            {
                var list = deptIdList.Select(id => new OptDept { DeptId = id, OptId = optId, SourceType = sourceType });
                this.CurrentRepository.Insert(list, false);
            }

            //提交事务
            this.CurrentRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
