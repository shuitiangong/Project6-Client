using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToolsPB
{
    public class Config
    {

        public static string outPath = new DirectoryInfo("../").FullName;//当前应用程序路径的上级目录
        //上 上 上 上级目录的
        public static string path = new DirectoryInfo("../../../../").FullName;

       
        public static string pbOutPath = path + "Protoc_3.4.0_bin/ProtoFile/";

        //@"H:\城盛网络工作文件夹\后端自动化工具\Protobuf\ProtoFile\";//输出路径
        public static string gmOutPath = path + "GameModule/";//CS文件输出路径
        public static string dbOutPath = path + "DBCMD/";//CS文件输出路径
        public static string configPath = "模板/";//
        public static string batPath = path +"Protoc_3.4.0_bin";
        public static string pbconfigPath = path + "/Protoc_3.4.0_bin/cs/"+"PBConfig.cs";
        public static string sqlFile = path + "sqlscript.sql";


        public static bool isCreateCSFile = true;//是否生成CS文件

        public static int pbVersion = 3;//

        public static string ProtoExcel = "Proto配置表.xlsx";//输入路径
        public static string GameDBExcel = "游戏数据模型.xlsx";

        public static string dbCMDModule = "数据库操作类.txt";



        public static void Init() {


        }

    }



}
