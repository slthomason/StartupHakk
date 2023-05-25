//Before Yield
IEnumerable<int> GreaterThanFive(IEnumerable<int> numbers)
{
   List<int> result = new List<int>();

   foreach (var number in numbers)
   {
      if (number > 5)
        result.Add(number);
   }

    return result;
}

//After Yield
IEnumerable<int> GreaterThanFive(IEnumerable<int> numbers)
{

  foreach (var number in numbers)
  {
     if (number > 5)
          yield return number;
  }
}