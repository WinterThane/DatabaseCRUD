using DatabaseCRUD.CoreClasses;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace DatabaseCRUD.ViewModels
{
    public class DatabaseConnectionViewModel : ViewModelBase
    {
        public ICommand? SearchFileCommand { get; private set; }
        public ICommand? ConnectCommand { get; private set; }
        public ICommand? CreateDBCommand { get; private set; }
        public string? FullFilename { get; set; }

        private string? _connectionString;
        public string? ConnectionString 
        {
            get => _connectionString;
            set
            {
                _connectionString = value;
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        public DatabaseConnectionViewModel()
        {
            SearchFileCommand = new RelayCommand(ExecuteSearchFileCommand);
            ConnectCommand = new RelayCommand(ExecuteConnectCommand);
            CreateDBCommand = new RelayCommand(ExecuteCreateDBCommand);
        }

        private void ExecuteSearchFileCommand()
        {
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                FullFilename = dialog.FileName;
                ConnectionString = FullFilename;
            }
        }

        private void ExecuteConnectCommand()
        {
            if (ConnectionString == null) 
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
                catch (System.Exception ex)
                {

                }
            }
        }

        public void ExecuteCreateDBCommand()
        {
            MessageBox.Show("create");
        }
    }
}
