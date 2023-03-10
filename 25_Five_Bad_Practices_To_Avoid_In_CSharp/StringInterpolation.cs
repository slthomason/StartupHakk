class Book
{
//Use Below
    
    public string GetTheBestBookName(Book book)
    {
        return $"The Best book's Name is {book.Name}. and the author name is {book.Author}";
    } 

 //Instead Of
    public string GetTheBestBookName(Book book)
    {
        return "The Best book's Name is " + book.Name + " and the author name is " + book.Author;
    }

}    