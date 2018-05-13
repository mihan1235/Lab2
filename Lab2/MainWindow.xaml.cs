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

        private void DrawP2CommandFunc(object sender, ExecutedRoutedEventArgs e)
        {
            int SelectedNodeNum = (int)GridComboBox.SelectedValue;
            var ModelDataObj = (ModelData)ListboxOMD.SelectedItem;

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();
            PreparePlotModelData(ref chart, SelectedNodeNum, ref ModelDataObj);

            var ObservableModelDataList = (ObservableModelData)FindResource("key_list_model_data");
            var MaxDistantPObj = ObservableModelDataList.MaxDistantP(ModelDataObj);

            PreparePlotModelDataMax(ref chart, SelectedNodeNum, ref MaxDistantPObj);
        }

        private void CanDrawP2Command(object sender, CanExecuteRoutedEventArgs e)
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

        private void PreparePlotModelDataMax(ref Chart chart, int SelectedNodeNum, ref ModelData ModelDataObj,
            bool SetMarker = true)
        {
            double[,] func_arr;
            ModelDataObj.Compute(out func_arr);
            {
                List<double> axisYData = new List<double>();
                for (int i = 0; i < ModelDataObj.NumberGridNodes; i++)
                {
                    axisYData.Add(func_arr[i, SelectedNodeNum]);
                }
                string series1 = ModelDataObj.FuncDescription + " with fixed x max p";
                //////////////////////////////////////////////////////////////////////////
                // Все графики находятся в пределах области построения ChartArea, создадим ее
                chart.ChartAreas.Add(new ChartArea("Default2"));
                // Добавим линию, и назначим ее в ранее созданную область "Default2"
                chart.Series.Add(new Series(series1));
                chart.Series[series1].ChartArea = "Default2";
                chart.Series[series1].ChartType = SeriesChartType.Line;
                if (SetMarker)
                {
                    chart.Series[series1].MarkerStyle = MarkerStyle.Square;
                    chart.Series[series1].MarkerSize = 5;
                }


                // Create a new legend called "Legend3".
                chart.Legends.Add(new Legend("Legend3"));
                // Set Docking of the Legend chart to the Default2 Chart Area.
                chart.Legends["Legend3"].DockedToChartArea = "Default2";

                // Assign the legend to Series1.
                chart.Series[series1].Legend = "Legend3";
                chart.Series[series1].IsVisibleInLegend = true;

                chart.Legends["Legend3"].Title = "P:" + ModelDataObj.P.ToString() + "\n"
                    + "j: " + SelectedNodeNum.ToString() + "\n";

                // добавим данные линии
                chart.Series[series1].Points.DataBindXY(ModelDataObj.YArr, axisYData);
                //////////////////////////////////////////////////////////////////////////
            }
            List<double> AxisXData = new List<double>();
            for (int i = 0; i < ModelDataObj.NumberGridNodes; i++)
            {
                AxisXData.Add(func_arr[i, SelectedNodeNum]);
            }
            string series2 = ModelDataObj.FuncDescription + " with fixed y max p";
            //////////////////////////////////////////////////////////////////////////
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default3"));
            // Добавим линию, и назначим ее в ранее созданную область "Default3"
            chart.Series.Add(new Series(series2));
            chart.Series[series2].ChartArea = "Default3";
            chart.Series[series2].ChartType = SeriesChartType.Line;
            if (SetMarker)
            {
                chart.Series[series2].MarkerStyle = MarkerStyle.Square;
                chart.Series[series2].MarkerSize = 5;
            }

            // Create a new legend called "Legend4".
            chart.Legends.Add(new Legend("Legend4"));
            // Set Docking of the Legend chart to the Default3 Chart Area.
            chart.Legends["Legend4"].DockedToChartArea = "Default3";

            // Assign the legend to Series2.
            chart.Series[series2].Legend = "Legend4";
            chart.Series[series2].IsVisibleInLegend = true;

            chart.Legends["Legend4"].Title = "P:" + ModelDataObj.P.ToString() + "\n"
                + "j: " + SelectedNodeNum.ToString() + "\n";

            // добавим данные линии
            chart.Series[series2].Points.DataBindXY(AxisXData, ModelDataObj.XArr);
            //////////////////////////////////////////////////////////////////////////
        }

        private void PreparePlotModelData(ref Chart chart, int SelectedNodeNum,ref ModelData ModelDataObj,
            bool SetMarker = true)
        {
            double[,] func_arr;
            ModelDataObj.Compute(out func_arr);
            {
                List<double> axisYData = new List<double>();
                for (int i = 0; i < ModelDataObj.NumberGridNodes; i++)
                {
                    axisYData.Add(func_arr[i, SelectedNodeNum]);
                }
                string series1 = ModelDataObj.FuncDescription+" with fixed x";
                //////////////////////////////////////////////////////////////////////////
                // Все графики находятся в пределах области построения ChartArea, создадим ее
                chart.ChartAreas.Add(new ChartArea("Default"));
                // Добавим линию, и назначим ее в ранее созданную область "Default"
                chart.Series.Add(new Series(series1));
                chart.Series[series1].ChartArea = "Default";
                chart.Series[series1].ChartType = SeriesChartType.Line;
                if (SetMarker)
                {
                    chart.Series[series1].MarkerStyle = MarkerStyle.Square;
                    chart.Series[series1].MarkerSize = 5;
                }
                

                // Create a new legend called "Legend1".
                chart.Legends.Add(new Legend("Legend1"));
                // Set Docking of the Legend chart to the Default Chart Area.
                chart.Legends["Legend1"].DockedToChartArea = "Default";

                // Assign the legend to Series1.
                chart.Series[series1].Legend = "Legend1";
                chart.Series[series1].IsVisibleInLegend = true;

                chart.Legends["Legend1"].Title = "P:" + ModelDataObj.P.ToString() + "\n"
                    + "j: " + SelectedNodeNum.ToString() + "\n";

                // добавим данные линии
                chart.Series[series1].Points.DataBindXY(ModelDataObj.YArr, axisYData);
                //////////////////////////////////////////////////////////////////////////
            }
            List<double> AxisXData = new List<double>();
            for (int i = 0; i < ModelDataObj.NumberGridNodes; i++)
            {
                AxisXData.Add(func_arr[i, SelectedNodeNum]);
            }
            string series2 = ModelDataObj.FuncDescription+" with fixed y";
            //////////////////////////////////////////////////////////////////////////
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default1"));
            // Добавим линию, и назначим ее в ранее созданную область "Default1"
            chart.Series.Add(new Series(series2));
            chart.Series[series2].ChartArea = "Default1";
            chart.Series[series2].ChartType = SeriesChartType.Line;
            if (SetMarker)
            {
                chart.Series[series2].MarkerStyle = MarkerStyle.Square;
                chart.Series[series2].MarkerSize = 5;
            }

            // Create a new legend called "Legend2".
            chart.Legends.Add(new Legend("Legend2"));
            // Set Docking of the Legend chart to the Default1 Chart Area.
            chart.Legends["Legend2"].DockedToChartArea = "Default1";

            // Assign the legend to Series2.
            chart.Series[series2].Legend = "Legend2";
            chart.Series[series2].IsVisibleInLegend = true;

            chart.Legends["Legend2"].Title = "P:" + ModelDataObj.P.ToString() + "\n"
                + "j: " + SelectedNodeNum.ToString() + "\n";

            // добавим данные линии
            chart.Series[series2].Points.DataBindXY(AxisXData, ModelDataObj.XArr);
            //////////////////////////////////////////////////////////////////////////
        }

        private void DrawSelectedCommandFunc(object sender, ExecutedRoutedEventArgs e)
        {
            int SelectedNodeNum = (int)GridComboBox.SelectedValue;
            var ModelDataObj = (ModelData)ListboxOMD.SelectedItem;
            
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();
            PreparePlotModelData(ref chart,SelectedNodeNum,ref ModelDataObj);
            
        }

        private void CanDrawSelectedCommand(object sender, CanExecuteRoutedEventArgs e)
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

    }
}
