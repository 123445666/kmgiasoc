using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace kmgiasoc.Deals
{
    public class DealAppServiceTests : kmgiasocApplicationTestBase
    {
        private readonly IDealAppService _dealAppService;

        public DealAppServiceTests()
        {
            _dealAppService = GetRequiredService<IDealAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
