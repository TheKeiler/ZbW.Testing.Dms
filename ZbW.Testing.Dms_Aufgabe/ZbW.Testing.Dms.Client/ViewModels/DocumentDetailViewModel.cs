﻿using System.Windows;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Repositories;

    public class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        private FileRepository _fileRepository;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;
            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
            _fileRepository = new FileRepository();
        }

        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
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

        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }


        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }

        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            // TODO: Add your Code here
            var metadataItem = new MetadataItem(this);
            this._fileRepository.AddFile(metadataItem, metadataItem._isRemoveFileEnabled);
            MessageBox.Show("Speichern erfolgreich. Bitte nächstes Element einlesen.");
        }
    }
}