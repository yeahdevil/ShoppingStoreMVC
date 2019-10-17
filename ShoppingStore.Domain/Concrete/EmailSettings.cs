using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "deepakmittalsmk@gmail.com";
        public string MailFromAddress = "dmittal2715.ca17@gmail.com";
        public bool UseSsl = true;
        public string Username = "dmittal2715.ca17@chitkara.edu.in";
        public string Password = "Mittal12147"; 
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
