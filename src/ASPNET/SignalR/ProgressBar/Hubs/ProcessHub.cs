using Microsoft.AspNet.SignalR;
using ProgressBar.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressBar.Hubs
{
    public class ProcessHub : Hub
    {
        public static List<BaseProcess> processes = new List<BaseProcess>();

        public void Begin()
        {
            if (processes.Count == 0)
            {
                Clients.Caller.log("Init...");

                processes = new List<BaseProcess>
                {
                    new DoSomethingProcess(Clients),
                    new DoSpendLongTimeThingProcess(Clients),
                    new DoOtherThingProcess(Clients),
                    new DoSomethingProcess(Clients),
                    new DoSpendLongTimeThingProcess(Clients),
                    new DoSomethingProcess(Clients),
                    new DoOtherThingProcess(Clients)
                };

                Clients.Caller.pull();

                Task.Factory.StartNew(() =>
                {
                    processes.ForEach(i => i.Begin());
                });
            }
            else
            {
                Clients.Caller.log("Alerady started.");
                Clients.Caller.log("Waiting to get the latest progress.");
                Clients.Caller.pull();
            }
        }

        public void GetProgress()
        {
            var total = processes.Count;
            var successed = processes.Count(p => p.IsSuccess);
            var isAllSuccessed = total == successed;

            Clients.Caller.refreshProgress(new
            {
                total,
                successed,
                isAllSuccessed,
                progress = Math.Round((double)successed / total, 2) * 100
            });

            if (isAllSuccessed)
            {
                Clients.Caller.log("All done!");
            }
        }
    }
}