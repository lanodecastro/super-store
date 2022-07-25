using MediatR;
using SuperStore.Domain.Model.Payment;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class Pay : IPipelineBehavior<CreateOrderRequest, CreateOrderResponse>
    {
        public Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            var paymentMaps = new Dictionary<PaymentType, IPayment>();
            paymentMaps.Add(PaymentType.Pix, new PixPayment());
            paymentMaps.Add(PaymentType.CreditCard, new CreditCardPayment());

            IPayment payment = paymentMaps[request.PaymentType];
            payment.Pay();

            return next();
        }
    }
}
