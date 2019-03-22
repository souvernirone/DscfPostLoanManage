using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.AuthCenter.Dto;

namespace Dscf.AuthCenter.Service
{
    public partial class AuthCenterService : IAuthCenterContract
    {
        public IRoleManager RoleManager { get; set; }

    }
}
