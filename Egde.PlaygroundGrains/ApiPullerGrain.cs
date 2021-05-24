using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans;

namespace Egde.PlaygroundGrains
{
    public class ApiPullerGrain : Grain, IApiPullerGrain
    {
        private bool _started;

        public override Task OnActivateAsync()
        {
            _started = false;
            DelayDeactivation(TimeSpan.FromMinutes(int.MaxValue));
            return base.OnActivateAsync();
        }

        public Task Init()
        {
            if (_started)
            {
                Console.WriteLine("I was started");
                return Task.CompletedTask;
            }
            _started = true;
            Console.WriteLine("I wasn't started");
            return Task.CompletedTask;
        }
    }
}