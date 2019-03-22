using Dscf.Common.Manager.Implement;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CreditLoan.Dto.Extension;
using Dscf.CreditLoan.Dao;
using Dscf.PostLoanGlobal;

namespace Dscf.CreditLoan.Manager.Implement
{
    public class ProductManager : GenericManagerBase<Product>, IProductManager
    {
        //public IOperaterInfoRepository OperaterInfoRepository { get; set; }
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        public ProductDto[] GetLoanProductList(int type)
        {
            IList<Product> proList = this.CurrentRepository.Entities.Where(pro => pro.Type == type && pro.IsDeleted == 0).ToList();
            return proList.Select(pro => pro.ToModel()).ToArray();
        }
    }
}
