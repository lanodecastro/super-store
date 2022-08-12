using MediatR;
using SuperStore.Domain.Model.Payment;
using SuperStore.Domain.Payment.CreateOrder;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class Pay : IPipelineBehavior<CreateOrderCommand, CreateOrderResponse>
    {
        public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            var paymentMaps = new Dictionary<PaymentTypeEnum, IPayment>();
            paymentMaps.Add(PaymentTypeEnum.Pix, new PixPayment());
            paymentMaps.Add(PaymentTypeEnum.CreditCard, new CreditCardPayment());

            IPayment payment = paymentMaps[request.PaymentType];
            payment.Pay();

            return next();
        }
    }
}
