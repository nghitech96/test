﻿using System.Data;

namespace WebAPI_QLNS.DTO
{
    public class Response
    {
        // Thêm ngày 20/05/2023
        public Response()
        {
            ResultCode = 0;
            Id = "0";
            Count = 0;
        }
        public Response(int value)
        {

            ResultCode = value;
            Id = "0";
            Count = 0;
        }
        public Response(int value, string message)
        {
            ResultCode = value;
            Message = message;
            Id = "0";
            Count = 0;
        }
        public Response GetResponse()
        {
            return (Response)MemberwiseClone();
        }
        public string Id { get; set; }
        public int ResultCode { get; set; } // 0 : No Error, <>0 Error

        public int Count { get; set; } // Số lượng
        public string Message { get; set; } // Thông báo
        public object data { get; set; } // dữ liệu

        //public DataSet dataset { get; set; }
        public void SetMessage(int value, string message)
        {
            ResultCode = value;
            Message = message;
        }
    }
    
}
