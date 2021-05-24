using System;
using System.Threading.Tasks;
using Orleans;

namespace Egde.PlaygroundGrainInterfaces
{
    public interface ITempReaderGrain : IGrainWithStringKey
    {
        Task Update(string temperature);
    }
}