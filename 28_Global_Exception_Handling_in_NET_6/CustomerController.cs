using ExceptionHandling.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult GetCustomers()
    {
        
        _logger.LogInformation("Getting customer details");

        var result = _customerService.GetCustomers();
        if (result.Count == 0)
            throw new ApplicationException("Invalid Token");

        return Ok(result);
        
    }
}  