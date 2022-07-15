using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> GetProductList();
    }
}
