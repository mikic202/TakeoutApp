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

        public float latitude {  get; set; }
        public float longitude { get; set; }
    }
}
