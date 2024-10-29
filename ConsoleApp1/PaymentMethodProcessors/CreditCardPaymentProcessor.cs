namespace Payments.PaymentMethodProcessors;

internal class CreditCardPaymentProcessor : IPaymentMethodProcessor
{
    public bool CanProcessOrder(Order order)
    {
        return order.PaymentMethod is PaymentMethod.CreditCard;
    }

    public Task<PaymentResult> ProcessPayment(Order order)
    {
        Console.WriteLine("Credit Card Payment processing");
        return Task.FromResult(new PaymentResult(true, null));
    }
}
