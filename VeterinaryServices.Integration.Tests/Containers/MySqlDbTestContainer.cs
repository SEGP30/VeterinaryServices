using System.Threading.Tasks;
using DotNet.Testcontainers.Containers.Builders;
using DotNet.Testcontainers.Containers.Modules;
using Xunit;

namespace VeterinaryServices.Integration.Tests.Containers
{
    public class MySqlDbTestContainer : IAsyncLifetime
    {
        private readonly TestcontainersContainer _localStackContainer;

        public MySqlDbTestContainer()
        {
            var localStackBuilder = new TestcontainersBuilder<TestcontainersContainer>()
                .WithImage("mysql")
                .WithCleanUp(true)
                .WithPortBinding(3307, 3306)
                .WithEnvironment("MYSQL_ROOT_PASSWORD", "3003");
        
            _localStackContainer = localStackBuilder.Build();
        }
    
        public async Task InitializeAsync()
        {
            await _localStackContainer.StartAsync();
        }

        public async Task DisposeAsync()
        {
            await _localStackContainer.StopAsync();
        }
    }
}