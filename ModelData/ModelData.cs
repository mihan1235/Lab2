using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace ModelDataLib
{
    [Serializable]
    public class FunctionStruct
    {
        public String _Description;

        public FunctionStruct(ModelData.F func, String description)
        {
            this.Func = func;
            this._Description = description;
        }

        public ModelData.F Func
        {
            get;
            set;
        }

        public override string ToString()
        {
            return _Description;
        }
    }

    [Serializable]
    public class ModelData: IDataErrorInfo/*,INotifyPropertyChanged*/
    {
        /// Need to implement this interface in order to get data binding
        /// to work properly.
        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        //[NonSerialized]
        //public event PropertyChangedEventHandler PropertyChanged;

        public String FuncDescription
        {
            get;
            set;
        }

        //Type double for the p parameter of the function;
        public double P
        {
            get;
            set;
        }
        public delegate double F(double x, double y, double p);
        public F Func
        {
            get;
            set;
        }
        //An int parameter for the number of grid nodes by X and y coordinates;
        int _NumberGridNodes=3;
        public int NumberGridNodes
        {
            get { return _NumberGridNodes; }
            set {
                _NumberGridNodes = value;
                x_arr = new double[NumberGridNodes];
                y_arr = new double[NumberGridNodes];
                fill_arr(ref x_arr, 0, 1);
                fill_arr(ref y_arr, 0, 1);
                _GridArr = new ObservableCollection<int>();
                for (int i = 0; i < NumberGridNodes; i++)
                {
                    _GridArr.Add(i);
                }
                //OnPropertyChanged("GridArr");
            }
        }

        public ModelData()
        {
            x_arr = new double[NumberGridNodes];
            y_arr = new double[NumberGridNodes];
            fill_arr(ref x_arr, 0, 1);
            fill_arr(ref y_arr, 0, 1);
            _GridArr = new ObservableCollection<int>();
            for (int i = 0; i < NumberGridNodes; i++)
            {
                _GridArr.Add(i);
            }
            //OnPropertyChanged("GridArr");
        }

        ObservableCollection<int> _GridArr = new ObservableCollection<int>();
        public ObservableCollection<int> GridArr { get
            {
                return _GridArr;
            }
            set
            {
                _GridArr = value;
            }
        }

        double[] x_arr, y_arr;
        public double[] XArr
        {
            get
            {
                return x_arr;
            }
            set
            {
                x_arr = value;
            }
        }
        public double[] YArr
        {
            get
            {
                return y_arr;
            }
            set
            {
                y_arr = value;
            }
        }



        void fill_arr(ref double[] arr, double a, double b)
        {
            double h = (b - a) / (double)NumberGridNodes;
            double tmp = a;
            for (int i = 0; i < NumberGridNodes; i++)
            {
                arr[i] = tmp;
                tmp += h;
            }
        }

        public void Compute(out double[,] func_arr)
        {
            func_arr = new double[NumberGridNodes, NumberGridNodes];
            for (int i = 0; i < NumberGridNodes; i++)
            {
                for (int j = 0; j < NumberGridNodes; j++)
                {
                    func_arr[i, j] = Func(x_arr[i], y_arr[j], P);
                }
            }
        }

        public string Error { get { return "Error Text"; } }

        public string this[string property]
        {
            get
            {
                string msg = null;
                void add_msg(string added_msg)
                {
                    if (added_msg != null)
                    {
                        if (msg != null)
                        {
                            msg += '\n' + added_msg;
                        }
                        else
                        {
                            msg = added_msg;
                        }
                    }

                }

                switch (property)
                {
                    case "NumberGridNodes":
                        if (!(NumberGridNodes >2))
                        {
                            add_msg("Number of grid nodes must be greater then 2");
                        }
                        break;
                    default:
                        break;
                }
                return msg;
            }
            
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("ModelData:\n");
            str.Append("Function: "+FuncDescription+'\n');
            str.Append("Parameter: "+P.ToString()+'\n');
            str.Append("NumberGridNodes: " + NumberGridNodes.ToString()+'\n');
            return str.ToString();
        }
    }
}
