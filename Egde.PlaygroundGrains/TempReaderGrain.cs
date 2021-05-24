using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class TempReaderGrain : Grain, ITempReaderGrain
    {
        public new virtual IGrainFactory GrainFactory => base.GrainFactory;

        public async Task<string> Update(string temperature)
        {
            var orchestratorGrain = GrainFactory.GetGrain<ITempReaderOrchestratorGrain>(0);
            await orchestratorGrain.Notify(this.GetPrimaryKeyString(), temperature);
            return $"Got a temperature reading of: [{temperature}] !";
        }
    }
}