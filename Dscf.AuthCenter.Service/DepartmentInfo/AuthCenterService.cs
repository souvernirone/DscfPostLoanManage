using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Dto;
using Dscf.AuthCenter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Service
{
    public partial class AuthCenterService : IAuthCenterContract
    {
        public IDepartmentInfoManager DepartmentInfoManager { get; set; }

        public DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID)
        {
            return DepartmentInfoManager.GetChildDeptListByDeptID(parentDeptID);
        }
        public string[] GetDeptSignSitiesById(int key)
        {
            int[] deptIds = GetDeptIdsById(key);
            List<string> signSitie = new List<string>();
            if (deptIds == null)
            {
                return null;
            }
            else if (deptIds.Contains(-1))
            {
                signSitie.Add("-1");
                return signSitie.ToArray();
            }
            else
            {
                foreach (var depId in deptIds)
                {
                    var sity = this.DepartmentInfoManager.Entities.Where(depInfo => depInfo.Id == depId && depInfo.SignCity != null).FirstOrDefault();
                    if (sity == null)
                    {
                        continue;
                    }
                    else
                    {
                        signSitie.Add(sity.SignCity);
                    }

                }
                return signSitie.ToArray();
            }
        }
        public DepartmentInfoDto GetDeptByDeptID(int deptID)
        {
            return DepartmentInfoManager.GetDeptByDeptID(deptID);
        }
    }
}
