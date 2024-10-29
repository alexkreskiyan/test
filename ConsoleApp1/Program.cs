using Microsoft.Extensions.DependencyInjection;
using Payments;

var services = new ServiceCollection();
services.AddProgramServices();
await using var sp = services.BuildServiceProvider();

var paymentFacade = sp.GetRequiredService<IPaymentFacade>();

var loyaltyCardResult = await paymentFacade.ProcessPayment(new Order
{
    Id = 1,
    Amount = 100,
    PaymentMethod = PaymentMethod.CreditCard
});
Console.WriteLine(loyaltyCardResult.IsSuccess ? "Payment successful" : $"Payment failed: {loyaltyCardResult.Error}");

var creditCardResult = await paymentFacade.ProcessPayment(new Order
{
    Id = 1,
    Amount = 150,
    PaymentMethod = PaymentMethod.CreditCard
});
Console.WriteLine(creditCardResult.IsSuccess ? "Payment successful" : $"Payment failed: {creditCardResult.Error}");

var giftCardResult = await paymentFacade.ProcessPayment(new Order
{
    Id = 2,
    Amount = 150,
    PaymentMethod = PaymentMethod.GiftCard
});
Console.WriteLine(giftCardResult.IsSuccess ? "Payment successful" : $"Payment failed: {giftCardResult.Error}");
