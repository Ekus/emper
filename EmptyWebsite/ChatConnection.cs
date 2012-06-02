using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;
using System.Threading.Tasks;
using SignalR.Hosting;
 

namespace EmptyWebsite
{
    public class ChatConnection : PersistentConnection
    {
       
        protected override Task OnReceivedAsync(IRequest request, string connectionId, string data)
        {
            // Broadcast data to all clients
            return Connection.Broadcast(data);
        }

    }

}