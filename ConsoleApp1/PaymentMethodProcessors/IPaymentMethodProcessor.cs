namespace Payments.PaymentMethodProcessors;

public interface IPaymentMethodProcessor
{
    bool CanProcessOrder(Order order);
    Task<PaymentResult> ProcessPayment(Order order);
}
