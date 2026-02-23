namespace ModularMonolith_DecoupledBoundaries.BillingModule
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Sent { get; internal set; }
    }
}
