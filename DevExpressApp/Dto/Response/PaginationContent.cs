using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressApp.Dto.Response
{
    public class PaginationContent<T>
    {
        public PaginationMetadata pagintaion { get; set; }
        public List<T> Data { get; set; }
    }
}
