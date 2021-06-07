using HCI_MAP.Controller;
using HCI_MAP.Model;
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

namespace HCI_MAP.Windows
{
    /// <summary>
    /// Interaction logic for EditEvent2.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        private Event _event;
        public event PropertyChangedEventHandler PropertyChanged;
        private TypeOfEventController typeOfEventController = new TypeOfEventController();
        private EventController eventController = new EventController();
        private List<TypeOfEvent> typeOfEventList = new List<TypeOfEvent>();
        Brush brush = Application.Current.Resources["ContainerBackground"] as Brush;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
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
        public EditEvent(Event _event)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Event = _event;

            AttendanceComboBox();
            TypeOfEventComboBox();
            datePicker.SelectedDate = Event.Date;
        }

        private void TypeOfEventComboBox()
        {
            TypeOfEventList.AddRange(typeOfEventController.GetAllTypeOfEvent());
            int br = 0;
            TypeOfEvent typeOfEventProm = typeOfEventController.getById(Event.TypeOfEventId);
            if (typeOfEventProm != null)
            {
                foreach (TypeOfEvent typeOfEvent in TypeOfEventList)
                {
                    if (typeOfEvent.Name.Equals(typeOfEventProm.Name))
                    {
                        comboTypeOfEvent.SelectedIndex = br;
                        break;
                    }
                    br++;
                }
            }
            comboTypeOfEvent.Items.Refresh();

        }

        public Event Event
        {
            get
            {
                return _event;
            }
            set
            {
                if (value != _event)
                {
                    _event = value;
                    OnPropertyChanged("Event");
                }
            }
        }

        private void AttendanceComboBox()
        {
            int br = 0;
            foreach (Attendance attendance in Enum.GetValues(typeof(Attendance)))
            {
                combo.Items.Add(attendance.ToString().Substring(5));
                if (attendance == Event.Attendance)
                {
                    combo.SelectedIndex = br;
                }
                br++;
            }
            combo.Items.Refresh();
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
        private int getSelectedTypeOfEvent(Event _event)
        {
            if (comboTypeOfEvent.SelectedItem == null)
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



        private void editClick(object sender, RoutedEventArgs e)
        {
            int br = 0;
            br += getSelectedAttendence(_event);
            br += getSelectedTypeOfEvent(_event);
            //date
            br = validateOtherTextBoxs(br);
            br = validateDatePicker(br);
            if (br > 0)
            {
                return;
            }

            eventController.EditEvent(_event);
            ((MainWindow)this.Owner).refreshList();
            this.Close();
        }

        private int validateDatePicker(int br)
        {
            if (datePicker.SelectedDate == null)
            {
                br++;
            }
            else
            {
                Event.Date = datePicker.SelectedDate.Value;
            }

            return br;
        }

        private int validateOtherTextBoxs(int br)
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

        public void refreshCombo()
        {
            TypeOfEventList.Clear();
            TypeOfEventComboBox();
        }

        private void price_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                double br = Double.Parse(price.Text);
            }
            catch (Exception ex)
            {
                price.Text = "";
                MessageBox.Show("Price must be a number !");
            }
        }

        private void AddTypeOfEvent(object sender, RoutedEventArgs e)
        {
            Window window = new AddTypeOfEvent();
            window.Owner = this;
            window.ShowDialog();
        }

        private void removeSelectedDate(object sender, RoutedEventArgs e)
        {
            if (listBoxOfDates.SelectedIndex == -1)
            {
                MessageBox.Show("Select date from listbox !");
                return;
            }
            Event.DateTimes.RemoveAt(listBoxOfDates.SelectedIndex);
            listBoxOfDates.Items.Refresh();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
            {
                return;
            }
            Event.DateTimes.Add(datePicker.SelectedDate.Value);
            datePicker.SelectedDate = null;
            listBoxOfDates.Items.Refresh();
        }
    }
}
