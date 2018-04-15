using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataLib
{
    public class ModelData
    {
        //Type double for the p parameter of the function;
        public double p;
        delegate double F(double x, double y, double p);
        //An int parameter for the number of grid nodes by X and y coordinates;
        int number_grid_nodes;
        //The array (s) of double values – the computed values of the function in the grid nodes.
        double[,,] arr;
    }
}
