using Microsoft.AspNet.SignalR.Hubs;
using System.Threading;
using System;

namespace ProgressBar.Processes
{
    public class DoOtherThingProcess : BaseProcess
    {
        public DoOtherThingProcess(IHubCallerConnectionContext<dynamic> clients) : base(clients)
        {
        }

        protected override string ProcessName => nameof(DoOtherThingProcess);

        public override void Begin()
        {
            base.Log("Start to do other thing...");

            Thread.Sleep(4000);

            base.Finish();
            base.Log("Finish do other thing!");
        }
    }
}