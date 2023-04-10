using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PZTools
{

    public class IOTools
    {

      /// <summary>
      /// 读取表格
      /// </summary>
      /// <param name="filePath">表格路径</param>
      /// <returns></returns>
        public static DataSet ExcelConnection(string filePath)//, string tableName)
        {
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filePath + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataSet ds = new DataSet();
            //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等    
            DataTable dtSheetName = conn.GetOleDbSchemaTable(
            OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

            //包含excel中表名的字符串数组  
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k++)
            {
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            }
            for (int i = 0; i < strTableNames.Length; i++)
            {
                OleDbDataAdapter odda = new OleDbDataAdapter("select * from [" + strTableNames[i].ToString() + "]", conn); //("select * from [Sheet1$]", conn);
                odda.Fill(ds, strTableNames[i]);// "[" + tableName + "$]");
            }

            conn.Close();
            return ds;
        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileText(string filePath)
        {
            string content = string.Empty;

            if (!File.Exists(filePath))
            {
                return content;
            }

            using (StreamReader sr = File.OpenText(filePath))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }


        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void WriteFile(string path, string content)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                using (StreamWriter sw = new StreamWriter(fs, UTF8Encoding.UTF8))
                {
                    sw.Write(content.ToString());
                }
            }
        }

    }
}
