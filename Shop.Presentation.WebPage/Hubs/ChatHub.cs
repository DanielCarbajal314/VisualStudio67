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

        public void EnviarMensajeComoUsuario(MensajeDeUsuario mensaje)
        {
            Clients.All.NuevoMensajeDelUsuario(mensaje);
        }
    }

    public class MensajeDeUsuario {
        public string Usuario { get; set; }
        public string Mensaje { get; set; }
    }
}