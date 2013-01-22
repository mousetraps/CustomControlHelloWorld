using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace CustomControlHelloWorld
{
    /// <summary>
    /// Interaction logic for OpenFileButton.xaml
    /// </summary>
    public partial class OpenFileButton : Button
    {
        public static readonly DependencyProperty SelectedFileNameProperty =
            DependencyProperty.Register("SelectedFileName", typeof (string), typeof (OpenFileButton),
                                        new UIPropertyMetadata(string.Empty));

        public OpenFileButton()
            : base()
        {
            this.Click += BtnOpenFile_OnClick;
        }
        
        public string SelectedFileName
        {
            get { return (string) GetValue(SelectedFileNameProperty); }
            set { SetValue(SelectedFileNameProperty, value);}
        }

        private void BtnOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog().Value)
            {
                SelectedFileName = openFileDialog.FileName;
            }
        }
    }
}

