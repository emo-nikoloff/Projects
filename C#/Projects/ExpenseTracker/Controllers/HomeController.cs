using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Data;

namespace ExpenseTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExpensesDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        List<Expense> allExpenses = _context.Expenses.ToList();

        decimal totalExpenses = allExpenses.Sum(e => e.Value);

        ViewBag.Expenses = totalExpenses;

        return View(allExpenses);
    }

    public IActionResult CreateEditExpense(int? id)
    {
        if (id != null)
        {
            // editing -> load an expense by id
            Expense expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
            return View(expense);
        }

        return View();
    }

    public IActionResult DeleteExpense(int id)
    {
        Expense expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
        _context.Remove(expense);
        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if (model.Id == 0)
        {
            // Creating
            _context.Expenses.Add(model);
        }
        else
        {
            // Editing
            _context.Update(model);
        }

        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
