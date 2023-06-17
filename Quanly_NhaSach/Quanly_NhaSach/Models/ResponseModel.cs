using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanly_NhaSach.Models
{
    internal class ResponseModel
    {
        public ResponseModel() { }
        public ResponseModel(int code, string message)
        {
            this.ResultCode = code;
            this.Message = message;
        }


        public int ResultCode { get; set; }
        public int Count { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public object data { get; set; }    
    }
}
