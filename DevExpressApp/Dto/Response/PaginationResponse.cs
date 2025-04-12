using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressApp.Dto.Response
{
    public class PaginationResponse<T>
    {
        public bool Result { get; set; }
        public PaginationContent<T> Content { get; set; }
        public string Message { get; set; }
    }
}
