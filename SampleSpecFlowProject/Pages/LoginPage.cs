using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SampleSpecFlowProject.Pages;

public class LoginPage
{
	private readonly IWebDriver _webDriver;
	private IWebElement UserName => _webDriver.FindElement(By.Id("username"));
	private IWebElement Password => _webDriver.FindElement(By.Id("password"));
	private IWebElement SubmitButton => _webDriver.FindElement(By.Id("submit"));
	private IWebElement Title => _webDriver.FindElement(By.ClassName("post-title"));
	private IWebElement Error => _webDriver.FindElement(By.Id("error"));

	public LoginPage(IWebDriver webDriver)
	{
		_webDriver = webDriver;
	}

	public void FillInUserNameAndPassword(string userName, string password)
	{
		UserName.SendKeys(userName);
		Password.SendKeys(password);
	}

	public void ClickSubmit()
	{
		SubmitButton.Click();
	}

	public string GetPageTitle()
	{
		return Title.Text;
	}

	public string GetPageError()
	{
		var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
		wait.Until(ExpectedConditions.ElementExists(By.Id("error")));
		return Error.Text;
	}
}