using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CustomExcept;
using Microsoft.Win32;


namespace Simple_PDFifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt1.Text = "Simple PDFifier";
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new DefaultPathException();
                MessageBox.Show("This is a test");
            }
            catch (DefaultPathException ex)
            {
                ex.DisplayError();
            }
        }

        private void processFile(object sender, RoutedEventArgs e)
        {
            string input = inputPath.Text;
            string output = outputPath.Text;

            //Check if both paths are correct
            try
            {
                if (input == "Enter image path here or click Browse")
                {
                    throw new DefaultPathException("You must specify an input path !");
                }
                if (!File.Exists(input))
                {
                    throw new InputFileNonExistent();
                }
                if (!System.IO.Path.IsPathRooted(input))
                {
                    throw new WrongPathException("Input path is invalid !");
                }
            }
            catch (DefaultPathException dpe)
            {
                dpe.DisplayError();
                return;
            }
            catch (InputFileNonExistent ifne)
            {
                ifne.DisplayError();
                return;
            }
            catch (WrongPathException wpe)
            {
                wpe.DisplayError();
                return;
            }
            catch (Exception ex)
            {
                string toDisplay = ex.Message;
                MessageBox.Show(toDisplay, "Error !");
                return;
            }

            try
            {
                if (output == "Enter pdf output path here or click Browse")
                {
                    throw new DefaultPathException("You must specify an output path !");
                }
                if (!System.IO.Path.IsPathRooted(output))
                {
                    throw new WrongPathException("Output path is invalid !");
                }
                if (!output.EndsWith(".pdf"))
                {
                    throw new WrongFormatException("Ouput file must end with .pdf. Please change file extension and try again");
                }
                string outputDir = System.IO.Path.GetDirectoryName(output);
                Directory.CreateDirectory(outputDir);
            }
            catch (DefaultPathException dpe)
            {
                dpe.DisplayError();
                return;
            }
            catch (WrongPathException wpe)
            {
                wpe.DisplayError();
                return;
            }
            catch (WrongFormatException wfe)
            {
                wfe.DisplayError();
                return;
            }
            catch (Exception ex)
            {
                string toDisplay = ex.Message;
                MessageBox.Show(toDisplay, "Error !");
                return;
            }
            Converter.pdfify(input, output);


        }

        private void showMessage(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Ceci est un message !", "Important", MessageBoxButton.YesNo);
            if (answer != MessageBoxResult.Yes)
            {
                MessageBox.Show("Si, ceci était bien un message. Ca aussi d'ailleurs.", "Débile", MessageBoxButton.OK);
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WIP");
        }

        private void exitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private string getPath()
        {
            OpenFileDialog selector = new OpenFileDialog();
            if (selector.ShowDialog() == true)
            {
                return selector.FileName;
            }
            else
            {
                return "NULL_VALUE";
            }
        }
        private void browseInput(object sender, RoutedEventArgs e)
        {
            string newPath = getPath();
            if (newPath != "NULL_VALUE")
            {
                inputPath.Text = newPath;
            }
        }
        private void browseOutput(object sender, RoutedEventArgs e)
        {
            SaveFileDialog selector = new SaveFileDialog();
            selector.AddExtension = true;
            selector.DefaultExt = ".pdf";
            if (selector.ShowDialog() == true)
            {
                outputPath.Text = selector.FileName;
            }
        }

        private void showAbout(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }

        private void showRepo(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Edern76/Simple-PDFifier");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
