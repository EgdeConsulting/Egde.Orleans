using System;
using System.Threading.Tasks;

namespace Egde.PlaygroundGrainInterfaces
{
    public interface ITempReaderGrain
    {
        Task Update(string temperature);
    }
}