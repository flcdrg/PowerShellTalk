using System.Management.Automation.Runspaces;

namespace HostingPsDemo
{
    public class Runner
    {
        private Pipeline _pipeline;
        private IWrapper _wrapper;

        public Runner(IWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void Execute(string script)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace(new CustomHost(_wrapper));

            _pipeline = runspace.CreatePipeline();
            _pipeline.Commands.AddScript(script);
            _pipeline.Runspace.Open();
            _pipeline.Runspace.SessionStateProxy.SetVariable("Form", _wrapper);

            _pipeline.StateChanged += _pipeline_StateChanged;
            _pipeline.InvokeAsync();
        }

        void _pipeline_StateChanged(object sender, PipelineStateEventArgs e)
        {
            if (e.PipelineStateInfo.State == PipelineState.Completed || e.PipelineStateInfo.State == PipelineState.Failed || e.PipelineStateInfo.State == PipelineState.Stopped)
            {
                _pipeline.Dispose();
            }
        }
    }
}