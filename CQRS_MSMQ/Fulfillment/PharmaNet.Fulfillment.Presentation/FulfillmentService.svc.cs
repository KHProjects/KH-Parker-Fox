using System;
using System.Linq;
using System.ServiceModel;
using PharmaNet.Fulfillment.Application;
using PharmaNet.Fulfillment.Contract;
using PharmaNet.Fulfillment.SQL;
using PharmaNet.Infrastructure.Messaging;

namespace PharmaNet.Fulfillment.Presentation
{
    public class FulfillmentService : IFulfillmentService
    {
        private PickListService _pickListService;

        private IMessageQueueOutbound<Messages.PlaceOrder>
            _messageQueue;

        private Random _networkError = new Random();

        public FulfillmentService()
        {
            FulfillmentDB.Initialize();

            FulfillmentDB context = new FulfillmentDB();

            _pickListService = new PickListService(
                context.GetPickListRepository());

            _messageQueue = new MsmqMessageQueueOutbound<
                Messages.PlaceOrder>(
                    ".",
                    typeof(Messages.PlaceOrder).FullName);
        }

        public void PlaceOrder(Order order)
        {
            _messageQueue.Send(new Messages.PlaceOrder
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                Lines = order.Lines.Select(l =>
                    new Messages.Line
                    {
                        ProductNumber = l.ProductNumber,
                        Quantity = l.Quantity
                    })
                    .ToList()
            });

            if (_networkError.Next(100) < 20)
                throw new FaultException<FulfillmentNetworkError>(
                    new FulfillmentNetworkError(),
                    "Network error.");
        }

        public Confirmation CheckOrderStatus(Guid orderId)
        {
            var pickLists = _pickListService
                .GetPickLists(orderId);

            if (!pickLists.Any())
                return null;

            return new Confirmation
            {
                Shipments = pickLists
                    .Select(pickList => new Shipment
                    {
                        ProductId = pickList.Product
                            .Id,
                        Quantity = pickList.Quantity,
                        TrackingNumber = "123-456"
                    })
                    .ToList()
            };
        }
    }
}
