using System;

namespace ZbW.Testing.Dms.Client.Services
{
    public class MyGuidGenerator
    {
        public string ReturnNewGuid()
        {
            var newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
    }
}