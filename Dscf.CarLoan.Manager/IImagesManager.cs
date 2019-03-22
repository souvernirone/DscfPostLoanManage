/*******************************************************
*类名称：IImagesManager
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:29:05
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Domain;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    //图片信息
    public interface IImagesManager : IGenericManager<Images>
    {
        bool UpdateImageById(int key);
    }
}
