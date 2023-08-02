//Inline Object to Object Mapper

public class ObjectToObjectTests
{
    [Benchmark]
    public void Inline()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = new PaymentEntity()
        {
            Amount = payment.Amount,
            Created = payment.Created,
            Id = payment.Id,
            Status = payment.Status
        };
    }
}


//Reflection
public class ObjectToObjectTests
{  
    public void Reflection()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = ReflectionMapper.MapObjects<Payment, PaymentEntity>(payment);
    }
}

public static class ReflectionMapper
{
    public static TTo MapObjects<TFrom, TTo>(TFrom sourceObject) where TTo : new()
    {
        TTo targetObject = new TTo();
        Type sourceType = sourceObject.GetType();
        PropertyInfo[] sourceProperties = sourceType.GetProperties();
        PropertyInfo[] targetProperties = typeof(TTo).GetProperties();

        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            PropertyInfo targetProperty = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
            if (targetProperty != null && targetProperty.CanWrite)
            {
                object value = sourceProperty.GetValue(sourceObject);
                targetProperty.SetValue(targetObject, value);
            }
        }

        return targetObject;
    }
}


//AutoMapper

public class ObjectToObjectTests
{
    private readonly AutoMapper.Mapper _autoMapper;
    public ObjectToObjectTests()
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentEntity>());
        _autoMapper = new AutoMapper.Mapper(config);
    }

    [Benchmark]
    public void AutoMapper()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = _autoMapper.Map<PaymentEntity>(payment);
    }
}

//TinyMapper

public class ObjectToObjectTests
{
    public ObjectToObjectTests()
    {
        TinyMapper.Bind<Payment, PaymentEntity>();
    }

    [Benchmark]
    public void TinyMapperTest()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = TinyMapper.Map<PaymentEntity>(payment);
    }
}

//Mapster
public class ObjectToObjectTests
{
    [Benchmark]
    public void Mapster()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = payment.Adapt<PaymentEntity>();
    }
}

//ValueInjector

public class ObjectToObjectTests
{
    [Benchmark]
    public void ValueInjecter()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = Omu.ValueInjecter.Mapper.Map<PaymentEntity>(payment);
    }
}

//FastMapper

public class ObjectToObjectTests
{
    [Benchmark]
    public void FastMapper()
    {
        var payment = new Payment()
        {
            Amount = 120,
            Created = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Status = "Created"
        };
        var paymentEntity = TypeAdapter.Adapt<Payment, PaymentEntity>(payment);
    }
}