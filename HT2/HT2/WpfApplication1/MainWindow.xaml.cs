using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {        
            Paths paths = new Paths() { _pathIn = txtBxIn.Text, _pathOut = txtBxOut.Text };

            var thread = new Thread(new ThreadStart(() => paths.CopyFile()));
            thread.Start();
        }
      
        private void OnFindFile(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "File"; // Default file name

            // Show open file dialog box
            bool? result = openFileDialog.ShowDialog();

           if (result == true)
            {
               txtBxIn.Text = openFileDialog.FileName;
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.btnCopy_Click(this,null);
            }
        }
    }
}
