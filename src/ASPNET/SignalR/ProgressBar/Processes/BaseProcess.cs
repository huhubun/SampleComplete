using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace ProgressBar.Processes
{
    public abstract class BaseProcess
    {
        protected IHubCallerConnectionContext<dynamic> _clients;

        public BaseProcess(IHubCallerConnectionContext<dynamic> clients)
        {
            _clients = clients;
        }

        public abstract void Begin();

        protected void Finish()
        {
            IsSuccess = true;
            _clients.All.pull(ProcessName);
        }

        protected void Log(string message)
        {
            _clients.All.log($"[{DateTime.Now.ToString("HH:mm:ss")}] {ProcessName}: {message}");
        }

        public bool IsSuccess { get; private set; }

        protected abstract string ProcessName { get; }
    }
}