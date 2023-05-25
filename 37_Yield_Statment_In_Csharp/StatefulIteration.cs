 //Before Yield
 IEnumerable<int> RunningTotal(IEnumerable<int> numbers)
 {
    // Create a new list to store the running total
    var runningTotal = new List<int>();
    // Set the initial running total to 0
    var total = 0;
    // Loop through the numbers in the list
    foreach (var number in numbers)
    {
        // Add the current number to the running total
        total += number;
        // Add the running total to the list
        runningTotal.Add(total);
    }
    // Return the list of running totals
    return runningTotal;
}

//After Yield

IEnumerable<int> RunningTotal(IEnumerable<int> numbers)
{
    var total = 0;
    foreach (var number in numbers)
    {
        total += number;
        yield return total;
    }
}