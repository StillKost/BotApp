using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Timers;
using BotApp.Models;
using DSharpPlus;
using DSharpPlus.EventArgs;
using BotApp.Core;

namespace BotApp.Controllers
{
    public class WatcherController
    {
        public List<SiteStatus> GetSitesStatus(List<string> sites, TimeSpan timeout)
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

        public async void SetWatcher(object sender, EventArgs e)
        {
            var instance = new Instance().CreateInstance();
            instance.ConnectAsync();
            
            var guild = await instance.GetGuildAsync(497731455653380097);
            var channel = await instance.GetChannelAsync(497731455653380099);
            var result = GetSitesStatus(new List<string>() { "https://www.google.com/" }, TimeSpan.FromSeconds(5));
            foreach (var status in result)
            {
                if (status.HttpStatusCode != HttpStatusCode.OK)
                {
                    channel.SendMessageAsync($"Сайт: {status.URL}, Код ошибки: {status.HttpStatusCode}, текст ошибки: {status.ResultMessage}");
                }
            }
        }
    }
}
