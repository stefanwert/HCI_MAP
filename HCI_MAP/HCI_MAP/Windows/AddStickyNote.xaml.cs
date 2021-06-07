using HCI_MAP.Controller;
using HCI_MAP.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddStickyNote.xaml
    /// </summary>
    public partial class AddStickyNote : Window
    {
        private Event _event;
        EventController eventController = new EventController();
        private Brush brush = Application.Current.Resources["ContainerBackground"] as Brush;
        public AddStickyNote(Event _event)
        {
            InitializeComponent();
            this.DataContext = this;
            this._event = _event;
        }

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int brError = 0;
            if (Description.Text.Length == 0)
            {
                Description.Background = Brushes.Red;
                brError++;
            }
            else
            {
                Description.Background = brush;
            }
            if (unique_mark.Text.Length == 0)
            {
                unique_mark.Background = Brushes.Red;
                brError++;
            }
            else
            {
                unique_mark.Background = brush;
            }

            if (brError > 0)
            {
                return;
            }
            if(ClrPcker_Background.SelectedColor == null)
            {
                MessageBox.Show("Select some color");
                return;
            }

            StickyNote stickyNote = new StickyNote(Description.Text,unique_mark.Text, 
                new Colour(ClrPcker_Background.SelectedColor.Value.A, 
                ClrPcker_Background.SelectedColor.Value.R, 
                ClrPcker_Background.SelectedColor.Value.G,
                ClrPcker_Background.SelectedColor.Value.B ));
            _event.StickyNotes.Add(stickyNote);
            eventController.EditEvent(_event);
            ((StickyNoteTable)this.Owner).refreshTable();
            this.Close();
        }
    }
}
