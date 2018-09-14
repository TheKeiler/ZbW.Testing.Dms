using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class AppSettingService
    {
        public string ReturnRepositoryDir()
        {
            var value = ConfigurationManager.AppSettings["RepositoryDir"];
            return value;
        }
    }
}
