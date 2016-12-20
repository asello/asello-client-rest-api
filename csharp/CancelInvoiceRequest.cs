namespace aselloClientRestAPI
{
    public class CancelInvoiceRequest
    {
        public long id { get; set; }
        public string internal_note { get; set; }
        public bool print { get; set; }
        public string printer { get; set; }
        public string reason { get; set; }
    }
}