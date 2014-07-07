using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;

namespace HostingPsDemo
{
    internal class CustomHostUserInterface : PSHostUserInterface
    {
        private readonly CustomHostRawUserInterface _wixHostRawUserInterface;
        private IWrapper _wrapper;

        public CustomHostUserInterface(IWrapper wrapper)
        {
            _wixHostRawUserInterface = new CustomHostRawUserInterface();
            _wrapper = wrapper;
        }

        public override PSHostRawUserInterface RawUI
        {
            get
            {
                return _wixHostRawUserInterface;
            }
        }

        public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
        {
            throw new NotImplementedException("PromptForChoice");
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            throw new NotImplementedException("PromptForCredential");
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            throw new NotImplementedException("PromptForCredential");
        }

        public override string ReadLine()
        {
            throw new NotImplementedException("ReadLine");
        }

        public override SecureString ReadLineAsSecureString()
        {
            throw new NotImplementedException("ReadLineAsSecureString");
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            _wrapper.Output = value;
        }

        public override void Write(string value)
        {
            _wrapper.Output = value;
        }

        public override void WriteDebugLine(string message)
        {
            _wrapper.Output = "Debug: " + message;
        }

        public override void WriteErrorLine(string value)
        {
            _wrapper.Output = "Error: " + value;
        }

        public override void WriteLine(string value)
        {
            _wrapper.Output = value;
        }

        public override void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
        }

        public override void WriteVerboseLine(string message)
        {
        }

        public override void WriteWarningLine(string message)
        {
        }

        public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
        {
            throw new NotImplementedException("Prompt");
        }
    }
}