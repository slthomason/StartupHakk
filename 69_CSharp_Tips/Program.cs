/*Write unit tests for non-public methods*/

// Make a specific assembly visible
[assembly: InternalsVisibleTo("MyTestAssembly")]


/*Use tuples*/
public Tuple<int, string, string> GetEmployee()
{
int employeeId = 100;
string firstName = "John";
string lastName = "Smith";
//create a tuple and return it
return Tuple.Create(employeeId, firstName, lastName);
}


/* No need to create temporary collections, better to use yield */

//Before Yield
public List<int> GetValuesGreaterThan100(List<int> masterCollection)
{
List<int> tempResult = new List<int>();
foreach (var value in masterCollection)
{
if (value > 100)
tempResult.Add(value);
}
return tempResult;
}

//After Yield

public IEnumerable<int> GetValuesGreaterThan100(List<int> masterCollection)
{
foreach (var value in masterCollection)
{
if (value > 100)
yield return value;
}
}




/*Report that the method is obsolete*/

//Before
[Obsolete("This method will be obsolete soon. To replace it you can use the XYZ method.")]
public void MyComponentLegacyMethod()
{
// Here the implementation
}

//After
[Obsolete("This method will be obsolete soon. To replace it you can use the XYZ method."
, true)]
public void MyComponentLegacyMethod()
{
// Here the implementation
}






//Remember that linq queries are deferred
public void MyComponentLegacyMethod(List<int> masterCollection)
{
// Without the ToList method this linq query would be executed twice
var result = masterCollection.Where(i => i > 100).ToList();
Console.WriteLine(result.Count());
Console.WriteLine(result.Average());
}