using Dscf.CarLoan.Dao;
using Dscf.CarLoan.Domain;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager.Implement
{
    //车贷展期
    public class CarLoanExtensionManager : GenericManagerBase<CarLoanExtension>, ICarLoanExtensionManager
    {
        public CarLoanExtensionManager(ICarLoanExtensionRepository repository)
        {
            this.CurrentRepository = repository;
        }

        /// <summary>
        /// 获取展期信息
        /// </summary>
        /// <returns></returns>
        public CarLoanExtension[] GetCarLoanExtensionList()
        {
            var list = this.CurrentRepository.Entities.Where(ext => ext.IsDelete == 0 && ext.IsEnable == 1).ToArray();
            return list;
        }
    }
}
