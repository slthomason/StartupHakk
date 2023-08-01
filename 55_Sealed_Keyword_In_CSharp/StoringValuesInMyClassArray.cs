public class StoringValuesInMyClassArray
{
    private readonly int NumberOfTrials = 10;
    private MyClass _myClassObject = new MyClass();
    private MySealedClass _mySealedClassObject = new MySealedClass();
    private MyClass[] _myClassObjectsArray = new MyClass[1];
    private MySealedClass[] _mySealedClassObjectsArray = new MySealedClass[1];

    public void StoringValuesInMyClassArray()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _myClassObjectsArray[0] = _myClassObject;
        }
    }

    public void StoringValuesInMySealedClassArray()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            _mySealedClassObjectsArray[0] = _mySealedClassObject;
        }
    }
}

//the performance of storing an object in an array on 
//the sealed class is better than calling it on the non-sealed class.


public class A {}
public class B : A {}


A[] arrayOfA = new B[5];


arrayOfA[0] = new B();
