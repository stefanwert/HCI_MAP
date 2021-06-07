using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using HCI_MAP.help;
using HCI_MAP.Model;

namespace HCI_MAP.Windows
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private EventController eventController = new EventController();
        private TypeOfEventController typeOfEventController = new TypeOfEventController();
        public event PropertyChangedEventHandler PropertyChanged;
        private List<TypeOfEvent> typeOfEventList = new List<TypeOfEvent>();
        BrushConverter brushConverter = new BrushConverter();
        private Brush brush = Application.Current.Resources["ContainerBackground"] as Brush;

        public List<TypeOfEvent> TypeOfEventList
        {
            get
            {
                return typeOfEventList;
            }
            set
            {
                if (value != typeOfEventList)
                {
                    typeOfEventList = value;
                    OnPropertyChanged("TypeOfEventList");
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
        public AddEvent()
        {
            InitializeComponent();
            this.DataContext = this;

            AttendanceComboBox();
            TypeOfEventList.AddRange(typeOfEventController.GetAllTypeOfEvent());
            comboTypeOfEvent.Items.Refresh();

        }

        private void AttendanceComboBox()
        {
            foreach (Attendance attendance in Enum.GetValues(typeof(Attendance)))
            {
                combo.Items.Add(attendance.ToString().Substring(5));
            }
            combo.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Event _event = new Event();

            int br = 0;
            br += getSelectedAttendence(_event);
            br += getSelectedTypeOfEvent(_event);
            br += getDate(_event);
            addSelectedDates(_event);

            br = validateOtherTextBoxs(_event, br);
            if (br > 0)
            {
                return;
            }
            if (eventController.addEvent(_event) == null)
            {
                MessageBox.Show("Enter unique mark!");
                return;
            }
            this.Close();
            ((MainWindow)this.Owner).refreshList();
            // TODO: proveri da li je selektovan datum i da li je sve uneto 
        }

        private int getDate(Event _event)
        {
            if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("Select some date !");
                return 1;
            }
            //to do 
            _event.Date = datePicker.SelectedDate.Value;
            return 0;
        }

        private int validateOtherTextBoxs(Event _event, int br)
        {
            if (Name.Text.Length == 0)
            {
                Name.Background = Brushes.Red;
                br++;
            }
            else
            {
                Name.Background = brush;
                _event.Name = Name.Text;
            }

            if (Description.Text.Length == 0)
            {
                Description.Background = Brushes.Red;
                br++;
            }
            else
            {
                Description.Background = brush;
                _event.Description = Description.Text;
            }

            if (Human_description.Text.Length == 0)
            {
                Human_description.Background = Brushes.Red;
                br++;
            }
            else
            {
                Human_description.Background = brush;
                _event.Human_description = Human_description.Text;
            }

            if (price.Text.Length == 0)
            {
                price.Background = Brushes.Red;
                br++;
            }
            else
            {
                price.Background = brush;
                _event.Price = Double.Parse(price.Text);
            }

            if (country.Text.Length == 0)
            {
                country.Background = Brushes.Red;
                br++;
            }
            else
            {
                country.Background = brush;
                _event.Country = country.Text;
            }

            if (city.Text.Length == 0)
            {
                city.Background = Brushes.Red;
                br++;
            }
            else
            {
                city.Background = brush;
                _event.City = city.Text;
            }

            if (place.Text.Length == 0)
            {
                place.Background = Brushes.Red;
                br++;
            }
            else
            {
                place.Background = brush;
                _event.Place = place.Text;
            }

            return br;
        }

        private int getSelectedTypeOfEvent(Event _event)
        {
            if(comboTypeOfEvent.SelectedItem == null)
            {
                MessageBox.Show("Select some type of event !");
                return 1;
            }
            foreach (TypeOfEvent typeOfEvent in TypeOfEventList)
            {
                string str = ((TypeOfEvent)comboTypeOfEvent.SelectedItem).Name.ToString();
                if (str.Equals(typeOfEvent.Name))
                {
                    _event.TypeOfEventId = typeOfEvent.Id;
                    break;
                }
            }
            return 0;
        }

        private int getSelectedAttendence(Event _event)
        {
            if (combo.SelectedItem == null)
            {
                MessageBox.Show("Select some attendance !");
                return 1;
            }
            foreach (Attendance attendance in Enum.GetValues(typeof(Attendance)))
            {
                string str = "Enum_" + combo.SelectedItem.ToString();
                if (str.Equals(attendance.ToString()))
                {
                    _event.Attendance = attendance;
                    break;
                }
            }
            return 0;
        }

        private void addSelectedDates(Event _event)
        {
            foreach (DateTime d in cldSample.SelectedDates)
            {
                _event.DateTimes.Add(d);
            }
        }

        private void price_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                double br = Double.Parse(price.Text);
            }
            catch(Exception ex)
            {
                price.Text = "";
                MessageBox.Show("Price must be a number !");
            }
            
        }

        public void refreshCombo()
        {
            TypeOfEventList.Clear();
            TypeOfEventList.AddRange(typeOfEventController.GetAllTypeOfEvent());
            comboTypeOfEvent.SelectedIndex = -1;
            comboTypeOfEvent.Items.Refresh();
        }
        private void AddTypeOfEvent(object sender, RoutedEventArgs e)
        {
            Window window = new AddTypeOfEvent();
            window.Owner = this;
            window.ShowDialog();
        }
    }
    
}
