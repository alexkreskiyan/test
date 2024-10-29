namespace Payments.PaymentMethodProcessors;

internal class GiftCardPaymentProcessor : IPaymentMethodProcessor
{
    public bool CanProcessOrder(Order order)
    {
        return order.PaymentMethod is PaymentMethod.GiftCard;
    }

    public Task<PaymentResult> ProcessPayment(Order order)
    {
        Console.WriteLine("Gift Card Payment processing");
        return Task.FromResult(new PaymentResult(true, null));
    }
}
