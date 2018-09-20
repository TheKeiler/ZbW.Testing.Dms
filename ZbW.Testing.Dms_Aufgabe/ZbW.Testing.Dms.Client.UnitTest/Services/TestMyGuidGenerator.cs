using NUnit.Framework;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTest.Services
{
    [TestFixture]
    class TestMyGuidGenerator
    {
        [Test]
        public void NewGuid_returns_ValidGuid()
        {
            // arrange
            var myGuidGenerator = new MyGuidGenerator();

            // act
            var guid = myGuidGenerator.ReturnNewGuid();

            // Assert
            Assert.That(guid.Length==36, Is.True);
        }
    }
}
