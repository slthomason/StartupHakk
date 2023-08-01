public class CallingVirtualMethodOnMyClass
{
    private readonly int NumberOfTrials = 10;
    private MyClass _myClassObject = new MyClass();
    private MySealedClass _mySealedClassObject = new MySealedClass();

    public void CallingVirtualMethodOnMyClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _myClassObject.DoSomething();
        }
    }

    public void CallingVirtualMethodOnMySealedClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _mySealedClassObject.DoSomething();
        }
    }
}
// the performance of calling the 
//virtual method on the sealed class is much better than calling it on the non-sealed class.