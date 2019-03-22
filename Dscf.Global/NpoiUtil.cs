﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Collections;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;

namespace Dscf.Global
{
    /// <summary>
    /// NPOI工具类
    /// </summary>
    public class NpoiUtil
    {

        #region 内存表转文件流

        /// <summary>
        /// 转换内存表为EXCEL文件流(行数超过65535，sheet分页)
        /// </summary>
        /// <param name="SourceTable">源数据</param>
        /// <param name="sheetSize">sheet最大行数，不大于65535</param>
        /// <param name="DateTimeFormat">时间列格式化</param>
        /// <returns>EXCEL文件流</returns>
        public static Stream RenderDataTableToPagingExcelStream(DataTable SourceTable, int sheetSize = 65535, string DateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();

            IDataFormat dataformat = workbook.CreateDataFormat();
            ICellStyle style = workbook.CreateCellStyle();

            int count = SourceTable.Rows.Count;
            int total = count / sheetSize + (count % sheetSize > 0 ? 1 : 0);

            for (
                    int sheetIndex = 0;
                    sheetIndex < total;
                    sheetIndex++)
            {
                ISheet sheet = workbook.CreateSheet();
                IRow headerRow = sheet.CreateRow(0);

                // handling header. 
                foreach (DataColumn column in SourceTable.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

                // handling value. 
                int rowIndex = 1;

                for (int i = sheetIndex * sheetSize;
                    i < (total.Equals(sheetIndex + 1) ? count : (sheetIndex + 1) * sheetSize);
                    i++)
                {
                    DataRow row = SourceTable.Rows[i];

                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in SourceTable.Columns)
                    {
                        if (row[column] is DBNull)
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(string.Empty);
                            continue;
                        }
                        if (column.DataType == typeof(int))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((int)row[column]);
                        }
                        else if (column.DataType == typeof(float))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((float)row[column]);
                        }
                        else if (column.DataType == typeof(double))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((double)row[column]);
                        }
                        else if (column.DataType == typeof(Byte))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((byte)row[column]);
                        }
                        else if (column.DataType == typeof(UInt16))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((UInt16)row[column]);
                        }
                        else if (column.DataType == typeof(UInt32))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((UInt32)row[column]);
                        }
                        else if (column.DataType == typeof(UInt64))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((UInt64)row[column]);
                        }
                        else if (column.DataType == typeof(DateTime))
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue((DateTime)row[column]);
                            style.DataFormat = dataformat.GetFormat(DateTimeFormat);
                            dataRow.GetCell(column.Ordinal).CellStyle = style;
                        }
                        else
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(Convert.ToString(row[column]));
                        }
                    }
                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                headerRow = null;
            }
            workbook = null;

            return ms;
        }

        /// <summary>
        /// 转换内存表为EXCEL文件流
        /// </summary>
        /// <param name="SourceTable">源数据</param>
        /// <param name="DateTimeFormat">时间列格式化</param>
        /// <returns>EXCEL文件流</returns>
        public static Stream RenderDataTableToExcelStream(DataTable SourceTable, string DateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            // handling header. 
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value. 
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                IDataFormat dataformat = workbook.CreateDataFormat();
                ICellStyle style = workbook.CreateCellStyle();

                foreach (DataColumn column in SourceTable.Columns)
                {
                    if (row[column] is DBNull)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(string.Empty);
                        continue;
                    }

                    if (column.DataType == typeof(int))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((int)row[column]);
                    }
                    else if (column.DataType == typeof(float))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((float)row[column]);
                    }
                    else if (column.DataType == typeof(double))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((double)row[column]);
                    }
                    else if (column.DataType == typeof(Byte))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((byte)row[column]);
                    }
                    else if (column.DataType == typeof(UInt16))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((UInt16)row[column]);
                    }
                    else if (column.DataType == typeof(UInt32))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((UInt32)row[column]);
                    }
                    else if (column.DataType == typeof(UInt64))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((UInt64)row[column]);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((DateTime)row[column]);
                        style.DataFormat = dataformat.GetFormat(DateTimeFormat);
                        dataRow.GetCell(column.Ordinal).CellStyle = style;
                    }
                    else
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(Convert.ToString(row[column]));
                    }
                }
                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        #endregion

        #region 文件流转内存表

        /// <summary>
        /// 将EXCEL文件流转换成内存表
        /// </summary>
        /// <param name="ExcelFileStream">EXCEL文件流</param>
        /// <param name="SheetName">表名</param>
        /// <param name="HeaderRowIndex">标题索引</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ISheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 将EXCEL文件流转换成内存表
        /// </summary>
        /// <param name="ExcelFileStream"></param>
        /// <param name="file"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="HeaderRowIndex"></param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string file, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = null;
            string fileExt = Path.GetExtension(file);
            if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook(ExcelFileStream);
            }
            else if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook(ExcelFileStream);
            }
            ISheet sheet = workbook.GetSheetAt(SheetIndex);
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = 0; i < rowCount + 1; i++)
            {

                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j <= cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                table.Rows.Add(dataRow);
            }
            table.Rows.RemoveAt(0);
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        #endregion

        #region 文件下载与导出

        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <param name="dt">内存表</param>
        /// <param name="fileName">文件名（不要包含后缀）</param>
        /// <param name="sheetSize">sheet最大行数，不大于65535</param>
        public static void ExportExcel(DataTable dt, string fileName = "", int sheetSize = 1023)
        {
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                string.Format("attachment; filename={0}.xls",
                string.IsNullOrWhiteSpace(fileName) ?
                DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") :
                fileName));
            using (MemoryStream ms = (dt.Rows.Count > sheetSize ? RenderDataTableToPagingExcelStream(dt, sheetSize) : RenderDataTableToPagingExcelStream(dt)) as MemoryStream)
            {
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 导出Excel文件请求
        /// </summary>
        /// <param name="dt">内存表</param>
        /// <param name="fileName">文件名（不要包含后缀）</param>
        /// <param name="sheetSize">sheet最大行数，不大于65535</param>
        public static HttpResponseMessage ExportExcelResponse(DataTable dt, string fileName = "", int sheetSize = 1023)
        {
            //创建HTTP请求内容
            HttpResponseMessage httpRspMsg = new HttpResponseMessage(HttpStatusCode.OK);

            httpRspMsg.Content = new StreamContent(
                dt.Rows.Count > sheetSize ?
                RenderDataTableToPagingExcelStream(dt, sheetSize) :
                RenderDataTableToExcelStream(dt));

            //通知浏览器下载文件而不是打开
            httpRspMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpRspMsg.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = string.Format("{0}.xls",
                string.IsNullOrWhiteSpace(fileName) ?
                DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") :
                fileName)
            };

            return httpRspMsg;
        }

        /// <summary>
        /// 下载本地目录的EXCEL文件
        /// </summary>
        /// <param name="filePath">完整文件目录</param>
        /// <param name="fileName">重命名下载文件名称（不要包含后缀名）</param>
        public static void DownLoadFile(string filePath, string fileName = "")
        {
            //文件后缀
            string fileExt = Path.GetExtension(filePath);

            if (fileExt.ToLower().IndexOf("xls") < 0)
                throw new Exception("不能下载非EXCEL格式的文件！");

            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                string.Format("attachment; filename={0}",
                string.IsNullOrWhiteSpace(fileName) ?
                Path.GetFileName(filePath) :
                fileName + fileExt));

            //以字符流的形式下载文件
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                HttpContext.Current.Response.BinaryWrite(bytes);
                bytes = null;
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 将内存表转换的EXCEL文件保存到本地
        /// </summary>
        /// <param name="SourceTable">源数据</param>
        /// <param name="FileName">文件名</param>
        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            using (MemoryStream ms = RenderDataTableToExcelStream(SourceTable) as MemoryStream)
            {
                using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    data = null;
                }
            }
        }

        #endregion

        #region List转DataTable

        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="header">列头</param>
        /// <returns></returns>
        public static DataTable List2DataTable<T>(List<T> list, IDictionary<string, string> header = null) where T : class
        {
            //如果header无效
            if (header == null || header.Count == 0)
                return GetDataTable(list, typeof(T));

            DataTable dt = new DataTable();

            PropertyInfo[] p = typeof(T).GetProperties();
            foreach (PropertyInfo pi in p)
            {
                //源数据实体是否包含header列
                if (header.ContainsKey(pi.Name))
                {
                    // The the type of the property
                    Type columnType = pi.PropertyType;

                    // We need to check whether the property is NULLABLE
                    if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                        columnType = pi.PropertyType.GetGenericArguments()[0];
                    }

                    dt.Columns.Add(header[pi.Name], columnType);
                }
            }

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    IList tempList = new ArrayList();
                    foreach (PropertyInfo pi in p)
                    {
                        object o = pi.GetValue(list[i], null);
                        if (header == null || header.Count == 0 ||  //如果header无效
                            header.ContainsKey(pi.Name))            // 或源数据实体包含header列
                        {
                            tempList.Add(o);
                        }
                    }
                    object[] itm = new object[header.Count];
                    for (int j = 0; j < tempList.Count; j++)
                    {
                        itm.SetValue(tempList[j], j);
                    }
                    dt.LoadDataRow(itm, true);
                }
            }
            List<string> dtColumnList = new List<string>();

            try
            {
                for (int i = 0; i < header.Count; i++)
                {
                    foreach (KeyValuePair<string, string> item in header)
                    {
                        if (dtColumnList.Where(c => c.Equals(item.Value)).FirstOrDefault() == null)
                        {
                            dt.Columns[item.Value].SetOrdinal(i);
                            dtColumnList.Add(item.Value);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        /// <summary>
        /// Converts a Generic List into a DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <param name="typ"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(IList list, Type typ)
        {
            DataTable dt = new DataTable();

            // Get a list of all the properties on the object
            PropertyInfo[] pi = typ.GetProperties();

            // Loop through each property, and add it as a column to the datatable
            foreach (PropertyInfo p in pi)
            {
                // The the type of the property
                Type columnType = p.PropertyType;

                // We need to check whether the property is NULLABLE
                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                    columnType = p.PropertyType.GetGenericArguments()[0];
                }

                // Add the column definition to the datatable.
                dt.Columns.Add(new DataColumn(p.Name, columnType));
            }

            // For each object in the list, loop through and add the data to the datatable.
            foreach (object obj in list)
            {
                object[] row = new object[pi.Length];
                int i = 0;

                foreach (PropertyInfo p in pi)
                {
                    row[i++] = p.GetValue(obj, null);
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        #endregion

    }
}

