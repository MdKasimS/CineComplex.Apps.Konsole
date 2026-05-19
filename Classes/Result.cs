using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Classes
{
    public class Result<T>
    {
        public T Value { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public Result(T value, bool isSuccessful, string message)
        {
            Value = value;
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
