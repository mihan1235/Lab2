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

        static CustomCommands()
        {
            // Инициализация команды
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
            //requery = new RoutedUICommand("Requery", "Requery", typeof(CustomCommands), inputs);
            __AddModelCommand = new RoutedUICommand("AddModelCommand", "AddModelCommand", typeof(CustomCommands));
        }

        public static RoutedUICommand AddModelCommand
        {
            get { return __AddModelCommand; }
        }
    }
}
