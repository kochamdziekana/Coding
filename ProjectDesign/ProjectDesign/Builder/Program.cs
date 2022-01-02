using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new InvoiceBuilder();

            Invoice invoice = builder.SetDate(new DateTime(2022, 1, 1))
                .SetInvoiceNumber("A1")
                .SetVendor("Marcos")
                .SetVendee("Kox")
                .SetLineItems(new List<string>() { "Max", "Adam" })
                .Build();

            Console.WriteLine(invoice.Vendor);
        }

    }
}

// problemy do rozwiązywania builderem
// przykłady:
// tworzenie powtarzalnych obiektów złożonych bez potrzeby deklaracji wielu konstruktorów, etapowe tworzenie obiektów
// prosta wersja:
// Invoice, klasa invoiceBuilder z metodami ustawiającymi fakturę, a na końcu tworzy obiekt metodą np build() -> return Invoice();