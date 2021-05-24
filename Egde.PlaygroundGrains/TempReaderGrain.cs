using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class TempReaderGrain : Grain, ITempReaderGrain
    {
        public Task Update(string temperature)
        {
            throw new NotImplementedException();
        }
    }
}