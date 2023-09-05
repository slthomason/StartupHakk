
if (condition)
{
    //complex logic
    //....
    //....
    //....
}


// early return using invert if condtion
if (invertCondition)
{
    return;
}
//now add complex logic here





//Don’t use many conditions inside If statement


if(condition1 && condition2 && condition3)
{
  // do something 
}



//1. Consolidate conditions into a local variable and treat them as a single condition.
bool isValidCondtion = condition1 && condition2 && condition3;

if(isValidCondtion)
{ 
 // do something
}





//2. Develop a helper validation method and invoke it within the main method.
if(Validate(DummyEnitity dummyEnitity))
{ 
 // do something
}



//Don’t use negation operator
if(!isValid)
{ 
}


//Instead add condtion without negation operator
if(isValid)
{ 
}


//Avoid using excessive conditional statements within a method as it can raise the cyclomatic complexity of the code. 
//This can make the code harder to understand, test and maintain.
internal void TestMethod()
{

    if (condition1)
    {
        // do something 
        //......
        //......
        //conditional statement
        //......
        //......
    }


    if (condition2)
    {
        // do something 
        //......
        //......
        //conditional statement
        //......
        //......
    }
}

//Improved Example
internal void TestMethod()
{
    SubMethod1();

    SubMethod2();
}

private void SubMethod1()
{
    if (condition1)
    {
        // do something 
        //......
        //......
        //conditional statement
        //......
        //......
    }
}

private void SubMethod2()
{
    if (condition2)
    {
        // do something 
        //......
        //......
        //conditional statement
        //......
        //......
    }
}

//Replace the “==” operator with “is” and the “!=” operator with 
//“is not” for better code clarity and adherence to best practices. 
//This helps improve the readability and maintainability of the code.

if (result is not null)
{
    // do something
}

//Null-coalescing operator(??) and Null-conditional operators (?.)


// If user Address or City is null then cityName becomes "Unknown"
string cityName = user?.Address?.City ?? "Unknown"; 


//If statement always uses curly brackets { }

if (lstProduct.HasItems())
{
    // do something
}

//Quite simple scenario uses ternary operator (?:)

int number = 9;
string numberType = (number % 2 == 0) ? "Even" : "Odd";
