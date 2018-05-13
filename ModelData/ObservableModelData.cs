using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ModelDataLib
{
    public class ObservableModelData: ObservableCollection<ModelData>, INotifyPropertyChanged
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
                                orderby Math.Abs(obj.P-md.P) descending
                                select obj).First();
            return MaxPModelData;
        }

        
        public List<FunctionStruct> __FunctionList = new List<FunctionStruct>();
        public List<FunctionStruct> FunctionList
        {
            get
            {
                return __FunctionList;
            }
            set
            {
                __FunctionList = value;
            }
        }

        public ObservableModelData()
        {

            __FunctionList.Add(new FunctionStruct(new ModelData.F((x,y,p)=>Math.Exp(x*y)+p), "Exp(x*y)+p"));
            __FunctionList.Add(new FunctionStruct(new ModelData.F((x,y,p)=> x+p*y), "x+p*y"));
            __FunctionList.Add(new FunctionStruct(new ModelData.F((x,y,p)=>Math.Sin(5*x+y)), "Sin(5*x+y)"));
            CollectionChanged += detect_collection_changed;
        }

        private void detect_collection_changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionIsChanged = true;
        }
    }
}
