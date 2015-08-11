using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CoursePlatForm.Common
{
    public class NPOIHelper
    {

        public static string path;
        static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.BLANK:
                    return string.Empty;
                case CellType.BOOLEAN:
                    return cell.BooleanCellValue.ToString();
                case CellType.ERROR:
                    return cell.ErrorCellValue.ToString();
                case CellType.NUMERIC:
                case CellType.Unknown:
                default:
                    return cell.ToString();//This is a trick to get the correct value of the cell. NumericCellValue will return a numeric value no matter the cell value is a date or a number
                case CellType.STRING:
                    return cell.StringCellValue;
                case CellType.FORMULA:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }

        /// <summary>
        /// 返回excel的行数
        /// </summary>
        /// <returns></returns>
        public static int getRowNum()
        {
            Stream excelFileStream = File.OpenRead(path);
            using (excelFileStream)
            {
                using (IWorkbook workbook = new HSSFWorkbook(excelFileStream))
                {
                    using (ISheet sheet = workbook.GetSheetAt(0))//第一页
                    {
                        int rowCount = sheet.LastRowNum;
                        return rowCount + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Excel文档导入到数据库,返回插入数据行成功的数目,由于耦合度太高，无法拆分，写在一起，方法包含了数据操作
        /// </summary>
        /// <param name="listField">用于设置字段</param>
        /// <param name="listNewUser">用于关联上新添加的userID</param>
        /// <returns></returns>
        public static int RenderToDb(List<Tb_FieldTable> listField, List<Tb_SoftUser> listNewUser)
        {
            Stream excelFileStream = File.OpenRead(path);
            DBEntities db = new DBEntities();
            int rowAffected = 0;
            using (excelFileStream)
            {
                using (IWorkbook workbook = new HSSFWorkbook(excelFileStream))
                {
                    using (ISheet sheet = workbook.GetSheetAt(0))//第一页
                    {
                        StringBuilder builder = new StringBuilder();

                        IRow headerRow = sheet.GetRow(0);//第一行
                        int cellCount = headerRow.LastCellNum-1;//LastCellNum = PhysicalNumberOfCells
                        int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1
                        //拼接字段字符串
                        string strField = "";
                        foreach (Tb_FieldTable item in listField)
                        {
                            strField += "" + item.FieldName + ",";
                        }
                        strField = strField.Substring(0, strField.Length - 1);
                        int start;
                        for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                        {
                            start = 0;
                            IRow row = sheet.GetRow(i);
                            if (row != null)
                            {
                                builder.Append("insert into Tb_ApplyTable ");
                                builder.Append("(RecordTime,UserID," + strField + ") values ('" + DateTime.Today.ToShortDateString() + "','" + listNewUser[start].UserID + "',");
                                int j = row.FirstCellNum;
                                for (; j < cellCount; j++)
                                {
                                    builder.AppendFormat("'{0}',", GetCellValue(row.GetCell(j)).Replace("'", ""));
                                }
                                builder.Length = builder.Length - 1;
                                builder.Append(") select 1 where 1=@id;");


                                if ((i % 50 == 0 || i == rowCount) && builder.Length > 0)
                                {
                                    //每50条记录一次批量插入到数据库
                                    
                                }
                                SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
                                parameters[0].Value = 1;
                                rowAffected += db.Database.ExecuteSqlCommand(builder.ToString(), parameters);
                                builder.Length = 0;
                            }
                            start++;
                        }
                    }
                }
            }
            return rowAffected;
        }


    }
}