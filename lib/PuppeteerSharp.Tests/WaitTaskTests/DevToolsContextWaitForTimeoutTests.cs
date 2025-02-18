using System;
using System.Threading.Tasks;
using PuppeteerSharp.Tests.Attributes;
using PuppeteerSharp.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace PuppeteerSharp.Tests.WaitForTests
{
    [Collection(TestConstants.TestFixtureCollectionName)]
    public class DevToolsContextWaitForTimeoutTests : DevToolsContextBaseTest
    {
        public DevToolsContextWaitForTimeoutTests(ITestOutputHelper output) : base(output)
        {
        }

        [PuppeteerTest("waittask.spec.ts", "Page.waitForTimeout", "waits for the given timeout before resolving")]
        [PuppeteerFact]
        public async Task WaitsForTheGivenTimeoutBeforeResolving()
        {
            await DevToolsContext.GoToAsync(TestConstants.EmptyPage);
            var startTime = DateTime.Now;
            await DevToolsContext.WaitForTimeoutAsync(1000);
            Assert.True((DateTime.Now - startTime).TotalMilliseconds > 700);
            Assert.True((DateTime.Now - startTime).TotalMilliseconds < 1300);
        }
    }
}
