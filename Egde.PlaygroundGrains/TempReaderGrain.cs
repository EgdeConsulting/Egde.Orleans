using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class TempReaderGrain : Grain, ITempReaderGrain
    {
        public Task<string> Update(string temperature)
        {
            return Task.FromResult($"Got a temperature reading of: [{temperature}] !");
        }
    }
}