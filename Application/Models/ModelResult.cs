using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ModelResult<T> where T : class
    {
        public ModelResult(T result, string message = "")
        {
            Result = result;
            Status = ModelResultStatus.OK;
            Message = message;
        }

        public ModelResult(T result, ModelResultStatus status, string message = "")
        {
            Result = result;
            Status = status;
            Message = message;
        }

        public T Result { get; set; }
        public ModelResultStatus Status { get; set; }
        public string Message { get; set; }
    }

    public enum ModelResultStatus
    {
        OK = 0,
        Error = 1
    }
}
