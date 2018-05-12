using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace ModelDataLib
{
    public class ObservableModelData: ObservableCollection<ModelData>
    {
        bool collection_is_changed;
        public bool CollectionIsChanged
        {
            get
            {
                return collection_is_changed;
            }
            set
            {
                collection_is_changed = value;
            }
        }

        //The Modeldata Maxdistantp method(Modeldata MD), which returns 
        //a member of a collection that has a value of p as different 
        //from the P of the MD object (the difference between the P 
        //value of this element and the MD object is the maximum)
        public ModelData MaxDistantP(ModelData md)
        {
            var MaxPModelData = (from obj in Items
                                orderby Math.Abs(obj.p-md.p) descending
                                select obj).First();
            return MaxPModelData;
        }

        public List<ModelData.F> __FunctionList = new List<ModelData.F>();
        public List<ModelData.F> FunctionList
        {
            get;
            set;
        }

        public ObservableModelData()
        {

            __FunctionList.Add(new ModelData.F((x,y,p)=>Math.Exp(x*y)+p));
            __FunctionList.Add(new ModelData.F((x,y,p)=> x+p*y));
            __FunctionList.Add(new ModelData.F((x,y,p)=>Math.Sin(5*x+y)));
        }
    }
}
