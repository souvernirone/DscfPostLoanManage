using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    public static class FileUtil
    {
        /// <summary>
        /// 判断指定文件是否为图片
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static bool IsImage(Stream stream)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                stream.Seek(0, SeekOrigin.Begin);  
            }
        }
    }
}
