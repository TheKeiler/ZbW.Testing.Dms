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
    class TestFileNameGenerator
    {
        [Test]
        public void NewFileNameContent_Generate_ReturnsValidFileName()
        {
            //Arrange
            var fileNameGenerator = new FileNameGenerator();
            // Fake String GUID and extension
            var guid = "3e911311-f1de-4279-9fed-a8a1a270845c";
            var extension = ".pdf";

            //Act
            var validFileNameExpected = fileNameGenerator.ReturnFileNameContent(guid, extension);

            //Assert
            Assert.That(validFileNameExpected, Is.EqualTo("3e911311-f1de-4279-9fed-a8a1a270845c_Content.pdf"));
        }

        [Test]
        public void NewFileNameMetadata_Generate_ReturnsValidFileName()
        {
            //Arrange
            var fileNameGenerator = new FileNameGenerator();
            // Fake String GUID and extension
            var guid = "3e911311-f1de-4279-9fed-a8a1a270845c";
            var extension = ".xml";

            //Act
            var validFileNameExpected = fileNameGenerator.ReturnFileNameMetadata(guid, extension);

            //Assert
            Assert.That(validFileNameExpected, Is.EqualTo("3e911311-f1de-4279-9fed-a8a1a270845c_Metadata.xml"));
        }
    }
}