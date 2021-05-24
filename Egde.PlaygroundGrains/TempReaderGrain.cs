using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;

namespace Egde.PlaygroundGrains
{
    public class TempReaderGrain : ITempReaderGrain
    {
        public Task Update(string temperature)
        {
            throw new NotImplementedException();
        }
    }
}