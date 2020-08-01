using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Timers;
using BotApp.Models;

namespace BotApp.Controllers
{
    public class WatcherController
    {
        public List<SiteStatus> Get(List<string> sites, TimeSpan timeout)
        {
            var sitesStatus = new List<SiteStatus>();
            var client = new HttpClient();
            client.Timeout = timeout == null ? TimeSpan.FromSeconds(5) : timeout;


            foreach (var url in sites)
            {
                var newSite = new SiteStatus()
                {
                    URL = url
                };

                var task = client.GetAsync(newSite.URL);

                try
                {
                    var result = task.Result;
                    newSite.HttpStatusCode = result.StatusCode;
                    newSite.ResultMessage = result.ReasonPhrase;
                }
                catch (Exception ex)
                {
                    newSite.HttpStatusCode = HttpStatusCode.InternalServerError;
                    newSite.ResultMessage = ex.Message;
                }
                sitesStatus.Add(newSite);
            }
            return sitesStatus;
        }
    }
}
