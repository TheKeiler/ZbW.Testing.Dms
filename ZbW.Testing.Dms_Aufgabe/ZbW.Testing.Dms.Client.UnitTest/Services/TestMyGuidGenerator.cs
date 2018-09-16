using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTest.Services
{
    class TestMyGuidGenerator
    {
        [Test]
        public void NewGuid_returns_ValidGuid()
        {
            // arrange
            var myGuidGenerator = A.Fake<MyGuidGenerator>();

            // act
            var guid = myGuidGenerator.ReturnNewGuid();

            // Assert
            Assert.That(guid.Length==36, Is.True);
        }
    }
}
