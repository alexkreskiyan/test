namespace Payments;

public interface IPaymentFacade
{
    Task<PaymentResult> ProcessPayment(Order order);
}
