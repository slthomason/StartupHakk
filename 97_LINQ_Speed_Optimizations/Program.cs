var query =
    from person in people
    where person.Age > 20
    select person.Name;


var query = 
  Enumerable.Select(Enumerable.Where(people, person => person.Age > 20), person => person.Name);


var query = people
    .Where(person => person.Age > 20)
    .Select(person => person.Name);


//Implicit enumerator collapse


public static IEnumerable<TSource> Where<TSource>(
    this IEnumerable<TSource> source, 
    Func<TSource, bool> predicate)
{
    foreach(var item in source)
    {
        if(predicate(item))
            yield return item;
    }
}


public static IEnumerable<TResult> Select<TSource, TResult>(
    this IEnumerable<TSource> source, 
    Func<TSource, TResult> selector)
{
    foreach(var item in source)
    {
        yield return selector(item);
    }
}     


public static IEnumerable<TResult> WhereSelect<TSource, TResult>(
    this IEnumerable<TSource> source, 
    Func<TSource, bool> predicate, 
    Func<TSource, TResult> selector)
{
    foreach(var item in source)
    {
        if(predicate(item))
            yield return selector(item);
    }
}


public static IEnumerable<TSource> Where<TSource>(
    this IEnumerable<TSource> source, 
    Func<TSource, bool> predicate1, 
    Func<TSource, bool> predicate2)
    => source.Where(item => predicate1(item) && predicate2(item));
    
public static IEnumerable<TResult> Select<TSource, TMiddle, TResult>(
    this IEnumerable<TSource> source, 
    Func<TSource, TMiddle> selector1, 
    Func<TMiddle, TResult> selector2)
    => source.Select(item => selector2(selector1(item)));


//Explicit enumerator collapse
public static int Count<TSource>(
    this IEnumerable<TSource> source
{
    var count = 0;
    using(var enumerator = source.GetEnumerator())
    {
        checked
        {
            while(enumerator.MoveNext())
                count++;
        }
    }
    return count;
}

public static int Count<TSource>(
    this IEnumerable<TSource> source, 
    Func<TSource, bool> predicate)
{
    var count = 0;
    foreach(var item in source)
    {
        checked
        {
            if(predicate(item))
                count++;
        }
    }
    return count;
})


//Source Types

public static bool Any<TSource>(this IEnumerable<TSource> source)
{
    using(var enumerator = source.GetEnumerator())
    {
        return enumerator.MoveNext();
    }
}


//Value-type enumerators


var source = new List<int>();
foreach(var item in source)
    Console.WriteLine(item);

List<int>.Enumerator enumerator = new List<int>().GetEnumerator();
try
{
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
}
finally
{
    ((IDisposable)enumerator).Dispose();
}

//Generic math

static T Sum<T>(IEnumerable<T> source)
    where T: IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>
{
    var sum = T.AdditiveIdentity; // initialize to zero
    foreach(var value in source)
        sum += value; // add value to sum
    return sum;
}

// half-precision floating-point
var sinHalf = Half.Sin(Half.Pi);
var arcSinHalf = Half.Asin(sinHalf);

// single-precision floating-point
var sinFloat = float.Sin(float.Pi);
var arcSinFloat = float.Asin(sinFloat);

// double-precision floating-point
var sinDouble = double.Sin(double.Pi);
var arcSinDouble = double.Asin(sinDouble);


