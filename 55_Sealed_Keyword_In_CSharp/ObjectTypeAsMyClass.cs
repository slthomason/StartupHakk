public class ObjectTypeAsMyClass
{
    private readonly int NumberOfTrials = 10;
    private BaseClass _baseClassObject = new BaseClass();
    
    public void ObjectTypeAsMyClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            var x = _baseClassObject as MyClass;
        }
    }

    public void ObjectTypeAsMySealedClass()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            var x = _baseClassObject as MySealedClass;
        }
    }
}

//the performance of casting the object 
//on the sealed class is better than calling it on the non-sealed class.