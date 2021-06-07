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
    /// Interaction logic for StickyNoteTable.xaml
    /// </summary>
    public partial class StickyNoteTable : Window
    {
        public Event _event;
        public event PropertyChangedEventHandler PropertyChanged;
        private EventController eventController = new EventController();
        public StickyNoteTable(Event _event)
        {
            InitializeComponent();
            this.DataContext = this;

            this._event = _event;
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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

        public void refreshTable()
        {
            table.Items.Refresh();
            table.ItemsSource = null;
            table.ItemsSource = _event.StickyNotes;
        }
        private void addStickyNote(object sender, RoutedEventArgs e)
        {
            Window window = new AddStickyNote(_event);
            window.Owner = this;
            window.ShowDialog();
        }

        private void removeStickyNote(object sender, RoutedEventArgs e)
        {
            if (table.SelectedIndex == -1)
            {
                MessageBox.Show("Select some event inside table first !!!");
                return;
            }
            StickyNote s = (StickyNote)table.SelectedItem;
            foreach(StickyNote sticky in _event.StickyNotes)
            {
                if (s.Human_description.Equals(sticky.Human_description))
                {
                    _event.StickyNotes.Remove(sticky);
                    break;
                }
            }
            eventController.EditEvent(_event);
            refreshTable();
        }

        private void editStickyNote(object sender, RoutedEventArgs e)
        {
            if(table.SelectedIndex == -1)
            {
                MessageBox.Show("Select some element first !");
                return;
            }
            StickyNote stickyNoneMatch = new StickyNote();
            foreach (StickyNote stickyNote in _event.StickyNotes)
            {
                StickyNote s = (StickyNote)table.SelectedItem;
                if (s.Human_description.Equals(stickyNote.Human_description))
                {
                    stickyNoneMatch = stickyNote;
                }
                
            }
            Window window = new EditStickyNote(stickyNoneMatch);
            window.Owner = this;
            window.ShowDialog();
        }

        public void editStickyNote(StickyNote stickyNote, String old_humman_desc)
        {
            int br = 0;
            foreach (StickyNote sn in _event.StickyNotes)
            {
                if (sn.Human_description.Equals(old_humman_desc))
                {
                    _event.StickyNotes[br] = stickyNote;
                    break;
                }
                br++;
            }
            eventController.EditEvent(_event);
        }
    }
}
