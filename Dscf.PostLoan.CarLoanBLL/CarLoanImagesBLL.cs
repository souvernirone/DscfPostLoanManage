/*******************************************************
*类名称：CarLoanImagesBLL
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:47:22
*说明：
*更新备注：
**********************************************************/

using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanImagesBLL
    {
        public bool InsertImages(ImagesDto dto)
        {
            using (var client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.InsertImages(dto);
            }
        }

        public bool DelImgFalse(int key)
        {
            using (var client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.DelImgFalse(key);
            }
        }
        public ImagesDto[] GetImages(int key)
        {
            using (var client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.GetImages(key);
            }
        }
    }
}
