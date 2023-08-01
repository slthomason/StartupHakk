public class CallingNonVirtualMethodOnMyClass
{
    private readonly int NumberOfTrials = 10;
    private BaseClass _baseClassObject = new BaseClass();
    private MyClass _myClassObject = new MyClass();
    private MySealedClass _mySealedClassObject = new MySealedClass();
    private MyClass[] _myClassObjectsArray = new MyClass[1];
    private MySealedClass[] _mySealedClassObjectsArray = new MySealedClass[1];

    public void CallingNonVirtualMethodOnMyClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _myClassObject.DoSomethingElse();
        }
    }

    public void CallingNonVirtualMethodOnMySealedClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _mySealedClassObject.DoSomethingElse();
        }
    }
}

//the performance of calling the non-virtual
// method on the sealed class is better than calling it on the non-sealed class.