using FluentAssertions;
using Gherkin;
using TechTalk.SpecFlow;
using VeterinaryServices.Domain.Entities;
using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Domain.Tests.Steps
{
    [Binding]
    public class AestheticServiceSteps
    {
        private AestheticService _aestheticService;
    
        [Given(@"a new aesthetic service")]
        public void GivenANewAestheticService()
        {
            _aestheticService = new AestheticService();
        }

        [When(@"input is registered")]
        public void WhenInputIsRegistered()
        {
            var pet = new Pet();
            var doctor = new Doctor();
            _aestheticService.Input(pet, doctor);
        }

        [When(@"the aesthetic service is started")]
        public void WhenTheAestheticServiceIsStarted()
        {
            _aestheticService.Start();
        }
        
        [When(@"the aesthetic service is output")]
        public void WhenTheAestheticServiceIsOutput()
        {
            _aestheticService.Output();
        }
        
        [When(@"the aesthetic service is canceled")]
        public void WhenTheAestheticServiceIsCanceled()
        {
            _aestheticService.Cancel();
        }
        
        [Then(@"aesthetic service state should be (.*)")]
        public void ThenAestheticServiceStateShouldBe(int stateExpected)
        {
            _aestheticService.State.Should().Be((AestheticServiceState) stateExpected);
        }

    }
}

