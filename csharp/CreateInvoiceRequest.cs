using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aselloClientRestAPI
{
    public class CreateInvoiceRequest
    {
        public List<InvoiceItem> items { get; set; }
        public InvoiceCustomer customer { get; set; }
        public string annotation { get; set; }
        public decimal discount { get; set; }
        public string internal_note { get; set; }
    }
}
