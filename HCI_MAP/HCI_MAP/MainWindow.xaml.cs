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
using HCI_MAP.Windows;
using HCI_MAP.Model;
using HCI_MAP.Controller;
using System.ComponentModel;
using HCI_MAP.Themes;
using System.Globalization;
using HCI_MAP.help;

namespace HCI_MAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventController eventController = new EventController();
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Event> events { get; set; }
        public static bool isFirstTime = false;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<Event> Events
        {
            get
            {
                return events;
            }
            set
            {
                if (value != events)
                {
                    events = value;
                    OnPropertyChanged("Events");
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            setLanguage();
            if (!isFirstTime)
            {
                App.Instance.SwitchLanguage("as-US");
                App.Instance.SwitchLanguage("en-US");
                isFirstTime = true;
            }
            events = eventController.GetAllEvents();
        }

        private void setLanguage()
        {
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(CultureInfo.CurrentUICulture.Name))
                    item.IsChecked = true;
            }
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            Window window = new AddEvent();
            window.Owner = this;
            window.ShowDialog();
        }

        public void refreshList()
        {
            Events.Clear(); 
            Events.AddRange(eventController.GetAllEvents());
            table.Items.Refresh();
        }

        private void removeEvent(object sender, RoutedEventArgs e)
        {
            if(table.SelectedItem == null)
            {
                MessageBox.Show("Select some event inside table first !!!");
                return;
            }
            foreach (Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    eventController.RemoveEvent(ev);
                    refreshList();
                    break;
                }
            }
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            if (table.SelectedIndex == -1)
            {
                MessageBox.Show("Select some event inside table first !!!");
                return;
            }
            foreach (Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    //Window window = new EditEvent(ev);
                    Window window = new EditEvent(ev);
                    window.Owner = this;
                    window.ShowDialog();
                    break;
                }
            }
        }

        private void showStickyNotes(object sender, RoutedEventArgs e)
        {
            if (table.SelectedIndex == -1)
            {
                MessageBox.Show("Select some event inside table first !!!");
                return;
            }

            foreach(Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    Window window = new StickyNoteTable(ev);
                    window.Owner = this;
                    window.ShowDialog();
                }
            }
        }

        private void openMap(object sender, RoutedEventArgs e)
        {
            Window w = new Map();
            w.Show();
            this.Close();
        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            refreshList();
            if(searchTextBox.Text.Length == 0)
            {
                return;
            }
            string textBox = searchTextBox.Text;//.Replace(" ", "");
            string[] conditions = textBox.Split(",");
            List<Event> eventTemp = new List<Event>();
            eventTemp.AddRange(events);
            foreach (string s in conditions)
            {
                string[] s2 = s.Split(":");
                if(s2.Length != 2)
                {
                    break;
                }
                switch (s2[0].ToLower())
                {
                    case "id":
                        foreach(Event ev in events)
                        {
                            if(!ev.Id.ToString().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "name":
                    case "ime":
                        foreach (Event ev in events)
                        {
                            if (!ev.Name.ToLower().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "price":
                    case "cena":
                        foreach (Event ev in events)
                        {
                            if (!ev.Price.ToString().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "country":
                    case "zemlja":
                        foreach (Event ev in events)
                        {
                            if (!ev.Country.ToLower().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "city":
                    case "grad":
                        foreach (Event ev in events)
                        {
                            if (!ev.City.ToLower().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "place":
                    case "mesto":
                        foreach (Event ev in events)
                        {
                            if (!ev.Place.ToLower().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                    case "description":
                    case "opis":
                        foreach (Event ev in events)
                        {
                            if (!ev.Description.ToLower().Equals(s2[1]))
                            {
                                eventTemp.Remove(ev);
                            }
                        }
                        break;
                }
            }
            Events.Clear();
            Events.AddRange(eventTemp);
            table.Items.Refresh();
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((MenuItem)sender).Uid))
            {
                case 0: ThemesController.SetTheme(ThemesController.ThemeTypes.Light); break;
                case 1: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulLight); break;
                case 2: ThemesController.SetTheme(ThemesController.ThemeTypes.Dark); break;
                case 3: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulDark); break;
            }
            e.Handled = true;
        }
        private void MenuItem_language_change(object sender, RoutedEventArgs e)
        {
            // Uncheck each item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                item.IsChecked = false;
            }

            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            App.Instance.SwitchLanguage(mi.Tag.ToString());
        }

        private void ShowEventTable(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowTypeOfEventTable(object sender, RoutedEventArgs e)
        {
            Window w = new TypeOfEventTable();
            w.Show();
            this.Close();
        }

        private void ShowMap(object sender, RoutedEventArgs e)
        {
            Window w = new Map();
            w.Show();
            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            refreshList();
        }

        private void addEvent_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window window = new AddEvent();
            window.Owner = this;
            window.ShowDialog();
        }

        private void addEvent_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void editEvent_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (table.SelectedIndex == -1)
            {
                MessageBox.Show("Select some event inside table first !!!");
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void editEvent_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    //Window window = new EditEvent(ev);
                    Window window = new EditEvent(ev);
                    window.Owner = this;
                    window.ShowDialog();
                    break;
                }
            }
        }

        private void deleteEvent_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some event inside table first !!!");
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void deleteEvent_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    eventController.RemoveEvent(ev);
                    refreshList();
                    break;
                }
            }
        }

        private void goToMap_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void goToMap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new Map();
            w.Show();
            this.Close();
        }

        private void showStickyNotes_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some event inside table first !!!");
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void showStickyNotes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (Event ev in eventController.GetAllEvents())
            {
                if (ev.Id.Equals(((Event)table.SelectedItem).Id))
                {
                    Window window = new StickyNoteTable(ev);
                    window.Owner = this;
                    window.ShowDialog();
                }
            }
        }

        private void ChangeTheme_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ChangeTheme_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(ThemesController.CurrentTheme == ThemesController.ThemeTypes.Dark)
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            }
            else
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            }
        }

        private void Lenguage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Lenguage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                App.Instance.SwitchLanguage("SRB");
            }
            else
            {
                App.Instance.SwitchLanguage("en-US");
            }
        }

        private void GoToMap_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void GoToMap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new Map();
            w.Show();
            this.Close();
        }

        private void Events_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        private void Events_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
            this.Close();
        }

        private void TypeOfEvents_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TypeOfEvents_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new TypeOfEventTable();
            w.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Help();
            w.ShowDialog();
        }
    }
}
