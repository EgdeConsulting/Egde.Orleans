using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class TempReaderOrchestratorGrain : Grain, ITempReaderOrchestratorGrain
    {
        private int _numberOfReads;

        public override Task OnActivateAsync()
        {
            _numberOfReads = 0;
            return base.OnActivateAsync();
        }

        public Task Notify(string identity, string temperature)
        {
            _numberOfReads = _numberOfReads++;
            return Task.CompletedTask;
        }
    }
}