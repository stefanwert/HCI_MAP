using HCI_MAP.Controller;
using HCI_MAP.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCI_MAP.Windows
{
    /// <summary>
    /// Interaction logic for EditTypeOfEvent.xaml
    /// </summary>
    public partial class EditTypeOfEvent : Window
    {
        private TypeOfEvent typeOfEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        private string picturePath = "";
        private TypeOfEventController typeOfEventController = new TypeOfEventController();
        public TypeOfEvent TypeOfEvent
        {
            get
            {
                return typeOfEvent;
            }
            set
            {
                if (value != typeOfEvent)
                {
                    typeOfEvent = value;
                    OnPropertyChanged("Event");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public EditTypeOfEvent(TypeOfEvent TOfE)
        {
            InitializeComponent();
            this.DataContext = this;
            loadImg(TOfE);

            typeOfEvent = TOfE;
        }

        private void loadImg(TypeOfEvent TOfE)
        {
            picturePath = TOfE.PicturePath;
            if (isThereAPic())
            {
                var path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path += "\\Resource\\" + TOfE.PicturePath;
                ImageSource imgsource = new BitmapImage(new Uri(path));
                imgDynamic.Source = imgsource;
            }
        }

        private bool isThereAPic()
        {
            return !picturePath.Equals("");
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            TypeOfEvent.PicturePath = picturePath;
            typeOfEventController.EditTypeOfEvent(TypeOfEvent);
            this.Close();
            ((TypeOfEventTable)this.Owner).refreshList();
        }

        private void btnLoadFromFile_Click(object sender, RoutedEventArgs e)
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
                picturePath = s[s.Length - 1];

            }
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Owner.Focus();
        }
    }
}
