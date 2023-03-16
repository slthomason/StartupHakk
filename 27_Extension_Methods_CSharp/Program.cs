public static class Class1
{
    // "this" modifier to extend methods for the list object
    public static List<int> ReverseAndAddSumAsLastElement(this List<int> list)
    { 
        list.Reverse();
        list.Add(list.Sum(s => Convert.ToInt32(s)));
        return list;
    }
    public static void CallExtensionMethod()
    {
        Random rnd = new Random();
        List<int> list = new List<int>();
        for (int i = 0; i < rnd.Next(10,50); i++)
        {
            list.Add(i);
        }

        //Every List Object has now an additional method
        list.ReverseAndAddSumAsLastElement();
    }
}