using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // çalışacağım tipi çalışırken söylicem: <T>
    public class DataResult<T>: Result,IDataResult<T>
    {
        // constructor için ctor tab2 
        public DataResult(T data, bool succes, string message): base (succes,message)
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
