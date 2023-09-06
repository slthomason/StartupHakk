string stringValue = "Value from a string";
int answer = 42;
    
object customProps = new
    {
        property1 = "something",
        name = "Bob",
        magicNumber = answer,
        favoriteString = stringValue
    };


//Option 1: parameters in our string
_logger.LogWarning("This is me! Logging some custom properties {properties}", customProps);


//Option 2: Use a scope
using (_logger.BeginScope(customProps))
{
    _logger.LogWarning("Test message custom properties using a scope");
}