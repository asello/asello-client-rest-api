using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aselloClientRestAPI
{
    public class CancelInvoiceResult
    {
        public CancelInvoiceData data { get; set; } 
        public string status { get; set; }
        public string message { get; set; }

        public class CancelInvoiceData
        {
            public long id { get; set; }
            public string number { get; set; }
            public string status { get; set; }
        }
    }
}
