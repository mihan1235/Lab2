using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataLib
{
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


    public class ModelData: IDataErrorInfo
    {
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
            set { _NumberGridNodes = value; }
        }
        //The array (s) of double values – the computed values of the function in the grid nodes.
        double[,,] arr;

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
