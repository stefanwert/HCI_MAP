using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HCI_MAP.Controller;
using HCI_MAP.Model;
using Microsoft.Win32;

namespace HCI_MAP.Windows
{
    /// <summary>
    /// Interaction logic for AddTypeOfEvent.xaml
    /// </summary>
    public partial class AddTypeOfEvent : Window
    {
        private TypeOfEventController typeOfEventController = new TypeOfEventController();
        private string picturePath="";
        private Brush brush;
        public AddTypeOfEvent()
        {
            InitializeComponent();
        }

        private void AddTypeOfEventClick(object sender, RoutedEventArgs e)
        {
            TypeOfEvent typeOfEvent = new TypeOfEvent();
            int brError=0;
            if(brush == null)
            {
                brush = Name.Background;
            }
            if(Name.Text.Length == 0)
            {
                Name.Background = Brushes.Red;
                brError++;
            }
            else
            {
                Name.Background = brush;
                typeOfEvent.Name = Name.Text;
            }

            if(Description.Text.Length == 0)
            {
                Description.Background = Brushes.Red;
                brError++;
            }
            else
            {
                Description.Background = brush;
                typeOfEvent.Description = Description.Text;
            }

            if(UniqueMark.Text.Length == 0)
            {
                UniqueMark.Background = Brushes.Red;
                brError++;
            }
            else
            {
                UniqueMark.Background = brush;
                typeOfEvent.Human_description = UniqueMark.Text;
            }

            if(brError > 0)
            {
                return;
            }
            
            typeOfEvent.PicturePath = picturePath;
            if(typeOfEventController.AddTypeOfEvent(typeOfEvent)== null)
            {
                MessageBox.Show("Enter unique mark !");
                return;
            }
            refreshComboBox();
            this.Close();
            if(this.Owner.GetType() == typeof(TypeOfEventTable))
                ((TypeOfEventTable)this.Owner).refreshList();
        }


        private void refreshComboBox()
        {
            if (this.Owner.GetType() == typeof(AddEvent))
            {
                ((AddEvent)this.Owner).refreshCombo();
            }
            else if (this.Owner.GetType() == typeof(EditEvent))
            {
                ((EditEvent)this.Owner).refreshCombo();
            }
        }


        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                string filepath = open.FileName;    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); 
                imgDynamic.Source = imgsource;

                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name, "Resource");
                try
                {
                    File.Copy(filepath, destinationPath, true);
                    
                }
                catch (IOException iox)
                {
                    Console.WriteLine(iox.Message);
                }
                string[] s = filepath.Split("\\");
                picturePath = s[s.Length-1];

            }
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }

        private void btnLoadFromResource_Click(object sender, RoutedEventArgs e)
        {
            Uri resourceUri = new Uri("/Images/white_bengal_tiger.jpg", UriKind.Relative);
            imgDynamic.Source = new BitmapImage(resourceUri);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Owner.Focus();
        }
    }
}
