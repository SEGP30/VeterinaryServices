using System;
using System.Threading.Tasks;
using DotNet.Testcontainers.Containers.Modules.Databases;
using TechTalk.SpecFlow;
using VeterinaryServices.Integration.Tests.Containers;

namespace VeterinaryServices.Integration.Tests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        
        private static MySqlDbTestContainer? _localStackTestContainer;

        private static MySqlDbTestContainer LocalStackTestContainer =>
            _localStackTestContainer ??= new MySqlDbTestContainer();
        
        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            await LocalStackTestContainer.InitializeAsync();
        }
        
        [AfterTestRun]
        public static async Task AfterTestRun()
        {
            await LocalStackTestContainer.DisposeAsync();
        }

    }
}