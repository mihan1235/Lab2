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
using System.Windows.Shapes;
using ModelDataLib;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для AddModelData.xaml
    /// </summary>
    public partial class AddModelData : Window
    {
        public AddModelData()
        {
            InitializeComponent();
            FunctionListBox.SelectedIndex = 0;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var obj =(ModelData)(this.DataContext);
            var func_struct = (FunctionStruct)(FunctionListBox.SelectedItem);
            obj.Func = func_struct.Func;
            obj.FuncDescription = func_struct._Description;
            this.DialogResult = true;
        }

        private void NotAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ValidationErrorFunc(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                if (OkButton != null)
                {
                    OkButton.IsEnabled = false;
                }
            }

            if (e.Action == ValidationErrorEventAction.Removed)
            {
                OkButton.IsEnabled = true;
            }
        }
    }
}
