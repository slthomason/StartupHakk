//Use Below

class Book
{
  //Use Below
    public Book GetTheBestBook(Book book)
    {
        return book ?? new Book() { Name = "C# in Depth" };
    }
 
    //Instead Of
    public Book GetTheBestBook(Book book)
    {
        if (book != null)
        {
            return book;
        }
        else
        {
            return new Book() { Name = "C# in Depth" };
        }
    }

} 
