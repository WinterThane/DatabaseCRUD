namespace DatabaseCRUD.ViewModels
{
    public class InfoOutputViewModel : ViewModelBase
    {
        private string? _infoRollingText;
        public string? InfoRollingText
        {
            get => _infoRollingText;
            set
            {
                _infoRollingText = value;
                OnPropertyChanged(nameof(InfoRollingText));
            }
        }
    }
}
