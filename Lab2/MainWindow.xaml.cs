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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using ModelDataLib;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawP2(object sender, RoutedEventArgs e)
        {
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default"));

            // Добавим линию, и назначим ее в ранее созданную область "Default"
            chart.Series.Add(new Series("Series1"));
            chart.Series["Series1"].ChartArea = "Default";
            chart.Series["Series1"].ChartType = SeriesChartType.Line;

            // добавим данные линии
            string[] axisXData = new string[] { "a", "b", "c" };
            double[] axisYData = new double[] { 0.1, 1.5, 1.9 };
            chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);

        }

        private void AddModelFunc(object sender, ExecutedRoutedEventArgs e)
        {
            AddModelData dialog = new AddModelData();
            if (dialog.ShowDialog()==true)
            {
                ModelData obj = (ModelData)dialog.DataContext;
                var ModelDataList = (ObservableModelData)this.FindResource("key_list_model_data");
                ModelDataList.Add(obj);
            }
            else
            {

            }
        }

        private void CanAddModelFunc(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CanDeleteModelFunc(object sender,CanExecuteRoutedEventArgs e)
        {
            if (ListboxOMD.SelectedIndex == -1)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void DeleteModelFunc(object sender,ExecutedRoutedEventArgs e)
        {
            int index = ListboxOMD.SelectedIndex;
            var DO = (ObservableModelData)this.FindResource("key_list_model_data");
            if (index != -1)
            {
                DO.RemoveAt(index);
            }
        }
    }
}
