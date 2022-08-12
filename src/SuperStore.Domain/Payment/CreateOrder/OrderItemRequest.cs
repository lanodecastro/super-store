namespace SuperStore.Domain.Payment.CreateOrder
{
    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
