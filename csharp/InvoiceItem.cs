namespace aselloClientRestAPI
{
    public class InvoiceItem
    {
        public string description { get; set; }
        public string name { get; set; }
        public decimal netprice { get; set; }
        public decimal quantity { get; set; }
        /// <summary>
        /// A, B, C, D, E
        /// </summary>
        public string vatcode { get; set; }
        public string articlenumber { get; set; }
    }
}