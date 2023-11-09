//Define the Specification Interface

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}

//Create Concrete Specifications
public class CustomerIsPremiumSpecification : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer customer)
    {
        return customer.IsPremium;
    }
}

public class OrderIsOver100Specification : ISpecification<Order>
{
    public bool IsSatisfiedBy(Order order)
    {
        return order.TotalAmount > 100;
    }
}

//Combine Specifications

public class AndSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
    }
}

//Applying Specifications

var premiumCustomerSpecification = new CustomerIsPremiumSpecification();
var over100OrderSpecification = new OrderIsOver100Specification();

var premiumAndOver100 = new AndSpecification<Customer>(
    premiumCustomerSpecification,
    over100OrderSpecification
);

var filteredCustomers = customers.Where(premiumAndOver100.IsSatisfiedBy);

