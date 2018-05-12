﻿using System;
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
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void NotAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
