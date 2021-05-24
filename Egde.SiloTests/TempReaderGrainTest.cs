using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Orleans.TestingHost;
using Xunit;

namespace Egde.SiloTests
{
    public class TempReaderGrainTest
    {
        [Fact]
        public async Task SaysHelloCorrectly()
        {
            var builder = new TestClusterBuilder();
            builder.Options.ServiceId = Guid.NewGuid().ToString();
            var cluster = builder.Build();
            cluster.Deploy();
            var hello = cluster.GrainFactory.GetGrain<ITempReaderGrain>("SomeString");
            var greeting = await hello.Update("1c");

            await cluster.StopAllSilosAsync();

            Assert.Equal("Got a temperature reading of: [1c] !", greeting);
        }
    }
}