using System.Threading;

namespace ProgressBar.Processes
{
    public class DoSpendLongTimeThingProcess : BaseProcess
    {
        public DoSpendLongTimeThingProcess(Microsoft.AspNet.SignalR.Hubs.IHubCallerConnectionContext<dynamic> clients) : base(clients)
        {
        }

        protected override string ProcessName => nameof(DoSpendLongTimeThingProcess);

        public override void Begin()
        {
            base.Log("Starting...");

            base.Log("Step 1: XXXXX");
            Thread.Sleep(1000);

            base.Log("Step 2: ASDFX");
            Thread.Sleep(4000);

            base.Log("Step 3: HAHAHAHA");
            Thread.Sleep(3000);

            base.Finish();
            base.Log("Finished!");
        }
    }
}