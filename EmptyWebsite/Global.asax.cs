using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Routing;
using SignalR.Samples.Raw;
using SignalR;

namespace EmptyWebsite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<Chat>();

                while (true)
                {
                    try
                    {
                        //context.Connection.Broadcast(DateTime.Now.ToString());
                        hubContext.Clients.fromArbitraryCode(DateTime.Now.ToString());
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("SignalR error thrown in Streaming broadcast: {0}", ex);
                    }
                    Thread.Sleep(2000);
                }
            });

            RouteTable.Routes.MapConnection<ChatConnection>("chat", "chat/{*operation}");
//            RouteTable.Routes.MapConnection<Streaming>("streaming", "streaming/{*operation}");
        }
    }
}