
namespace Builder
{
    public interface IInvoiceBuilder
    {
        Invoice Build();
        InvoiceBuilder SetDate(DateTime date);
        InvoiceBuilder SetInvoiceNumber(string number);
        InvoiceBuilder SetLineItems(IEnumerable<string> lineItems);
        InvoiceBuilder SetNote(string note);
        InvoiceBuilder SetVendee(string vendee);
        InvoiceBuilder SetVendor(string vendor);
    }
}