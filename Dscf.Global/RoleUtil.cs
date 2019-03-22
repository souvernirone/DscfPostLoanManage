using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    /// <summary>
    /// 角色工具类
    /// </summary>
    public static class RoleUtil
    {
        /// <summary>
        /// 车贷催收人员角色ID
        /// </summary>
        public static int CarLoanCollectorRole
        {
            get { return 1029; }
        }


        /// <summary>
        /// 信贷催收人员角色ID
        /// </summary>
        public static int CreditLoanCollectorRole
        {
            get { return 1028; }
        }

        /// <summary>
        /// P2P-客户服务角色ID
        /// </summary>
        public static int P2PCustomerServiceRole
        {
            get { return 4033; }
        }
        public static int SystemAdministrator
        {
            get { return 8; }
        }
        public static int DepartmentAdministrator
        {
            get { return 9; }
        }
        public static int CollectionSupervisor
        {
            get { return 1030; }
        }
        public static int SettlementPersonnel
        {
            get { return 1031; }
        }


    }
}
