using System.Threading.Tasks;
using Orleans;

namespace Egde.PlaygroundGrainInterfaces
{
    public interface ITempReaderOrchestratorGrain : IGrainWithIntegerKey
    {
        Task Notify(string identity, string temperature);
    }
}