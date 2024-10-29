using Microsoft.Extensions.DependencyInjection;
using Payments.PaymentMethodProcessors;

namespace Payments;

public static class ServiceCollectionExtensions
{
    public static void AddProgramServices(this IServiceCollection services)
    {
        services.AddSingleton<IPaymentFacade, PaymentFacade>();
        services.AddSingleton<IPaymentProcessorFactory, PaymentProcessorFactory>();
        services.AddSingleton<IPaymentMethodProcessor, LoyaltyCardPaymentProcessor>();
        services.AddSingleton<IPaymentMethodProcessor, CreditCardPaymentProcessor>();
        services.AddSingleton<IPaymentMethodProcessor, GiftCardPaymentProcessor>();
    }
}
