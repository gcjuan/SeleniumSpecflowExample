using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleSpecFlowProject.StepDefinitions
{
	[Binding]
	public sealed class Hooks
	{
		private readonly IObjectContainer _objectContainer;
		private readonly IWebDriver _webDriver;

		public Hooks(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
			_webDriver = new ChromeDriver();
		}

		[BeforeScenario(Order = 1)]
		public void BeforeScenario()
		{
			_objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
		}

		[AfterScenario]
		public void AfterScenario()
		{
			_webDriver.Close();
			_webDriver.Dispose();
		}
	}
}