using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scat_chat_api.Models
{
    public class ServiceResponse<T> //T is type of data want to return
    {
       public T? Data { get; set;}
       public bool Success { get; set; }  = true;
       public string? Message { get; set; } = null;
    }
}