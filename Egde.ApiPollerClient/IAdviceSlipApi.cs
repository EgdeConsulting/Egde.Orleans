using System.Threading.Tasks;
using Refit;

namespace Egde.ApiPollerClient
{
    public interface IAdviceSlipApi
    {
        [Get("/advice")]
        Task<Adviceslip> GetRandomAdvice();
    }
}