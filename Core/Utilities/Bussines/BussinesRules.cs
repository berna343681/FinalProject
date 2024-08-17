using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Bussines
{
    public class BussinesRules
    {
        public static IResult Run(params IResult[] logics) // params ile ıresult türünde ist. parametreleri ekleyebilirz
        {
            foreach(var logic in logics) // logicdeki her iş kuralını gezer 
            {
                if(!logic.Success) // kurala uymayanı döndürüyoruz
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
