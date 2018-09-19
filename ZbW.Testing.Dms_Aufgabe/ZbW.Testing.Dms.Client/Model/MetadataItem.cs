using System;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Model
{
    
    public class MetadataItem 
    {
        // Falls aus dem XML gelesen wird
        public MetadataItem()
        {

        }

        //Falls gespeichert werden möchte
        public MetadataItem(DocumentDetailViewModel model)
        {
            this._guid = new MyGuidGenerator().ReturnNewGuid();
            this._benutzer = model.Benutzer;
            this._bezeichnung = model.Bezeichnung;
            this._erfassungsdatum = model.Erfassungsdatum;
            this._filePath = model.FilePath;
            this._isRemoveFileEnabled = model.IsRemoveFileEnabled;
            this._selectedTypItem = model.SelectedTypItem;
            this._stichwoerter = model.Stichwoerter;
            this._valutaDatum = model.ValutaDatum;

        }
        // TODO: Write your Metadata properties here

        public string _guid { get; set; }

        public string _benutzer { get; set; }

        public string _bezeichnung { get; set; }

        public DateTime _erfassungsdatum { get; set; }

        public string _filePath { get; set; }

        public bool _isRemoveFileEnabled { get; set; }

        public string _selectedTypItem { get; set; }

        public string _stichwoerter { get; set; }

        public DateTime? _valutaDatum { get; set; }


        public XmlSchema GetSchema()
        {
            return (null);
        }

        public MetadataItem ReadXml(string streamFile)
        {
            var xml_Serializer = new XmlSerializer(typeof(MetadataItem));
            var streamReader = new StreamReader(streamFile);
            var metadataItem = (MetadataItem)xml_Serializer.Deserialize(streamReader);
            if (metadataItem == null)
            {
                throw new Exception("Das hat nicht geklappt..");
            }
            return metadataItem;
        }

    }
}