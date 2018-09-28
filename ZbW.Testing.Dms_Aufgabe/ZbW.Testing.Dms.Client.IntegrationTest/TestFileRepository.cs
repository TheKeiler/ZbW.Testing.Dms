using System.Collections.Generic;
using System.IO;
using FakeItEasy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;

namespace ZbW.Testing.Dms.Client.IntegrationTest

{
    [TestFixture()]
    class TestFileRepository
    {
        [Ignore("Filerepo lässt sich nicht testen")]
        public void FileRepository_AddFiles_WasSuccesfull()
        {
            //Arrange
            var metadataItem = A.Fake<MetadataItem>();
            bool istrue = true;
            var fileRepository = A.Fake<FileRepository>();
            A.CallTo(() => fileRepository.AddFile(metadataItem, istrue)).MustHaveHappened();

            //Act
            fileRepository.AddFile(metadataItem, istrue);

            //Assert
            A.CallTo(() => fileRepository.AddFile(metadataItem, istrue)).MustHaveHappened();
        }

        [Ignore("Filerepo lässt sich nicht testen")]
        public void FileRepository_LoadMetaDataFiles_CreatesValidList()
        {
            //Arrange
            var fileRepository = new FileRepository();

            //Act
            fileRepository.LoadMetadataFiles();

            //Assert
            Assert.That(fileRepository.EveryMetadataItemInRepository.Count , Is.Positive);
        }
    }
}
