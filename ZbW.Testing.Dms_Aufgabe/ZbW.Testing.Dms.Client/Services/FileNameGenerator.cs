using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class FileNameGenerator
    {

        public FileNameGenerator()
        {
        }

        public string ReturnFileNameContent(string guid, string extension)
        {
            return guid + "_Content" + extension;
        }

        public string ReturnFileNameMetadata(string guid, string extension)
        {
            return guid + "_Metadata" + extension;
        }
    }
}
