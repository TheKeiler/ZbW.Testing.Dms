using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        private FileRepository _fileRepository;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            _fileRepository=new FileRepository();
            _filteredMetadataItems = _fileRepository.EveryMetadataItemInRepository;
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            if(OnCanCmdOeffnen())

            _fileRepository.OpenSelectedPDF(SelectedMetadataItem);
        }

        private void OnCmdSuchen()
        {
            // TODO: Add your Code here
            if (string.IsNullOrEmpty(_selectedTypItem) && string.IsNullOrEmpty(_suchbegriff))
            {
                MessageBox.Show("Bitte wählen Sie einen Dokumententyp oder schreiben Sie einen Suchbegriff.");
            }
            else
            {
                _fileRepository.SearchFiles(SelectedTypItem, Suchbegriff);
                FilteredMetadataItems = _fileRepository.FilteredMetadataItems;
            }
        }

        private void OnCmdReset()
        {
            _fileRepository.LoadMetadataFiles();
            FilteredMetadataItems = _fileRepository.EveryMetadataItemInRepository;
            SelectedTypItem = null;
        }
    }
}