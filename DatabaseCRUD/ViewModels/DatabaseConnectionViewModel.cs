using DatabaseCRUD.CoreClasses;
using DatabaseCRUD.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DatabaseCRUD.ViewModels
{
    public class DatabaseConnectionViewModel : ViewModelBase
    {
        public ICommand? SearchFileCommand { get; private set; }
        public ICommand? ConnectCommand { get; private set; }
        public ICommand? CreateDBCommand { get; private set; }
        public string? InfoTextDatabase { get; set; }

        private string? _databaseLocation;
        public string? DatabaseLocation 
        {
            get => _databaseLocation;
            set
            {
                _databaseLocation = value;
                OnPropertyChanged(nameof(DatabaseLocation));
            }
        }

        private string? _databaseNewName;
        public string? DatabaseNewName
        {
            get => _databaseNewName;
            set
            {
                _databaseNewName = value;
                OnPropertyChanged(nameof(DatabaseNewName));
            }
        }

        public DatabaseConnectionViewModel()
        {
            InfoText.ListOfTextRows = new List<string>();
            SearchFileCommand = new RelayCommand(ExecuteSearchFileCommand);
            ConnectCommand = new RelayCommand(ExecuteConnectCommand);
            CreateDBCommand = new RelayCommand(ExecuteCreateDBCommand);
        }

        private void ExecuteSearchFileCommand()
        {
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                DatabaseLocation = dialog.FileName;
            }
        }

        private void ExecuteConnectCommand()
        {
            if (DatabaseLocation == null) 
            {
                MessageBox.Show("missing connection string");
            }   
            else
            {
                try
                {
                    MessageBox.Show("connecting");
                    MessageBox.Show("connected");
                }
                catch (Exception ex)
                {
                    Logger.Log($"Failed to connect to a database. Name: {DatabaseLocation}", ex, Logger.ErrorType.CRITICAL);
                }
            }
        }

        public void ExecuteCreateDBCommand()
        {
            if (!string.IsNullOrEmpty(DatabaseNewName))
            {
                try
                {
                    DatabaseFunctions.CreateDatabase(DatabaseNewName);
                    Logger.Log($"New database created. Name: {DatabaseNewName}", Logger.ErrorType.INFO);
                    InfoTextDatabase = InfoText.InfoTextResult($"New database created. Name: {DatabaseNewName}");
                }
                catch (Exception ex)
                {
                    Logger.Log($"Failed to create a new database. Name: {DatabaseNewName}", ex, Logger.ErrorType.CRITICAL);
                }                
            }
            else
            {
                Logger.Log($"Failed to provide a new database name.", Logger.ErrorType.INFO);
                MessageBox.Show("Missing Database name.");
            }
        }
    }
}
