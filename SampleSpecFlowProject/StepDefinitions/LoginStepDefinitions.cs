using NUnit.Framework;
using OpenQA.Selenium;
using SampleSpecFlowProject.Pages;

namespace SampleSpecFlowProject.StepDefinitions
{
	[Binding]
	public sealed class LoginStepDefinitions
	{
		private readonly IWebDriver _webDriver;
		private readonly LoginPage _loginPage;

		public LoginStepDefinitions(IWebDriver webDriver)
		{
			_webDriver = webDriver;
			_loginPage = new LoginPage(_webDriver);
		}

		[Given(@"I go to the site '([^']*)'")]
		public void GivenIGoToTheSite(string url)
		{
			_webDriver.Navigate().GoToUrl(url);
		}

		[Given(@"I the username '([^']*)' with password '([^']*)'")]
		public void GivenITheUsernameWithPassword(string username, string password)
		{
			_loginPage.FillInUserNameAndPassword(username, password);
		}

		[When(@"I click the submit button")]
		public void WhenIClickTheSubmitButton()
		{
			_loginPage.ClickSubmit();
		}

		[Then(@"I should login successfully")]
		public void ThenIShouldLoginSuccessfully()
		{
			Assert.AreEqual("Logged In Successfully", _loginPage.GetPageTitle());
		}

		[Then(@"the error '([^']*)' is displayed")]
		public void ThenTheErrorIsDisplayed(string error)
		{
			Assert.AreEqual(error, _loginPage.GetPageError());
		}
	}
}