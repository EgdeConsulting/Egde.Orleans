using System;
using System.Threading.Tasks;
using Egde.ApiPollerClient;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class ApiPullerGrain : Grain, IApiPullerGrain
    {
        private bool _started;
        private readonly IAdviceSlipApi _adviceSlipApi;

        public ApiPullerGrain(IAdviceSlipApi adviceSlipApi)
        {
            _adviceSlipApi = adviceSlipApi;
        }
        public override Task OnActivateAsync()
        {
            _started = false;
            DelayDeactivation(TimeSpan.FromMinutes(int.MaxValue));
            return base.OnActivateAsync();
        }

        public async Task Init()
        {
            if (_started)
            {
                Console.WriteLine("I was started");
                return;
            }
            RegisterTimer(PullApisRegistered, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            _started = true;
            Console.WriteLine("I wasn't started");
        }

        private async Task PullApisRegistered(object _)
        {
            var advice = await _adviceSlipApi.GetRandomAdvice();
            Console.WriteLine(advice.Slip.advice);
        }
    }
}