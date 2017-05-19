using Microsoft.AspNet.SignalR.Hubs;
using System.Threading;

namespace ProgressBar.Processes
{
    public class DoSomethingProcess : BaseProcess
    {
        public DoSomethingProcess(IHubCallerConnectionContext<dynamic> clients) : base(clients)
        {
        }

        protected override string ProcessName => nameof(DoSomethingProcess);

        public override void Begin()
        {
            base.Log("Starting...");

            Thread.Sleep(2000);

            base.Finish();
            base.Log("Finished!");
        }
    }
}