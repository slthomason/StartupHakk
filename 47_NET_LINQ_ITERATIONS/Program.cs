int counter = 0;            //   Declaration + Initialization
while (counter < 10)        //   Iterative condition
{
    DoSomething(counter);
    counter++;              //   Increment
}

for(int counter = 0; counter < 10; counter++)    // All the counter logic
{
    DoSomething(counter);                        // All the business logic
}

User[] user = GetUsersFromSomewhere();  // Declare the collection

for(int i = 0; i < users.Length; i++)   // Count all the indices
{
    var user = users[i];                // Access the item on the given index

    DoSomething(user);
}


User[] user = GetUsersFromSomewhere();

foreach(var user in users)               // All of the iteration logic
{
    DoSomething(user);                   // All of the business logic
}

List<Foo> originalItems = GetFoos();
List<Bar> mappedItems = new List<Bar>();

foreach(var item in originalItems)
{
    mappedItems.Add(new Bar(item));
}

List<Foo> originalItems = GetFoos();
List<Foo> filteredItems = new List<Foo>();

foreach(var item in originalItems)
{
    if(item.Bar == "condition")
        filteredItems.Add(new Bar(item));
}


List<Foo> originalItems = GetFoos();
Foo foundItem = null;

foreach(var item in originalItems)
{
    if(item.Bar == "condition")
    {
      if(foundItem != null)
        throw new Exception("More than one item was found.");

      foundItem = item;
    }     
}

if(foundItem == null)
    throw new Exception("No item was found.");

List<Foo> originalItems = GetFoos();

var mappedItems   = originalItems.Select(item => new Bar(item));
var filteredItems = originalItems.Where(item => item.Bar == "condition");
var foundItem     = originalItems.Single(item  => item.Bar == "condition");


var result = GetDogs()
                .Where(dog => dog.Name == "Rover")
                .Select(dog => dog.Owner)
                .Where(person => person.FirstName == "Bob")
                .OrderBy(person => person.Age);