using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Servcies
{
    public class ProductService : IProductService
    {
        public List<ProductModel> GetProductList()
        {
            List<ProductModel> lst = new List<ProductModel>()
            {
                new ProductModel { Id=1,Name="Product1",Price=10,Quantity=10},
                new ProductModel { Id=2,Name="Product2",Price=20,Quantity=20},
                new ProductModel { Id=3,Name="Product3",Price=30,Quantity=30},
                new ProductModel { Id=4,Name="Product4",Price=40,Quantity=40}
            };

            return lst;
        }
    }
}
