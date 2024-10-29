using Microsoft.Extensions.DependencyInjection;

namespace Payments.PaymentMethodProcessors;

public interface IPaymentProcessorFactory
{
    IPaymentMethodProcessor? GetPaymentMethodProcessor(IServiceProvider sp, Order order);
}

internal class PaymentProcessorFactory : IPaymentProcessorFactory
{
    public IPaymentMethodProcessor? GetPaymentMethodProcessor(IServiceProvider sp, Order order)
    {
        var processors = sp.GetRequiredService<IEnumerable<IPaymentMethodProcessor>>();
        var suitableProcessor = processors.FirstOrDefault(x => x.CanProcessOrder(order));

        return suitableProcessor;
    }
}
