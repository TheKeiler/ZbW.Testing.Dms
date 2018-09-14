using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    class IXmlSerializer : XmlSerializer
    {
        public IXmlSerializer(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
