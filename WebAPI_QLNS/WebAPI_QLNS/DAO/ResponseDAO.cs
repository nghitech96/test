using System.Data;
using System.Drawing;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
   
        public class ResponseDAO : Response
        {
            public ResponseDAO()
            {
                
                ResultCode = 0;
                dataset = new DataSet();
                Count = 0;
                Id = "0";
            }
            public ResponseDAO(int value)
            {

                ResultCode = value;
                dataset = new DataSet();
                Count = 0;
                Id = "0";
            }
            public ResponseDAO(int value, string message)
            {
                dataset = new DataSet();
                ResultCode = value;
                Message = message;
                Count = 0;
                Id = "0";
            }

            public Response getRespone()
            {
                return base.GetResponse();
            }

            //public int Id { get; set; }
            //public string Message { get; set; }
            //public object data { get; set; }
            public DataSet dataset { get; set; }
            //public void SetMessage(int value, string message)
            //{
            //    Id = value;
            //    Message = message;
            //}
         }
}
