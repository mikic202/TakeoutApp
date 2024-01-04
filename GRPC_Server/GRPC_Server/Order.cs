using Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server
{
    internal class Order
    {
        public int Id { get; set; }
        public int restaurantId { get; set; }

        public int userId { get; set; }

        public DateTime date { get; set; }  

        public float latitude {  get; set; }
        public float longitude { get; set; }

        public void fillWithProtoOrder(ProtoOrder order)
        {
            restaurantId = order.RestaurantId; userId = order.UserId;
            latitude = order.DeliveryLocation.Latitude; longitude = order.DeliveryLocation.Longitude;
            //date = order.orderDate;
        }
    }
}
