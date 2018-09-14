using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem : System.Xml.Serialization.IXmlSerializable
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

        public void ReadXml(XmlReader reader)
        {
            _guid = reader.ReadElementContentAsString(_guid, "");
            _benutzer = reader.ReadElementContentAsString(_benutzer, "");
            _bezeichnung = reader.ReadElementContentAsString(_bezeichnung, "");
            reader.ReadToFollowing("_erfassungsdatum");
            DateTime erfassungsDatum = reader.ReadElementContentAsDateTime();
            _erfassungsdatum = erfassungsDatum;
            _filePath = reader.ReadElementContentAsString(_filePath, "");
            _isRemoveFileEnabled = reader.ReadElementContentAsBoolean(_bezeichnung, "");
            _stichwoerter = reader.ReadElementContentAsString(_stichwoerter, "");
            _selectedTypItem = reader.ReadElementContentAsString(_selectedTypItem, "");
            reader.ReadToFollowing("_valutaDatum");
            DateTime valutaDatum = reader.ReadElementContentAsDateTime();
            _valutaDatum = valutaDatum;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("_guid" ,this._guid);
            writer.WriteElementString("_benutzer",this._benutzer);
            writer.WriteElementString("_bezeichnung",this._bezeichnung);
            writer.WriteElementString("_erfassungsdatum",this._erfassungsdatum.ToString());
            writer.WriteElementString("_filepath",this._filePath);
            writer.WriteElementString("_isRemoveFileEnabled",_isRemoveFileEnabled.ToString());
            writer.WriteElementString("_stichwoerter",this._stichwoerter);
            writer.WriteElementString("_selectedTypeItem",this._selectedTypItem.ToString());
            writer.WriteElementString("_valutaDatum",this._valutaDatum.ToString());
        }
    }
}