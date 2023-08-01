public class BaseClass
{
    public virtual void DoSomething()
    {
    }

    public void DoSomethingElse()
    {
    }
}

public class MyClass : BaseClass
{
    public override void DoSomething()
    {
    }
}

public sealed class MySealedClass : BaseClass
{
    public override void DoSomething()
    {
    }
}