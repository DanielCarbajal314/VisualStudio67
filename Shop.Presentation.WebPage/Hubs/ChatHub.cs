using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Presentation.WebPage.Hubs
{
    public class ChatHub : Hub
    {
        public void EnviarMensaje(string mensaje)
        {
            Clients.All.NuevoMensaje(mensaje);
        }
    }
}