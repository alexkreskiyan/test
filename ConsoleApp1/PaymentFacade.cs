using Microsoft.Extensions.DependencyInjection;
using Payments.PaymentMethodProcessors;

namespace Payments;

public class PaymentFacade(IServiceProvider sp, IPaymentProcessorFactory paymentProcessorFactory) : IPaymentFacade
{
    public async Task<PaymentResult> ProcessPayment(Order order)
    {
        await using var scope = sp.CreateAsyncScope();
        var processor = paymentProcessorFactory.GetPaymentMethodProcessor(sp, order);
        if (processor is null)
            return new PaymentResult(false, $"Can't process order with unsupported payment method: {order.PaymentMethod}");

        return await processor.ProcessPayment(order);
    }
}
