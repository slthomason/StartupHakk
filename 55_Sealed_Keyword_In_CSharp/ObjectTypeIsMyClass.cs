public class ObjectTypeIsMyClass
{
    private readonly int NumberOfTrials = 10;
    private BaseClass _baseClassObject = new BaseClass();
    
    public bool ObjectTypeIsMyClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            var x = _baseClassObject is MyClass;
        }

        return true;
    }

    public bool ObjectTypeIsMySealedClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            var x = _baseClassObject is MySealedClass;
        }

        return true;
    }
}

//the performance of checking the 
//object type on the sealed class is better than calling it on the non-sealed class.