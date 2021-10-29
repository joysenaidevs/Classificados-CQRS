using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum
{
    /// <summary>
    /// Super Classe da minha API
    /// </summary>
    public abstract class Base : Notifiable<Notification>
    {

        //quando a classe for instaciada ela vai gerar automaticamente
        // Um Guid e a data do sistema, para isso geramos um método construtor
        public Base()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }



        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
