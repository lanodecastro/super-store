using MediatR;
using SuperStore.Domain.Account;
using SuperStore.Domain.Inventory;
using SuperStore.Domain.Payment.CreateOrder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class RetriveData : IPipelineBehavior<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly CreateOrderContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public RetriveData(CreateOrderContext context, IUserRepository userRepository, IProductRepository productRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            _context.User = _userRepository.Get(request.UserId);

            foreach (var item in request.Items)
            {
                _context.Products.Add(_productRepository.Get(item.ProductId));
            }

            Console.WriteLine("RetrieveData ok;");

            return next();
        }
    }
}
