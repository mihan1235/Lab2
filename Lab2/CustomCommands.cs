using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2
{
    class CustomCommands
    {
        // Создание команды AddCustomProgrammer
        private static RoutedUICommand __AddModelCommand;
        private static RoutedUICommand _DrawSelectedCommand;
        private static RoutedUICommand _DrawP2Command;

        static CustomCommands()
        {
            // Инициализация команды
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
            //requery = new RoutedUICommand("Requery", "Requery", typeof(CustomCommands), inputs);
            __AddModelCommand = new RoutedUICommand("AddModelCommand", "AddModelCommand", typeof(CustomCommands));
            _DrawSelectedCommand = new RoutedUICommand("DrawSelectedCommand", "DrawSelectedCommand", typeof(CustomCommands));
            _DrawP2Command = new RoutedUICommand("DrawP2Command", "DrawP2Command", typeof(CustomCommands));
        }

        public static RoutedUICommand AddModelCommand
        {
            get { return __AddModelCommand; }
        }

        public static RoutedUICommand DrawSelectedCommand
        {
            get { return _DrawSelectedCommand; }
        }

        public static RoutedUICommand DrawP2Command
        {
            get { return _DrawP2Command; }
        }

    }
}
