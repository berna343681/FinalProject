﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // çıplak class kalmayacak, Result:IResult 
    public class Result : IResult
    {
       
        public Result(bool success, string message):this(success)
        {
            Message = message;
            
        }

        public Result(bool success)
        {
            Success = success;
        }

        // interface içinde sadece get olduğundan dolayı 
        // => ve sonrasına ne yazacaksak return edecek 


        public bool Success  { get; }
        public string Message { get; }
    }
}
