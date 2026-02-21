using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers;

public class HelloWorldController : Controller
{
    public string Text()
    {
        // use localhost:{PORT}/HelloWorld/Text to check its functionality; *{PORT} should be replaced with the port number*
        return "This is my default action...";
    }

    public string WelcomeText()
    {
        // use localhost:{PORT}/HelloWorld/WelcomeText to check its functionality; *{PORT} should be replaced with the port number*
        return "This is the Welcome action method...";
    }

    [Route("HelloWorld/Welcome")]
    public string Welcome(string firstName, string secondName)
    {
        // use localhost:{PORT}/HelloWorld/Welcome?firstName=Rick&secondName=Morty to check its functionality; *{PORT} should be replaced with the port number*
        return HtmlEncoder.Default.Encode($"Hello {firstName} and {secondName}");
    }

    [Route("HelloWorld/Welcome/{id}")]
    public string Welcome(string name, int id)
    {
        // use localhost:{PORT}/HelloWorld/Welcome/3?name=Rick to check its functionality; *{PORT} should be replaced with the port number*
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {id}");
    }

    public IActionResult Index()
    {
        return View();
    }
}
