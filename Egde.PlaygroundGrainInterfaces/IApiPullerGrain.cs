using System.Threading.Tasks;
using Orleans;

namespace Egde.PlaygroundGrainInterfaces
{
    public interface IApiPullerGrain : IGrainWithIntegerKey
    {
        Task Init();
    }
}