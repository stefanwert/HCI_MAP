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
    /// Interaction logic for EditStickyNote.xaml
    /// </summary>
    public partial class EditStickyNote : Window
    {
        private StickyNote stickyNote;
        EventController eventController = new EventController();
        public event PropertyChangedEventHandler PropertyChanged;
        String old_humman_desc;
        private Brush brush = Application.Current.Resources["ContainerBackground"] as Brush;
        public EditStickyNote(StickyNote stickyNote)
        {
            InitializeComponent();
            this.DataContext = this;
            this.stickyNote = stickyNote;

            Color color = new Color();
            color.A = stickyNote.Color.A;
            color.R = stickyNote.Color.R;
            color.G = stickyNote.Color.G;
            color.B = stickyNote.Color.B;

            old_humman_desc = stickyNote.Human_description;

            ClrPcker_Background.SelectedColor = color;
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public StickyNote StickyNote
        {
            get
            {
                return stickyNote;
            }
            set
            {
                if (value != stickyNote)
                {
                    stickyNote = value;
                    OnPropertyChanged("StickyNote");
                }
            }
        }
        private void EditNote(object sender, RoutedEventArgs e)
        {
            int brError = 0;
            brError = validateTextBoxs(brError);

            if (brError > 0)
            {
                return;
            }
            if (ClrPcker_Background.SelectedColor == null)
            {
                MessageBox.Show("Select some color");
                return;
            }
            Colour colour = new Colour(ClrPcker_Background.SelectedColor.Value.A,
                ClrPcker_Background.SelectedColor.Value.R,
                ClrPcker_Background.SelectedColor.Value.G,
                ClrPcker_Background.SelectedColor.Value.B);
            StickyNote stickyNoteNew = new StickyNote(stickyNote.Description, stickyNote.Human_description, colour);

            ((StickyNoteTable)this.Owner).editStickyNote(stickyNoteNew, old_humman_desc);
            this.Close();
        }

        private int validateTextBoxs(int brError)
        {
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

            return brError;
        }
    }
}
