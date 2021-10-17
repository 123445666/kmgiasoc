using System;
using System.Threading.Tasks;
using kmgiasoc.Deals;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace kmgiasoc.EntityFrameworkCore.Deals
{
    public class DealRepositoryTests : kmgiasocEntityFrameworkCoreTestBase
    {
        private readonly IDealRepository _dealRepository;

        public DealRepositoryTests()
        {
            _dealRepository = GetRequiredService<IDealRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
