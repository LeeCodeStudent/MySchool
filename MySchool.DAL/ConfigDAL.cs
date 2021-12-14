using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL
{
    public class ConfigDAL
    {
        public static DBConfigModel GetDBConfig()
        {
            XMLDAL xml = new XMLDAL(Environment.CurrentDirectory + "\\Config\\DBConfig.xml", "root");
            xml.LoadXml();
            IList<DBConfigModel> configs = xml.GetChildNodeInner<DBConfigModel>("DBConfig");
            return configs[0];
        }
    }
}
