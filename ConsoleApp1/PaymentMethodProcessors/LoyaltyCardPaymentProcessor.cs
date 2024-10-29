namespace Payments.PaymentMethodProcessors;

internal class LoyaltyCardPaymentProcessor : IPaymentMethodProcessor
{
    public bool CanProcessOrder(Order order)
    {
        return order.Amount <= 100 || order.PaymentMethod is PaymentMethod.LoyaltyCard;
    }

    public Task<PaymentResult> ProcessPayment(Order order)
    {
        Console.WriteLine("Loyalty Card Payment processing");
        return Task.FromResult(new PaymentResult(true, null));
    }
}
