﻿namespace StarterKit.Service
{
    using Autofac;
    using MassTransit;
    using MassTransit.Util;
    using Topshelf;
    using Topshelf.Logging;

    public class MyService : ServiceControl
    {
        readonly LogWriter _log = HostLogger.Get<MyService>();

        IBusControl _busControl;
        BusHandle _busHandle;

        public MyService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public bool Start(HostControl hostControl)
        {
            _log.Info("Starting bus...");

            _busHandle = TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _log.Info("Stopping bus...");

            if (_busHandle != null)
                _busHandle.Stop();

            return true;
        }
    }
}