using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToolsPB
{
    public class Tools
    {
        //第一步:读取表格
        //第二步:获取到每张表的数据,生成一个字典
        //第三步:将每张表的数据加到字典中
        //第四步:生成.proto文件
        //第五步:生成.cs文件
        //第六步:扩展,遍历基类,生成.sql文件
        //第七步:遍历其他类,生成gameModule文件

        //key类名 类结构
        //Dictionary<string, string> tab = new Dictionary<string, string>();

        //key:表名  value:表的内容    
        static Dictionary<string, List<TabData>> tabsDic = new Dictionary<string, List<TabData>>();
        

        /// <summary>
        /// 读取表格,转换为字典
        /// </summary>
        public static void ExcelToDic()
        {
            DataSet dataSet = IOTools.ExcelConnection("Proto配置表.xlsx");

            //遍历每一张表
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {

                //存储一张表所有的内容
                List<TabData> tabList = new List<TabData>();
                //tabData = null;

                var tab = dataSet.Tables[i];
                var TabName = tab.TableName.Replace("$", "").Split('_')[1];
                //遍历表中的每一行 
                for (int j = 0; j < tab.Rows.Count; j++)
                {
                    var row = tab.Rows[j];
                    if (row["协议名称"].ToString() != "")
                    {
                        //创建一个类
                        TabData tabData = new TabData();
                        tabData.TabID = int.Parse(row["协议ID"].ToString());
                        tabData.ClassName = row["协议名称"].ToString();
                        tabData.Notes = row["注释"].ToString();
                        if (TabName == "Root")
                        {
                            if (row["所属数据库"].ToString() != "")
                            {
                                
                                tabData.DataBaseName = row["所属数据库"].ToString();
                            }
                            if (row["生成数据表"].ToString() != "")
                            {
                                tabData.IsCreateTab = row["生成数据表"].ToString()== "是";
                            }
                            if (row["生成存储过程"].ToString() != "")
                            {
                                
                                tabData.IsCreateCMDFile = row["生成存储过程"].ToString() == "是";
                            }
                        }
                        tabList.Add(tabData);
                    }
                    else
                    {
                        if (row["字段"].ToString() != "")
                        {
                            string rowString = "";
                            string isList = row["修饰符"].ToString() == "repeated" ? "是" : "否";
                            if (TabName == "Root")
                            {
                                //string defult = row["默认值"].ToString() == "" ? "Null" : row["默认值"].ToString();
                                //string isMainKey = row["是否主键"].ToString() == "" ? "FALSE" : row["是否主键"].ToString();
                                //string isAutoAdd = row["是否自增"].ToString() == "" ? "FALSE" : row["是否自增"].ToString();

                                //string defult = row["默认值"].ToString() == "" ? "" : row["默认值"].ToString();
                                //string isMainKey = row["是否主键"].ToString() == "" ? "" : row["是否主键"].ToString();
                                //string isAutoAdd = row["是否自增"].ToString() == "" ? "" : row["是否自增"].ToString();
                                rowString = isList + "&" + row["类型"] + "&" + row["字段"]
                                + "&" + row["注释"] + "&" + row["默认值"] + "&" + row["是否主键"]
                                + "&" + row["是否自增"];
                            }
                            else
                            {
                                rowString = isList + "&" + row["类型"] + "&" + row["字段"]
                              + "&" + row["注释"];
                            }

                            Console.WriteLine(TabName + " " + rowString);
                            tabList[tabList.Count - 1].FieldList.Add(rowString);
                        }
                    }
                }
                tabsDic.Add(TabName, tabList);

            }

            Console.WriteLine("一共有多少张表:" + tabsDic.Keys.Count);
            //foreach (var item in tabsDic.Keys)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            for (int i = 0; i < tabsDic["Root"].Count; i++)
            {
                for (int j = 0; j < tabsDic["Root"][i].FieldList.Count; j++)
                {
                    Console.WriteLine("确认:" + tabsDic["Root"][i].FieldList[j]);
                }

            }
            CreateProtoFile();
            CreateProtoConfig();
            CreateDataBase();
            CreateStoredProcedure();
            CreateGameMoudle();
            CallBatCMD();
            Console.ReadKey();
        }

        /// <summary>
        /// 创建Protofile
        /// </summary>
        public static void CreateProtoFile()
        {
            List<TabData> tabDatas = new List<TabData>();

            //写入文件 IOTools.WriteFile
            foreach (var key in tabsDic.Keys)
            {
                //获取到每一张表
                string pbName = key.ToString() + "PB.proto";

                StringBuilder sb = new StringBuilder();
                //表头
                sb.Append("syntax =" + '"' + "proto3" + '"' + ";");
                sb.Append("\r\n");
                sb.Append("package ProtoMsg;");
                sb.Append("\r\n");
                if (key.ToString() != "Root")
                {
                    sb.Append("import \"RootPB.proto\";");
                    sb.Append("\r\n");
                }

                sb.Append("\r\n");

                //遍历每张表中的每个类
                for (int i = 0; i < tabsDic[key].Count; i++)
                {
                    sb.Append("message " + tabsDic[key][i].ClassName + "{");
                    sb.Append("\r\n");
                    for (int j = 0; j < tabsDic[key][i].FieldList.Count; j++)
                    {
                        string[] Field = tabsDic[key][i].FieldList[j].Split('&');
                        //是否List 类型 名称 注释 索引从j+1开始
                        sb.Append("	" + (Field[0] == "是" ? "repeated " : "") + Field[1] + " " + Field[2] + "=" + (j + 1) + ";//" + Field[3]);
                        //if (key.ToString()=="Root")
                        //{

                        //}
                        sb.Append("\r\n");
                    }
                    sb.Append("\r\n");
                    sb.Append("}");
                    sb.Append("\r\n");
                    sb.Append("\r\n");
                }

                IOTools.WriteFile(Config.pbOutPath + pbName, sb.ToString());
                Console.WriteLine("创建Pb:" + pbName);

            }
        }

        /// <summary>
        /// 创建protoConfig
        /// </summary>
        public static void CreateProtoConfig()
        {

            StringBuilder C2SList = new StringBuilder();
            StringBuilder S2CList = new StringBuilder();

            List<TabData> tabDatas = new List<TabData>();
            foreach (var key in tabsDic.Keys)
            {
                tabDatas.AddRange(tabsDic[key]);
            }

            List<TabData> tabs = new List<TabData>();
            for (int i = 0; i < tabDatas.Count; i++)
            {
                for (int j = i + 1; j < tabDatas.Count; j++)
                {
                    if (tabDatas[i].TabID > tabDatas[j].TabID)
                    {
                        var TabData = tabDatas[i];
                        tabDatas[i] = tabDatas[j];
                        tabDatas[j] = TabData;
                    }
                }
            }

            for (int i = 0; i < tabDatas.Count; i++)
            {
                if (tabDatas[i].ClassName.Contains("C2S"))
                {
                    C2SList.Append("\r\n");
                    C2SList.Append("            PBC2SDic.Add(" + tabDatas[i].TabID + ',' + "typeof(" + tabDatas[i].ClassName + "));");

                }
                else if (tabDatas[i].ClassName.Contains("S2C"))
                {
                    S2CList.Append("\r\n");
                    S2CList.Append("            PBS2CDic.Add(" + tabDatas[i].TabID + ',' + "typeof(" + tabDatas[i].ClassName + "));");

                }

            }
            string pbConfig = IOTools.GetFileText(Config.configPath + "PBConfig模板.txt");
            Console.WriteLine(pbConfig);
            pbConfig = pbConfig.Replace("//初始化c2s", C2SList.ToString());
            pbConfig = pbConfig.Replace("//初始化s2c", S2CList.ToString());
            Console.WriteLine(pbConfig);
            IOTools.WriteFile(Config.pbconfigPath, pbConfig);//创建PBConfig
                                                             //Console.WriteLine(pbConfig);

        }


        /// <summary>
        /// 创建数据库与表
        /// </summary>
        public static void CreateDataBase()
        {

            StringBuilder sb = new StringBuilder();
            List<TabData> tabs = tabsDic["Root"];

            List<string> dbName = new List<string>();
            for (int i = 0; i < tabs.Count; i++)
            {
                //判断所属数据库是否等于空 
                //如果不等于空
                //加入判断生成数据库的语句
                //判断是否需要生成数据表
                //如果需要创建数据表
                //就创建A表记录当前信息
                //B表记录过往操作.....  操作ID..操作时间..操作结果..
                //然后创建字段 设置字段属性 是否主键 是否有默认值 是否自增

                if (tabs[i].DataBaseName != "")
                {
                    if (!dbName.Contains(tabs[i].DataBaseName))
                    {
                        dbName.Add(tabs[i].DataBaseName);
                    }
                }
            }
            for (int i = 0; i < dbName.Count; i++)
            {
                sb.Append("drop database if exists " + dbName[i] + ";");
                sb.Append("\r\n");
                sb.Append("Create Database If Not Exists " + dbName[i] + ";");
                sb.Append("\r\n");
            }

            //创建表
            for (int i = 0; i < tabs.Count; i++)
            {
                if (tabs[i].DataBaseName != "")
                {
                    string tabsName = tabs[i].ClassName.ToLower() + "_a";
                    sb.Append("use " + tabs[i].DataBaseName + ";");//切换至数据库
                    sb.Append("\r\n");
                    sb.Append("drop table if exists " + tabsName + ";");//如果包含该表则先删除表
                    sb.Append("\r\n");
                    sb.Append("create table " + tabsName + "(");//创建该表
                    sb.Append("\r\n");
                    //for每一个字段
                    for (int j = 0; j < tabs[i].FieldList.Count; j++)
                    {
                        //是否List 类型 名称 注释 默认值,是否主键,是否自增
                        string[] Field = tabs[i].FieldList[j].Split('&');
                        sb.Append(Field[2] + " " + GetDBType(Field[1]));
                        if (Field[6].ToString() == "是")
                        {
                            sb.Append(" auto_increment ");
                        }
                        if (Field[5] == "是")
                        {
                            sb.Append(" primary key ");
                        }
                        if (j != tabs[i].FieldList.Count - 1)
                        {
                            sb.Append(",");
                        }
                        sb.Append("\r\n");

                    }
                    sb.Append(")default charset=utf8;");//创建该表
                }
            }
            IOTools.WriteFile(Config.sqlFile, sb.ToString());//创建PBConfig

        }

        /// <summary>
        /// 创建存储过程
        /// </summary>
        public static void CreateStoredProcedure()
        {
            //
            string dbcmd = IOTools.GetFileText(Config.configPath + "数据库操作类.txt");

            //确定哪些是需要生成存储过程的

            List<TabData> tabs = tabsDic["Root"];
            for (int i = 0; i < tabs.Count; i++)
            {
                Console.WriteLine(tabs[i].ClassName+":"+ tabs[i].IsCreateCMDFile);
                if (tabs[i].IsCreateCMDFile == true)
                {
                    string file = dbcmd.Replace("classname", tabs[i].ClassName);

                    //Select 1
                    StringBuilder select = new StringBuilder();

                    //StringBuilder insert = new StringBuilder();

                    StringBuilder ikey = new StringBuilder();
                    StringBuilder ivalue = new StringBuilder();
                    //为该类开发存储过程
                    for (int j = 0; j < tabs[i].FieldList.Count; j++)
                    {
                        //是否List 类型 名称 注释 默认值,是否主键,是否自增
                        string[] Field = tabs[i].FieldList[j].Split('&');
                        select.Append("\r\n");
                        select.Append("                " + tabs[i].ClassName + "." +
                            Field[2] + "=" + "r.Get" + GetRowDataType(Field[1]) + "(\"" + Field[2] + "\");"
                            );

                        //insert.Append("\r\n");
                        //如果不是自增
                        if (Field[6]!="是")
                        {
                            ikey.Append(Field[2]);//+ ","
                            if (j != tabs[i].FieldList.Count-1)
                            {
                                ikey.Append(",");
                            }

                            Console.WriteLine(".............."+j);
                            ivalue.Append(GetIValues(Field[1],tabs[i].ClassName + "." +Field[2], ivalue.ToString()));
                            ivalue.Append("\r\n"+"                        ");
                            //insert.Append("                    " + "v = v.Insert(" + '"' + Field[2] + '"' + ',' + tabs[i].ClassName + "." +
                            //  Field[2] + ");");
                        }
                    }
                    string execute = "";
                   
                    //if (ikey.Length>0)
                    //{
                    //    ikey = ikey.Remove(ikey.Length - 1, 1);
                    //}
                    //if (ivalue.Length>0)
                    //{
                    //    ivalue = ivalue.Remove(ivalue.Length - 4, 4);
                    //}

                    string insert = "string sqlCmd = \"insert into " + (tabs[i].ClassName.ToLower() + "_a(Ikey)  values(\"")
                        + "Ivalue" + "+\")\";";
                    
                    insert = insert.Replace("Ikey", ikey.ToString()).Replace("Ivalue", ivalue.ToString());

                    file = file.Replace("//遍历每一行表格", select.ToString());
                    file = file.Replace("//插入所有字段", insert.ToString());
                    file = file.Replace("dbname", tabs[i].ClassName.ToLower() + "_a");
                    file = file.Replace("tablename", tabs[i].ClassName.ToLower() + "_a");
                    //"dbtype"
                    file = file.Replace("\"dbtype\"", tabs[i].DataBaseName== "loluser" ? "ConnectType.USER": "ConnectType.GAME");

                    file = file.Replace("//执行命令", execute);
                    //file = file.Replace("\"dbconnection\"", dbconnection);
                    //创建.cs存储过程文件
                    IOTools.WriteFile(Config.dbOutPath + "DB" + tabs[i].ClassName + ".cs", file);
                    Console.WriteLine("创建DB操作文件:"+"DB" + tabs[i].ClassName + ".cs");
                }
            }
            //
        }


        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <param name="typeStr"></param>
        /// <returns></returns>
        public static string GetDBType(string typeStr)
        {
            string str = "";

            typeStr = typeStr.Replace(" ", "");
            switch (typeStr)
            {
                case "int32":
                case "int64":
                    str = "int";
                    break;
                case "string":
                    str = "varchar(255)";
                    break;
                case "float":
                    str = "float";
                    break;
                case "bool":
                    str = "TinyInt(1)";
                    break;
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// 获取数据库操作的类型
        /// </summary>
        /// <param name="typeStr"></param>
        /// <returns></returns>
        static string GetRowDataType(string typeStr)
        {
            string targetStr = "";
            typeStr = typeStr.Replace(" ", "");
            switch (typeStr)
            {
                case "int32":
                    targetStr = "Int32";
                    break;
                case "int64":
                    targetStr = "Int64";
                    break;
                case "string":
                    targetStr = "String";
                    break;
                case "bool":
                    targetStr = "Boolean";
                    break;
                case "float":
                    targetStr = "Float";
                    break;
                case "datetime":
                    targetStr = "String";
                    break;
                default:
                    break;
            }
            return targetStr;
        }

        static string GetIValues(string dataType,string v,string ivalue)
        {
            //由类型决定 字符串的格式 
            string targetStr = "";
            dataType = dataType.Replace(" ", "");
            switch (dataType)
            {
                case "string":
                    //v是字段名称 ivalue如果本身是没有内容的 就不追加逗号在前面
                    string stringstr = ivalue == "" ? ("+\"\\\"\" + str + \"\\\"\"") : ("+\",\" +\"\\\"\" + str + \"\\\"\"");
                        //"+\"\\\"\" + str + \"\\\",\"";
                    targetStr = stringstr.Replace("str", v);
                    break;

                case "int32":
                case "int64":
                case "bool":
                case "float":
                    string intStr = ivalue == "" ? ("+str") :("+\",\" + str");
                        //" +str+ \",\" ";
                    targetStr = intStr.Replace("str",v);
                    break;
                //case "datetime":
                //    targetStr = "String";
                //break;
                //default:
                //    break;
            }
            return targetStr;
        }



        /// <summary>
        /// 创建游戏模块
        /// </summary>
        public static void CreateGameMoudle()
        {
            //先获取模板
            //修改模板
            //遍历每个类对应的List 对应的Count 每个Count如果包含C2S就需要进行监听来自客户端的消息
            string text = IOTools.GetFileText(Config.configPath + "GameModule.txt");

            string funModul = @"
         /// <summary> 方法注释 </summary>
        private void Handle__C2S(MsgEntity p)
        {
            __C2S c2sMsg = __C2S.Parser.ParseFrom(p.body);

            __S2C s2cMsg = new __S2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }";

            foreach (var key in tabsDic.Keys)
            {
                if (key != "Root")
                {


                    //脚本名称
                    string scriptName = key.ToString() + "Module";
                    StringBuilder addSB = new StringBuilder();
                    StringBuilder fun = new StringBuilder();
                    StringBuilder removeSB = new StringBuilder();

                    //获取到每个List
                    for (int i = 0; i < tabsDic[key].Count; i++)
                    {
                        string className = tabsDic[key][i].ClassName;

                        //监听C2S的类
                        if (className.Contains("C2S"))
                        {
                            //创造一个类

                            addSB.Append("\r\n");
                            addSB.Append("            NetEvent.Instance.AddEventListener(" + tabsDic[key][i].TabID + ", Handle" + className + ");//" + tabsDic[key][i].Notes);

                            removeSB.Append("\r\n");
                            removeSB.Append("            NetEvent.Instance.RemoveEventListener(" + tabsDic[key][i].TabID + ", Handle" + className + ");//" + tabsDic[key][i].Notes);

                            fun.Append("\r\n");
                            string tempFun = funModul.Replace("方法注释", tabsDic[key][i].Notes);
                            fun.Append(tempFun.Replace("__", className.Replace("C2S", "")));

                        }
                    }
                    string scriptText = text.Replace("xxx", scriptName);
                    scriptText = scriptText.Replace("//添加监听", addSB.ToString());
                    scriptText = scriptText.Replace("//移除监听", removeSB.ToString());
                    scriptText = scriptText.Replace("//实现的监听", fun.ToString());

                    Console.WriteLine("创建:" + scriptName + ".cs");
                    IOTools.WriteFile(Config.gmOutPath + scriptName + ".cs", scriptText);
                }
            }
        }

        /// <summary>
        /// 执行Proto的批处理
        /// </summary>
        public static void CallBatCMD()
        {
            Process pro = new Process();
            pro.StartInfo.WorkingDirectory = Config.batPath;
            pro.StartInfo.FileName = "_GenAllC#.bat";
            //pro.StartInfo.Arguments = string.Format("10");//this is argument
            //pro.StartInfo.CreateNoWindow = true;
            //pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行

            pro.Start();
            pro.WaitForExit();

            //pro.StartInfo.UseShellExecute = false;
            //pro.StartInfo.RedirectStandardInput = false;
            //proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.CreateNoWindow = true;
            //string result = pro.StandardOutput.ReadToEnd();
            Console.WriteLine("批处理执行结束");

        }

    }

    public class TabData
    {
        //public string TabName;
        public int TabID;
        public string ClassName = "";
        public string DataBaseName = "";//属于哪个数据库的
        public bool IsCreateTab = false;//是否创建数据表
        public bool IsCreateCMDFile;//是否创建C#操作类
        public string Notes = "";
        public bool IsAutoAdd = false;

        //字段集合,格式:是否List,类型,名称,注释,默认值,是否主键,是否自增
        public List<string> FieldList = new List<string>();
    }
}