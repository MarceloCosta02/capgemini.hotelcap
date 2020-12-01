using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.DTO
{
    public class TransferResultDTO
    {
        public string Message { get; set; }
        public int Status { get; set; }

        public TransferResultDTO(string message, int status)
        {
            Message = message;
            Status = status;
        }
    }
}
