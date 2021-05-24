using System;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Egde.PlaygroundGrains;
using Orleans;
using Xunit;
using Moq;
using Orleans.TestKit;

namespace Egde.SiloTests
{
    public class TempReaderGrainMoqTest : TestKitBase
    {
        [Fact]
        public async Task RecordsMessageInJournal()
        {
            var pong = Silo.AddProbe<ITempReaderOrchestratorGrain>(0);
            var tempReaderGrain = await Silo.CreateGrainAsync<TempReaderGrain>("test-adr");
            tempReaderGrain.Update("2");
            pong.Verify(x => x.Notify(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}