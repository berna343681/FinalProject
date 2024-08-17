using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{    
    // temel voidler için yazıyoruz 
    public interface IResult
    {
        bool Success { get; } // sadcece okuma ekleme başarılı=true / false
        string Message { get; } // işlem başarılı, ürün eklendi 
    }
}
