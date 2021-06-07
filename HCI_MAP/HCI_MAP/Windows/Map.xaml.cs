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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_MAP.Windows
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        UIElement dragObject = null;
        Point offset;
        EventController eventController = new EventController();
        TypeOfEventController typeOfEventController = new TypeOfEventController();
        List<Event> events = new List<Event>();
        public event PropertyChangedEventHandler PropertyChanged;
        public static double bugfixOffset=0;
        private int lastSelectedId=-1;
        private int eventStartPostionOffset=0;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Map()
        {
            InitializeComponent();
            this.DataContext = this;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Resource/world_map.jpg", UriKind.RelativeOrAbsolute));
            MyCanvas.Background = ib;
            /*StackPanel stackPanel = new StackPanel();
            stackPanel.Background = Brushes.Blue;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Top;
            stackPanel.Width = MyCanvas.Width;
            stackPanel.Height = 30;
            stackPanel.Name = "stackPanel";
            MyCanvas.Children.Add(stackPanel);*/
            events = eventController.GetAllEvents();
            foreach (Event e in events)
            {
                Canvas canvas = new Canvas();
                
                canvas.Width = 20;
                canvas.Height = 20;
                canvas.Name = "ID" + e.Id.ToString();
                TypeOfEvent typeOfEvent = typeOfEventController.getById(e.TypeOfEventId);
                if(typeOfEvent == null)
                {
                    DefaultImg(canvas);
                }
                else if (typeOfEvent.PicturePath.Length == 0  )
                {
                    DefaultImg(canvas);
                }
                else
                {
                    ImageBrush ib2 = new ImageBrush();
                    ib2.ImageSource = new BitmapImage(new Uri("Resource/"+typeOfEvent.PicturePath, UriKind.RelativeOrAbsolute));
                    canvas.Background = ib2;
                }
                canvas.MouseEnter += MyCanvas_MouseEnter;
                canvas.MouseLeave += MyCanvas_MouseLeave;
                canvas.PreviewMouseMove += Canvas_PreviewMouseMove;// added now
                if(e.X <30 || e.Y < 30)
                {
                    e.Y = 0 + eventStartPostionOffset*30;
                    eventStartPostionOffset++;
                    e.X = 0;
                }
                Canvas.SetTop(canvas, e.X);
                Canvas.SetLeft(canvas, e.Y);
                canvas.PreviewMouseDown += PreviewMouseDown;
                MyCanvas.Children.Add(canvas);

            }
        }

        private static void DefaultImg(Canvas canvas)
        {
            ImageBrush ib2 = new ImageBrush();
            ib2.ImageSource = new BitmapImage(new Uri("Resource/" + "download.png", UriKind.RelativeOrAbsolute));
            canvas.Background = ib2;
        }

        private void MyCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas canvas = ((Canvas)sender);
            bool isElementRemoved = true;
            do
            {
                isElementRemoved = removeStacPanel(canvas);
            } while (isElementRemoved == true);
        }

        private bool removeStacPanel(Canvas canvas)
        {
            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                if (fe.Name.Substring(1).Equals(canvas.Name))
                {
                    MyCanvas.Children.Remove(fe);
                    return true;
                }
            }
            return false;
        }

        private void MyCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas canvas = ((Canvas)sender);
            
            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "s"+canvas.Name;
            stackPanel.Background = Brushes.Green;
            int id;
            try
            {
                id = int.Parse(canvas.Name.Substring(2));
            }
            catch
            {
                return;
            }
            fillStackPanelWithInfoAboutEvent(stackPanel, id);
            double top = Canvas.GetTop(canvas);
            double left = Canvas.GetLeft(canvas);

            Canvas.SetTop(stackPanel, top+20);
            Canvas.SetLeft(stackPanel, left);
            MyCanvas.Children.Add(stackPanel);
        }

        private void fillStackPanelWithInfoAboutEvent(StackPanel stackPanel, int id)
        {
            foreach (Event ev in events)
            {
                if (ev.Id == id)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.FontSize = 12;
                    textBlock.Text += "Name:" + ev.Name;
                    stackPanel.Children.Add(textBlock);

                    TextBlock textBlock2 = new TextBlock();
                    textBlock2.FontSize = 12;
                    textBlock2.Text += "Price:" + ev.Price.ToString();
                    stackPanel.Children.Add(textBlock2);

                    TextBlock textBlock3 = new TextBlock();
                    textBlock3.FontSize = 12;
                    textBlock3.Text += "Country:" + ev.Country;
                    stackPanel.Children.Add(textBlock3);

                    TextBlock textBlock4 = new TextBlock();
                    textBlock4.FontSize = 12;
                    textBlock4.Text += "City:" + ev.City;
                    stackPanel.Children.Add(textBlock4);
                }
            }
        }

        private void PreviewMouseDown (object sender, MouseButtonEventArgs e)
        {
            bugfixOffset = 3;
            try
            {
                string strId = ((FrameworkElement)sender).Name;
                if (strId.StartsWith("ID"))
                {
                    lastSelectedId = int.Parse(strId.Substring(2));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.MyCanvas);
            double top = Canvas.GetTop(this.dragObject);
            double left = Canvas.GetLeft(this.dragObject);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.MyCanvas.CaptureMouse();
        }
        public Rect GetBounds(FrameworkElement of, FrameworkElement from)
        {
            // Might throw an exception if of and from are not in the same visual tree
            GeneralTransform transform = of.TransformToVisual(from);

            return transform.TransformBounds(new Rect(0, 0, of.ActualWidth - bugfixOffset, of.ActualHeight - bugfixOffset));
        }
        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //logic for forbbiding overlaping of canvas 
            
            FrameworkElement frameworkElement = (FrameworkElement)this.dragObject;
            if(frameworkElement == null)
            {
                return;
            }
            e.GetPosition(this);
            if (frameworkElement.Name.StartsWith("ID"))
            {
                foreach (FrameworkElement fe in MyCanvas.Children)
                {
                    var currentBounds = GetBounds(fe, this);
                    if (GetBounds(frameworkElement, this).IntersectsWith(currentBounds) && !frameworkElement.Name.Equals(fe.Name))
                    {
                        return;
                    }
                }


            }
            if(bugfixOffset>0)
                bugfixOffset -= 0.5;
            if (this.dragObject == null)
            return;

            var position = e.GetPosition(sender as IInputElement);
            if(position.X>990 || position.Y>610 || position.X<10 || position.Y<10)
            {
                return;
            }
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.MyCanvas.ReleaseMouseCapture();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                double top = Canvas.GetTop(fe);
                double left = Canvas.GetLeft(fe);
                int id = int.Parse(fe.Name.Substring(2));
                foreach(Event ev in events)
                {
                    if(id == ev.Id)
                    {
                        ev.X = top ;
                        ev.Y = left;
                        eventController.EditEvent(ev);
                        break;
                    }
                }
            }
        }

        private void filterClick(object sender, RoutedEventArgs e)
        {
            refreshMapList();
            if (searchTextBox.Text.Length == 0)
            {
                return;
            }

            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                int id = int.Parse(fe.Name.Substring(2));
                foreach (Event ev in events)
                {
                    if (ev.Id == id)
                    {
                        if (!ev.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
                            fe.Visibility = Visibility.Hidden;
                    }
                }

            }
        }

        private void refreshMapList()
        {
            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                fe.Visibility = Visibility.Visible;
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
            Window w = new TypeOfEventTable();
            w.Show();
            this.Close();
        }

        private void ShowMap(object sender, RoutedEventArgs e)
        {

        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                fe.Visibility = Visibility.Visible;
            }
            searchTextBox.Text = "";
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            foreach (FrameworkElement fe in MyCanvas.Children)
            {
                if (fe.Name.StartsWith("ID"))
                {
                    try
                    {
                        Canvas canvas = (Canvas)fe;
                        if (fe.Name.EndsWith(lastSelectedId.ToString()))
                        {
                            MyCanvas.Children.Remove(fe);
                            break;
                        }
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2.Message);
                    }
                }
            }
            eventController.RemoveById(lastSelectedId);
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
            e.CanExecute = false;
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
