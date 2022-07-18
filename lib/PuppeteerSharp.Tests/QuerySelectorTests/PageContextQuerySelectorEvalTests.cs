using System.Threading.Tasks;
using PuppeteerSharp.Tests.Attributes;
using Xunit;
using Xunit.Abstractions;

namespace PuppeteerSharp.Tests.QuerySelectorTests
{
    [Collection(TestConstants.TestFixtureCollectionName)]
    public class PageContextQuerySelectorEvalTests : DevToolsContextBaseTest
    {
        public PageContextQuerySelectorEvalTests(ITestOutputHelper output) : base(output)
        {
        }

        [PuppeteerFact]
        public async Task ShouldWork()
        {
            await DevToolsContext.SetContentAsync("<section id='testAttribute'>43543</section>");
            var idAttribute = await DevToolsContext.QuerySelectorAsync("section").EvaluateFunctionAsync<string>("e => e.id");
            Assert.Equal("testAttribute", idAttribute);
        }

        [PuppeteerFact]
        public async Task ShouldWorkWithAwaitedElements()
        {
            await DevToolsContext.SetContentAsync("<section id='testAttribute'>43543</section>");
            var section = await DevToolsContext.QuerySelectorAsync("section");
            var idAttribute = await section.EvaluateFunctionAsync<string>("e => e.id");
            Assert.Equal("testAttribute", idAttribute);
        }

        [PuppeteerFact]
        public async Task ShouldAcceptArguments()
        {
            await DevToolsContext.SetContentAsync("<section>hello</section>");
            var text = await DevToolsContext.QuerySelectorAsync("section").EvaluateFunctionAsync<string>("(e, suffix) => e.textContent + suffix", " world!");
            Assert.Equal("hello world!", text);
        }

        [PuppeteerFact]
        public async Task ShouldAcceptElementHandlesAsArguments()
        {
            await DevToolsContext.SetContentAsync("<section>hello</section><div> world</div>");
            var divHandle = await DevToolsContext.QuerySelectorAsync("div");
            var text = await DevToolsContext.QuerySelectorAsync("section").EvaluateFunctionAsync<string>("(e, div) => e.textContent + div.textContent", divHandle);
            Assert.Equal("hello world", text);
        }

        [PuppeteerFact]
        public async Task ShouldThrowErrorIfNoElementIsFound()
        {
            var exception = await Assert.ThrowsAsync<SelectorException>(()
                => DevToolsContext.QuerySelectorAsync("section").EvaluateFunctionAsync<string>("e => e.id"));
            Assert.Contains("failed to find element matching selector", exception.Message);
        }
    }
}
