using HCI_MAP.Controller;
using HCI_MAP.Model;
using HCI_MAP.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for TypeOfEventTable.xaml
    /// </summary>
    public partial class TypeOfEventTable : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public TypeOfEventController typeOfEventController = new TypeOfEventController();
        public List<TypeOfEvent> typeOfEvents = new List<TypeOfEvent>();
        public TypeOfEventTable()
        {
            InitializeComponent();
            this.DataContext = this;
            typeOfEvents.AddRange(typeOfEventController.GetAllTypeOfEvent());
        }

        public List<TypeOfEvent> TypeOfEvents
        {
            get
            {
                return typeOfEvents;
            }
            set
            {
                if (value != typeOfEvents)
                {
                    typeOfEvents = value;
                    OnPropertyChanged("Events");
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
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            Window window = new AddTypeOfEvent();
            window.Owner = this;
            window.Show();
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some type of event inside table first !!!");
                return;
            }
            foreach (TypeOfEvent ev in typeOfEventController.GetAllTypeOfEvent())
            {
                if (ev.Id.Equals(((TypeOfEvent)table.SelectedItem).Id))
                {
                    Window window = new EditTypeOfEvent(ev);
                    window.Owner = this;
                    window.Show();
                }
            }
            
        }

        private void removeEvent(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some type of event inside table first !!!");
                return;
            }
            foreach (TypeOfEvent ev in typeOfEventController.GetAllTypeOfEvent())
            {
                if (ev.Id.Equals(((TypeOfEvent)table.SelectedItem).Id))
                {
                    typeOfEventController.RemoveTypeOfEvent(ev);
                    refreshList();
                    refreshList();
                    break;
                }
            }
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
            Window w = new MainWindow();
            w.Show();
            this.Close();
        }
        private void ShowTypeOfEventTable(object sender, RoutedEventArgs e)
        {
            //Window w = new TypeOfEventTable();
            //w.Show();
            //this.Close();
        }

        private void ShowMap(object sender, RoutedEventArgs e)
        {
            Window w = new Map();
            w.Show();
            this.Close();
        }

        public void refreshList()
        {
            TypeOfEvents.Clear();
            TypeOfEvents.AddRange(typeOfEventController.GetAllTypeOfEvent());
            table.Items.Refresh();
        }

        private void ChangeTheme_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ChangeTheme_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ThemesController.CurrentTheme == ThemesController.ThemeTypes.Dark)
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
            e.CanExecute = true;
        }

        private void Events_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
            this.Close();
        }

        private void TypeOfEvents_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        private void TypeOfEvents_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window w = new TypeOfEventTable();
            w.Show();
            this.Close();
        }

        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window window = new AddTypeOfEvent();
            window.Owner = this;
            window.Show();
        }

        private void Edit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some type of event inside table first !!!");
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (TypeOfEvent ev in typeOfEventController.GetAllTypeOfEvent())
            {
                if (ev.Id.Equals(((TypeOfEvent)table.SelectedItem).Id))
                {
                    Window window = new EditTypeOfEvent(ev);
                    window.Owner = this;
                    window.Show();
                }
            }
        }

        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (table.SelectedItem == null)
            {
                MessageBox.Show("Select some type of event inside table first !!!");
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (TypeOfEvent ev in typeOfEventController.GetAllTypeOfEvent())
            {
                if (ev.Id.Equals(((TypeOfEvent)table.SelectedItem).Id))
                {
                    typeOfEventController.RemoveTypeOfEvent(ev);
                    refreshList();
                    refreshList();
                    break;
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Help();
            w.ShowDialog();
        }
    }
}
