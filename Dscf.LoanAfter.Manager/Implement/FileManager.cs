using Dscf.Common.Manager.Implement;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager.Implement
{
    //T_File
    public class FileManager : GenericManagerBase<FileEntity>, IFileManager
    {
        public static readonly string UpFilePath = ConfigurationManager.AppSettings["UpFilePath"];

        public static readonly string UpFileIPAddress = ConfigurationManager.AppSettings["UpFileIPAddress"];

        public UpFileResultMessage UpLoadFile(UpFileMessage fileMessage)
        {
            try
            {

                string now = DateTime.Today.ToString("yyyyMMdd");
                string guid = Guid.NewGuid().ToString();

                //获取文件扩展名
                var fileSuffix = Path.GetExtension(fileMessage.OriginalFileName);

                var uploadFolder = Path.Combine(FileManager.UpFilePath, now);

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                //保存文件名
                string saveFileName = guid + fileSuffix;
                string filePath = Path.Combine(uploadFolder, saveFileName);


                UpFileResultMessage upFileResult = new UpFileResultMessage()
                {
                    IsSuccess = true,
                    FileName = Path.GetFileNameWithoutExtension(fileMessage.OriginalFileName),
                    FileSuffix = fileSuffix,
                    FilePath = string.Format(@"{0}/{1}", FileManager.UpFileIPAddress, now),
                    SaveFileName = guid
                };

                using (Stream sourceStream = fileMessage.FileStream)
                {
                    using (FileStream targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        const int bufferLen = 1024 * 4;//4KB
                        byte[] buffer = new byte[bufferLen];
                        int count = 0;
                        while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                        {
                            targetStream.Write(buffer, 0, count);
                        }
                    }
                    //上传文件为图片时,需创建缩略图
                    if (fileMessage.IsImage)
                    {
                        var uploadThumbFolder = Path.Combine(uploadFolder, "Thumb");

                        if (!Directory.Exists(uploadThumbFolder))
                        {
                            Directory.CreateDirectory(uploadThumbFolder);
                        }
                        using (FileStream targetStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            string thumbFilePath = Path.Combine(uploadThumbFolder, saveFileName);
                            int width = fileMessage.ThumbWidth.HasValue ? fileMessage.ThumbWidth.Value : 200;
                            int height = fileMessage.ThumbHeight.HasValue ? fileMessage.ThumbHeight.Value : 100;
                            CreateThumbnail(thumbFilePath, targetStream, width, height);
                            upFileResult.ThumbPath = string.Format(@"{0}/{1}/Thumb", FileManager.UpFileIPAddress, now);
                        }
                    }
                }

                return upFileResult;
            }
            catch (Exception ex)
            {
                return new UpFileResultMessage() { IsSuccess = false, Message = ex.Message };
            }

        }

        /// <summary>
        /// 创建指定图片文件流的缩略图
        /// </summary>
        /// <param name="thumbFilePath">缩略图文件保存路径</param>
        /// <param name="fileStream">原始文件流</param>
        /// <param name="width">缩略图宽</param>
        /// <param name="height">缩略图高</param>
        private void CreateThumbnail(string thumbFilePath, Stream fileStream, int width, int height)
        {
            using (Image image = Image.FromStream(fileStream))
            {
                using (Image thumbnail = image.GetThumbnailImage(width, height, null, IntPtr.Zero))
                {
                    thumbnail.Save(thumbFilePath);
                }
            }

        }
    }
}
