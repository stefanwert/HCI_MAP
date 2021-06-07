using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HCI_MAP
{
    public static class MyCommands
    {
        public static readonly RoutedUICommand AddEvent = new RoutedUICommand(
            "Add event",
            "Add event",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control),
                new KeyGesture(Key.A, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand EditEvent = new RoutedUICommand(
            "Edit event",
            "Edit event",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control),
                new KeyGesture(Key.E, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand DeleteEvent = new RoutedUICommand(
            "Delete event",
            "Delete event",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control),
                new KeyGesture(Key.D, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand GoToMap = new RoutedUICommand(
            "Go to map",
            "Go to map",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Control),
                new KeyGesture(Key.G, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand ShowStickyNotes = new RoutedUICommand(
            "ShowStickyNotes",
            "ShowStickyNotes",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control),
                new KeyGesture(Key.S, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand ChangeTheme = new RoutedUICommand(
            "ChangeTheme",
            "ChangeTheme",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control),
                new KeyGesture(Key.T, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand Lenguage = new RoutedUICommand(
            "Lenguage",
            "Lenguage",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Control),
                new KeyGesture(Key.L, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand windowsCommand1 = new RoutedUICommand(
            "windowsCommand1",
            "windowsCommand1",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F1, ModifierKeys.Control),
                new KeyGesture(Key.F1, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand windowsCommand2 = new RoutedUICommand(
            "windowsCommand2",
            "windowsCommand2",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F2, ModifierKeys.Control),
                new KeyGesture(Key.F2, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand windowsCommand3 = new RoutedUICommand(
            "windowsCommand",
            "windowsCommand",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F3, ModifierKeys.Control),
                new KeyGesture(Key.F3, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand addTypeOfEvent = new RoutedUICommand(
            "addTypeOfEvent",
            "addTypeOfEvent",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control),
                new KeyGesture(Key.A, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand editTypeOfEvent = new RoutedUICommand(
            "editTypeOfEvent",
            "editTypeOfEvent",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control),
                new KeyGesture(Key.E, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand deleteTypeOfEvent = new RoutedUICommand(
            "deleteTypeOfEvent",
            "deleteTypeOfEvent",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control),
                new KeyGesture(Key.D, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );
    }
}
