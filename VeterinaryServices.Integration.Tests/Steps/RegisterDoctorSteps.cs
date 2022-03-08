using TechTalk.SpecFlow;

namespace VeterinaryServices.Integration.Tests.Steps
{
    [Binding]
    public class RegisterDoctorSteps
    {
        [Given(@"a request for register with name ""(.*)"", surnames ""(.*)"", telephone number ""(.*)"", address ""(.*)"", gender (.*) and age (.*)")]
        public void GivenARequestForRegisterWithNameSurnamesTelephoneNumberAddressGenderAndAge(string sebastian, string p1, string p2, string p3, int p4, int p5)
        {
            ScenarioContext.StepIsPending();
        }
    }
}