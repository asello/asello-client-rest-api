using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aselloClientRestAPI
{
    class Program
    {
        const string RootUrl = "http://localhost:2323/";


        static void Main(string[] args)
        {
            Run().Wait();

            Console.ReadLine();
        }

        static async Task Run()
        {
            try
            {
                var res = await createNewInvoice();

                Console.WriteLine("invoice created " + res.data.number);

                var res2 = await cancelInvoice(res.data.id);

                Console.WriteLine("invoice canceled " + res2.data.number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
        }

        static async Task<T> HttpPost<T>(string url, object data)
        {
            var client = new HttpClient();

            var res = await client.PostAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            res.EnsureSuccessStatusCode();

            var obj = await res.Content.ReadAsAsync(typeof(T));

            return (T)obj;
        }
        static async Task<CreateInvoiceResult> createNewInvoice()
        {
            var data = new CreateInvoiceRequest()
            {
                items = new List<InvoiceItem>() {
                    new InvoiceItem()
                    {
                        name = "Produkt 1",
                        description = "Meine Beschreibung",
                        netprice = 20,
                        vatcode = "A",
                        quantity = 2
                    }
                },
                customer = new InvoiceCustomer()
                {
                    salution = "Mister",
                    name = "Müller",
                    firstname = "Max",
                    street = "Straße 12",
                    zip = "8150",
                    city = "Graz"
                },
                annotation = "Meine Anmerkung auf dieser Rechnung",
                internal_note = "Meine interne Notiz zu dieser Rechnung",
                discount = 20.0m
            };

            var requestUrl = RootUrl + "api/create?action=print";

            var res = await HttpPost<CreateInvoiceResult>(requestUrl, data);

            return res;
        }
        static async Task<CancelInvoiceResult> cancelInvoice(long id)
        {
            var data = new CancelInvoiceRequest()
            {
                id = id,
                reason = "Meine Begründung",
                internal_note = "Meine interne Notiz",
                print = true,
                printer = "default"
            };

            var requestUrl = RootUrl + "api/cancel";

            var res = await HttpPost<CancelInvoiceResult>(requestUrl, data);

            if (res.status == "error")
                throw new Exception(res.message);

            return res;
        }
    }
}
