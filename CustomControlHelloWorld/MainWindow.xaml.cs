using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CustomControlHelloWorld.Annotations;

namespace CustomControlHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectedFile = "No file selected";
        }

    }

    public class ViewModel : INotifyPropertyChanged
    {
        private string _selectedFile;
        public string SelectedFile
        {
            get { return _selectedFile; }
            set {
                _selectedFile = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
