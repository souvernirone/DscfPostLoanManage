/*******************************************************
*类名称：IImagesRepository
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:27:12
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Domain;
using Dscf.Common.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao
{
    //图片信息
    public interface IImagesRepository : IRepository<Images>
    {

    }
}
