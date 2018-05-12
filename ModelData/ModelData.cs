﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataLib
{
    public class ModelData: IDataErrorInfo
    {
        //Type double for the p parameter of the function;
        public double p;
        delegate double F(double x, double y, double p);
        //An int parameter for the number of grid nodes by X and y coordinates;
        int number_grid_nodes;
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
                        if (!(number_grid_nodes >2))
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
    }
}