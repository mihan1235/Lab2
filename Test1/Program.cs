using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataLib;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableModelData list = new ObservableModelData();
            list.Add(new ModelData() { p = 1 });
            list.Add(new ModelData() { p = -5 });
            list.Add(new ModelData() { p = 5 });
            list.Add(new ModelData() { p = -3 });
            var tmp = list.MaxDistantP(new ModelData() { p = -6 });
            Console.WriteLine(tmp.p);
        }
    }
}
