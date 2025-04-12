using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressApp.Model
{
    public class DPost
    {
        public long Id { get; set; }
        public long PostId { get; set; }    // (m_post)
        public string Content { get; set; }
    }
}
