using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class FileRepository
    {
        private AppSettingService _appSettingService;
        private List<MetadataItem> _exeryMetadataItemInRepository = new List<MetadataItem>();
        private readonly FileNameGenerator _fileNameGenerator;

        public FileRepository()
        {
            _appSettingService = new AppSettingService();
            _fileNameGenerator = new FileNameGenerator();
            LoadMetadataFiles();
        }

        public List<MetadataItem> EveryMetadataItemInRepository { get; set; }

        public void AddFile(MetadataItem metadataItem, bool deleteFile)
        {
            var repositoryDir = new AppSettingService().ReturnRepositoryDir();
            var year = metadataItem._valutaDatum.Value.Year;
            var documentId = metadataItem._guid;
            var extension = Path.GetExtension(metadataItem._filePath);
            var path = metadataItem._filePath;
            var returnFileNameContent = _fileNameGenerator.ReturnFileNameContent(metadataItem._guid, extension);
            var returnFileNameMetadata = _fileNameGenerator.ReturnFileNameMetadata(metadataItem._guid, ".xml");

            var targetDir = Path.Combine(repositoryDir, year.ToString());

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            metadataItem.WriteXml(targetDir, returnFileNameMetadata, metadataItem);

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

        public void LoadMetadataFiles()
        {
            var repositoryDir = new AppSettingService().ReturnRepositoryDir();
            var serialisedMetadataFiles =
                Directory.GetFiles(repositoryDir, "*_Metadata.xml", SearchOption.AllDirectories);
            var metadataItems = new List<MetadataItem>();

            foreach (var streamFile in serialisedMetadataFiles)
            {
                var metadataItem = new MetadataItem();
                var readXml = metadataItem.ReadXml(streamFile);
                metadataItems.Add(readXml);
                EveryMetadataItemInRepository = metadataItems;
            }
        }

        public void OpenSelectedPDF(MetadataItem metadataItem)
        {
            System.Diagnostics.Process.Start(metadataItem._filePath);
        }
    }
}