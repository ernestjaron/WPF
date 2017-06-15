using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie4;
using ServicesLayer;

namespace GUI.Model
{
    public class DataLayer
    {
        public List<Product> Products
        {
            get
            {
                List<Product> Products = new List<Product>();
                CRUD crud = new CRUD();
                Products = crud.Read(Products);
                return Products;
            }
        }
    }
}
