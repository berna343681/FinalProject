using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string  CategoryName { get; set; } = string.Empty;
        public short  UnitsInStock { get; set; }
    }
}
