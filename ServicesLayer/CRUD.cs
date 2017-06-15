using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie4;

namespace ServicesLayer
{
    public class CRUD 
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public CRUD()
        {

        }
        public ObservableCollection<Product> Create(ObservableCollection<Product> list, Product product)
        {
            list.Add(product);
            return list;

        }

        public ObservableCollection<Product> Delete(ObservableCollection<Product> list, Product product)
        {
            list.Remove(product);
            return list;

        }

        public ObservableCollection<Product> Read(ObservableCollection<Product> list)
        {
           
            return list ;
            
        }

        public List<Product> Read(List<Product> list)
        {

            return list;

        }

    }
}
