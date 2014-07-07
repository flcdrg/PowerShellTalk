using System;
using System.Globalization;
using System.Management.Automation.Host;
using System.Threading;

namespace HostingPsDemo
{
    internal class CustomHost : PSHost
    {
        private readonly Guid _guid;
        private readonly PSHostUserInterface _wixHostUserInterface;

        public CustomHost(IWrapper wrapper)
        {
            _wixHostUserInterface = new CustomHostUserInterface(wrapper);
            _guid = Guid.NewGuid();
        }

        public override string Name
        {
            get
            {
                return "CustomHost";
            }
        }

        public override PSHostUserInterface UI
        {
            get
            {
                return _wixHostUserInterface;
            }
        }

        public override CultureInfo CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture;
            }
        }

        public override CultureInfo CurrentUICulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
        }

        public override Guid InstanceId
        {
            get
            {
                return _guid;
            }
        }

        public override Version Version
        {
            get
            {
                return new Version(1, 0, 0, 0);
            }
        }

        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException("EnterNestedPrompt");
        }

        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException("ExitNestedPrompt");
        }

        public override void NotifyBeginApplication()
        {
        }

        public override void NotifyEndApplication()
        {
        }

        public override void SetShouldExit(int exitCode)
        {
        }
    }
}