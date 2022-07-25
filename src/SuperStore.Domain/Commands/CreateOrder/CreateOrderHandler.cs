using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using SuperStore.Domain.Model.Payment;
using SuperStore.Domain.Repositories;
using SuperStore.Infra.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly CreateOrderResponse _createOrderResponse;
        private readonly IMailService _mailService;
        public CreateOrderHandler(IProductRepository productRepository, IMailService mailService, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _createOrderResponse = new CreateOrderResponse();
            _mailService = mailService;
            _userRepository = userRepository;
        }
        public Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            if (!_createOrderResponse.IsValid)
                return Task.FromResult(_createOrderResponse);

            Console.WriteLine("Request is valid");

            CheckStock(request);

            if (!_createOrderResponse.IsValid)
                return Task.FromResult(_createOrderResponse);

            Console.WriteLine("Stock ok");

            Pay(request);
            Console.WriteLine("Payment ok");

            OrderNotify(request);
            Console.WriteLine("Notify ok");

            _createOrderResponse.OrderId = Guid.NewGuid();

            return Task.FromResult(_createOrderResponse);

        }
        private void ValidateRequest(CreateOrderRequest request)
        {
            _createOrderResponse.AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(request.UserId, "invalid_user_id", "Invalid UserId")
                .IsNotEmpty(request.Items, "items_is_not_empty", "Items cannot be empty")
                );
        }
        private void CheckStock(CreateOrderRequest request)
        {
            foreach (var item in request.Items)
            {
                var product = _productRepository.Get(item.ProductId);

                if (product.AvailableQuantity < item.Amount)
                {
                    _createOrderResponse.AddNotification("invalid_amount", $"Amount is less than available stock for {product.Description}");
                    break;
                }
            }
        }
        private void Pay(CreateOrderRequest request)
        {
            var paymentMaps = new Dictionary<PaymentType, IPayment>();
            paymentMaps.Add(PaymentType.Pix, new PixPayment());
            paymentMaps.Add(PaymentType.CreditCard, new CreditCardPayment());

            IPayment payment = paymentMaps[request.PaymentType];
            payment.Pay();

        }
        private void OrderNotify(CreateOrderRequest request)
        {
            var user = _userRepository.Get(request.UserId);
            _mailService.Send(user.Email);
        }
    }

}
