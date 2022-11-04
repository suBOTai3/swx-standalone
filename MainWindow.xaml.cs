using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Camman_Drawing_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ProgramProgres
        {
            public int ProgressValue { get; set; }
            public string ProgressDescription { get; set; } = "";
        }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<ProgramProgres>(pp =>
            {
                pbrProgress.Minimum = 1;
                pbrProgress.Maximum = 10;
                pbrProgress.Value = pp.ProgressValue;
                pbrDescription.Content = pp.ProgressDescription;
            });
            ProcessFiles(progress);

        }

        public async void ProcessFiles(IProgress<ProgramProgres> progress)
        {
            // loop 10 times
            for (int i = 1; i <= 10; i++)
            {
                // simulate a long running task
                await Task.Delay(1000);

                // report progress
                progress.Report(new ProgramProgres { ProgressValue = i, ProgressDescription = "Processing file " + i.ToString() });
            }
        }
    }
}
