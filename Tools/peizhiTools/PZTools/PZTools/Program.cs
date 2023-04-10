using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZTools
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.ReadKey();
            //待修改为整个文件夹遍历的
            string path = AppDomain.CurrentDomain.BaseDirectory+ "/../../../../../peizhi/最终的配置表/游戏配置.xlsx";
            string writePath = AppDomain.CurrentDomain.BaseDirectory+"/../../../../../GameConfig/";
            //string path = @"G:\dijiuse\Tools\peizhi\最终的配置表\Y英雄配置表.xlsx";
            //string writePath = @"G:\dijiuse\Tools\GameConfig\";
            //string path = @"J:\dijiuse\Tools\peizhi\最终的配置表\Y英雄配置表.xlsx";
            //string writePath = @"J:\dijiuse\Tools\GameConfig\";

            //表格的数据容器
            DataSet dataSet = IOTools.ExcelConnection(path);
            List<TableEntity> tabList = new List<TableEntity>();

            #region 先缓存每张表的数据
            //遍历每一张表
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable tab = dataSet.Tables[i];//表
                TableEntity tableEntity = new TableEntity();
                tableEntity.TableName = tab.TableName.Replace("$", "").Split('_')[1]; //表名
                for (int j = 0; j < tab.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(tab.Columns[j].ColumnName.Trim()))
                    {
                        tableEntity.FieldName.Add(tab.Columns[j].ColumnName);
                        tableEntity.FieldType.Add(tab.Rows[0][tab.Columns[j].ColumnName].ToString());
                        tableEntity.FieldList.Add(tab.Rows[1][tab.Columns[j].ColumnName].ToString());
                        Console.WriteLine(" 字段名称:" + tableEntity.FieldName[j]);
                        Console.WriteLine(" 字段类型:" + tableEntity.FieldType[j]);
                        Console.WriteLine(" 字段标识符:" + tableEntity.FieldList[j]);
                    }
                }
                
                //-------------分割线 取每条数据------------//

                //从第二行开始取实体数据
                for (int j = 2; j < tab.Rows.Count; j++)
                {
                    //一行的数据 
                    List<string> row = new List<string>();

                    //一行中的每个字段
                    for (int x = 0; x < tableEntity.FieldName.Count; x++)
                    {

                        row.Add(tab.Rows[j][tableEntity.FieldName[x]].ToString());
                    }

                    tableEntity.Rows.Add(row);
                }
                tabList.Add(tableEntity);
            }
            #endregion
            //for (int i = 0; i < tabList.Count; i++)
            //{
            //    for (int j = 0; j < tabList[i].Rows.Count; j++)
            //    {
            //        for (int k = 0; k < tabList[i].Rows[j].Count; k++)
            //        {
            //            Console.WriteLine(tabList[i].Rows[j][k]);
            //        }
            //    }
            //}

            //--------------分割线:生产实体模板--------------//

            #region 第二部分是计算生成什么代码

            string temp = @"
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ClassName
{

    static ClassName()
    {
        //初始化
    }

    //Get方法

    //创建实例
}

//实体类
";

            //对每张表进行解析
            for (int i = 0; i < tabList.Count; i++)
            {

                //创建实体类 加到每个配置的末尾
                string templateEntity = CreateEntity(tabList[i]);
                string init = CreateInit(tabList[i]);
                string get = CreateGet(tabList[i]);
                string instance = CreateGetInstance(tabList[i]);
                string configTemp = temp;
                configTemp = configTemp.Replace("ClassName", tabList[i].TableName)
                    .Replace("//初始化", init).Replace("//Get方法", get).Replace("//实体类", templateEntity).Replace("//创建实例",instance);
                Console.WriteLine(configTemp);

                #region 第三部分是将脚本文件创造出来

                IOTools.WriteFile(writePath + tabList[i].TableName + ".cs", configTemp);
                
                #endregion
            }
            #endregion
        }

        private static string CreateGet(TableEntity tableEntity)
        {
            string temp = @"
    static Dictionary<int, TempEntity> entityDic = new Dictionary<int, TempEntity>();
    public static TempEntity Get(int key)
    {
        if (entityDic.ContainsKey(key))
        {
            return entityDic[key];
        }
        return null;
    }";
            temp = temp.Replace("TempEntity", tableEntity.TableName.Replace("Config", "Entity"));
            Console.WriteLine(temp);
            return temp;
        }

        private static string CreateGetInstance(TableEntity tableEntity)
        {
            string temp = @"
   
    public static TempEntity GetInstance(int key)
    {
        TempEntity instance = new TempEntity();
        if (entityDic.ContainsKey(key))
        {
            //Instance
        }
        return instance;
    }";
            StringBuilder builder = new StringBuilder();
            string s = "            instance._key = entityDic[key]._key;";
            for (int i = 0; i < tableEntity.FieldList.Count; i++)
            {
                builder.AppendLine(s.Replace("_key", tableEntity.FieldList[i]));
            }
            //FieldName
            temp = temp.Replace("TempEntity", tableEntity.TableName.Replace("Config", "Entity")).Replace("//Instance", "\n"+builder.ToString());
            Console.WriteLine(temp);
            return temp;
        }

        public static string CreateInit(TableEntity tableEntity)
        {
            StringBuilder init = new StringBuilder();
            for (int j = 0; j < tableEntity.Rows.Count; j++)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                string entityName = tableEntity.TableName.Replace("Config", "Entity");
                string className = entityName + j;
                string temp = "       TempEntity tempEntity = new TempEntity();";
                string memberInit = "       tempEntity.m_id = m_value;";

                
                sb.AppendLine(temp.Replace("TempEntity", entityName).Replace("tempEntity", className));
                for (int k = 0; k < tableEntity.Rows[j].Count; k++)
                {
                    //字段名称都在这个里面
                    List<string> Row = tableEntity.Rows[j];
                    //换成字段的名称

                    //这里可以获取到每个成员变量的类型 名称
                    string initMember = memberInit;
                    initMember = memberInit.Replace("tempEntity", className).Replace("m_id",
                        tableEntity.FieldList[k]);
              


                    //sb = sb.AppendLine(t.Replace("tempEntity", entity).Replace("m_id",
                    //    tabList[i].FieldList[k]));
                    if (tableEntity.FieldType[k] == "string")
                    {
                        initMember = initMember.Replace("m_value", "@\"" + Row[k] + "\"");
                    }
                    else if (tableEntity.FieldType[k] =="float")
                    {
                        initMember = initMember.Replace("m_value", Row[k] + "f");
                    }
                    else if (tableEntity.FieldType[k] == "Vector3")
                    {
                        initMember = initMember.Replace("m_value", "new Vector3("+Row[k]+")");
                    }
                    else
                    {
                        if (Row[k]=="真")
                        {
                            initMember = initMember.Replace("m_value", "true");
                        }
                        else if (Row[k] == "假")
                        {
                            initMember = initMember.Replace("m_value", "false");
                        }
                        else
                        {
                            initMember = initMember.Replace("m_value", Row[k]);
                        }
                    }
                    sb.AppendLine(initMember);
                }
                string add = @"
        if (!entityDic.ContainsKey(tempEntity.ID))
        {
          entityDic.Add(tempEntity.ID, tempEntity);
        }";
                add = add.Replace("tempEntity", className);
                sb.AppendLine(add);
                init.Append(sb);
                Console.WriteLine(sb);
            }

            return init.ToString();
        }
        
        public static string CreateEntity(TableEntity tableEntity)
        {
            string templateEntity = @"
public class TemplateEntity
{
    //TemplateMember
}";
            StringBuilder entity = new StringBuilder();
            for (int i = 0; i < tableEntity.FieldList.Count; i++)
            {
                entity.AppendLine("    public " + tableEntity.FieldType[i] + " " + tableEntity.FieldList[i] + ";//"+ tableEntity.FieldName[i]);
            }
            templateEntity = templateEntity.Replace("TemplateEntity", tableEntity.TableName.Replace("Config","Entity"));
            templateEntity = templateEntity.Replace("//TemplateMember", "//TemplateMember" + "\n" + entity.ToString());
            Console.Write(templateEntity);
            return templateEntity;
        }

    }
}


public class TableEntity
{
    public string TableName;//表名
    public List<string> FieldName = new List<string>();//字段注释 索引0
    public List<string> FieldType = new List<string>();//字段数据类型 索引1
    public List<string> FieldList = new List<string>();//字段名称 索引2

    public List<List<string>> Rows = new List<List<string>>();//每一行的集合
}
