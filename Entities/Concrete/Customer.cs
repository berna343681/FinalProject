using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class Customer:IEntity
    {
        public string CustomerId { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;


    }
}