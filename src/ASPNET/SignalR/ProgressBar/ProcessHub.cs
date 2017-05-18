using Microsoft.AspNet.SignalR;
using ProgressBar.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressBar
{
    public class ProcessHub : Hub
    {
        private static List<BaseProcess> processes = new List<BaseProcess>();

        public void Begin()
        {
            if (processes.Count == 0)
            {
                Clients.Client(Context.ConnectionId).log("Init...");

                processes = new List<BaseProcess>
                {
                    new DoSomethingProcess(Clients),
                    new DoOtherThingProcess(Clients)
                };

                // TODO Some bugs here
                processes.ForEach(i => i.Begin());
            }
            else
            {
                Clients.Client(Context.ConnectionId).pull();
            }
        }

        public void GetProgress(string processName)
        {
            Clients.Client(Context.ConnectionId).refreshProgress(new
            {
                Total = processes.Count,
                TotalSuccess = processes.Count(p => p.IsSuccess),
                Timestamp = DateTime.Now.ToString("HH:mm:ss.fff"),
                Context.ConnectionId,
                processName
            });
        }
    }
}