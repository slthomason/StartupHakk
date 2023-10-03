//Unit Test Class

 [Fact]
 public async Task GetExistsAsync_WithCustomerIdOne_ReturnsTrue()
 {
     //Arrange
     var customerId = 1;
     //Act
     var result = await _customerService.GetExistsAsync(customerId);
     //Assert
     Assert.True(result);
 }



//Boolean
Assert.True(customer.IsNew);

Assert.False(customer.IsNew);

//Strings
//Equals
Assert.Equal("John", customer.FirstName, ignoreCase:true);

//StartsWith
Assert.StartsWith(customer.FirstName, customer.FullName);

//EndsWith
Assert.EndsWith(customer.LastName, customer.FullName);

//Numeric Values
// We can use equal and notequal also on numeric values.
Assert.Equal(2, customer.Products);
Assert.NotEqual(3, customer.Products);

// We can also check, if something is in a range
Assert.True(customer.Invoice => 2000 && customer.Invoice <= 2500);

// The better way is to use 
Assert.InRange(customer.Invoice, 2000, 2500);

//Floating Values:
var customer = new Customer("John", "Doe");
customer.Invoice = 2200.12m;

// We can also use Equal, NotEqual and InRange for floating values

//Arrays & Collections


var customer = new Customer("John", "Doe");

// We can use contains to check if a customer is in a IEnumerable
Assert.Contains(customer, newlyCreatedCustomers);

// Or wen can even check if two IEnumerable's are equal
var actual = new List<Customer>() {customer};
Assert.Equals(actual, newlyCreatedCustomers) 

// If you want to check all items in a list
// you can use Assert.All, which runs through every item in an IEnumerable
Assert.All(newlyCreatedCustomers, cus => Assert.True(cus.IsNew));

//Asynchronous Code

// This is quite easy
// Lets assume we have a Method GetCustomerAsync
// Just change the signature of your test method from void to async Task
// and await tested method

[Fact]
public async Task GetCustomerAsync_WithCustomerIdOne_ReturnsCustomerOne()
{
    var customerId = 1;

    var result = await _customerService.GetCustomerAsync(customerId);

    Assert.Equal(customerId, result.Id);
}

//Exceptions:

// Act & Assert

await Assert.ThrowsAsync<NotImplementedExpcetion>(async () => 
await _customerService.GetExceptionAsync());



//Mocking
public CustomerServiceTests()
{
    var customerSeedDataFixture = new CustomerSeedDataFixture();

    //Creating a Mock of the typ ILoggerFactory
    Mock<Microsoft.Extensions.Logging.ILoggerFactory> loggerFactory = new();
    //Setting the CreateLogger method up, so it will always Returns a Mock of a Logger.
    loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new Mock<ILogger<ICustomerService>>().Object);

    _customerService = new CustomerService(customerSeedDataFixture.DbContext, loggerFactory.Object);
}