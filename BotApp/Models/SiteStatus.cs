using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BotApp.Models
{
    public class SiteStatus
    {
        public string URL { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
