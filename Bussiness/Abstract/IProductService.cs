﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        //list of product döndürür 
        IDataResult <List<Product>> GetAllByCategoryId(int id);
        IDataResult< List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        // tek başına ürün döndürüyor, 
        IDataResult<Product> GetById(int productId);

        //birşey döndürmüyor 
        //void Add(Product product); void olan yere IResult yaz onu döndürsün
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

      
    }
}
