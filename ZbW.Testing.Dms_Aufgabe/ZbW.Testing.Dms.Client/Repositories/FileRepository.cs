using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Model
{
    class FileRepository
    {
        private AppSettingService _appSettingService;
        private FileNameGenerator _fileNameGenerator;
        private List<MetadataItem> _exeryMetadataItemInRepository = new List<MetadataItem>();

        public FileRepository()
        {           
            this._appSettingService = new AppSettingService();
            this._fileNameGenerator = new FileNameGenerator();
            loadMetadataFiles();
        }

        public List<MetadataItem> EveryMetadataItemInRepository { get; set; }

        public void AddFile(MetadataItem metadataItem, bool deleteFile)
        {
            var repositoryDir = new AppSettingService().ReturnRepositoryDir();
            var year = metadataItem._valutaDatum.Value.Year;
            var documentId = metadataItem._guid;
            var extension = Path.GetExtension(metadataItem._filePath);
            var path = metadataItem._filePath;
            var returnFileNameContent = this._fileNameGenerator.ReturnFileNameContent(metadataItem._guid, extension);
            var returnFileNameMetadata = this._fileNameGenerator.ReturnFileNameMetadata(metadataItem._guid, ".xml");

            var targetDir = Path.Combine(repositoryDir, year.ToString());

            // MetaData
            var xmlSerializer = new XmlSerializer(typeof(MetadataItem));

            if (!Directory.Exists(targetDir))
            {
                {
                    Directory.CreateDirectory(targetDir);
                }

                var streamWriter = new StreamWriter(Path.Combine(targetDir, returnFileNameMetadata));
                xmlSerializer.Serialize(streamWriter, metadataItem);
                streamWriter.Flush();
                streamWriter.Close();

                // move or copy OriginalFile
                File.Copy(metadataItem._filePath, Path.Combine(targetDir, returnFileNameContent));

                if (deleteFile)
                {
                    var task = Task.Factory.StartNew(
                        () =>
                        {
                            Task.Delay(500);
                            File.Delete(metadataItem._filePath);
                        }
                    );

                    try
                    {
                        Task.WaitAll(task);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public void loadMetadataFiles()
        {
            
            var repositoryDir = new AppSettingService().ReturnRepositoryDir();
            var serialisedMetadataFiles = Directory.GetFiles(repositoryDir,"*_Metadata.xml", SearchOption.AllDirectories);
            var metadataItems = new List<MetadataItem>();

            foreach (var streamFile in serialisedMetadataFiles)
            {
                var metadataItem = new MetadataItem();
                var readXml = metadataItem.ReadXml(streamFile);
                metadataItems.Add(readXml);
                this.EveryMetadataItemInRepository = metadataItems;
            }
        }
    }
}
