using Lab2;

public class Program
{
    private static void Main(string[] args)
    {
        //float a = 0.123456789123456789123456789123F;
        //double b = 0.123456789123456789123456789123;
        //decimal c = 0.123456789123456789123456789123M;

        //string d = "abc";
        //d = d.Concat("def");

        //Console.WriteLine(a);
        //Console.WriteLine(b);
        //Console.WriteLine(c);

        //int a, b;
        //a = 3;
        //b = a;
        //a = 4;

        //Console.WriteLine(a);
        //Console.WriteLine(b);

        //Book book1, book2;

        //book1 = new Book();
        //book1.Id = 1;
        //book1.Title = "Moroetii";

        //book2 = book1;
        //book1.Title = "Morometii";

        //Console.WriteLine(book1.Title);
        //Console.WriteLine(book2.Title);

        List<Book> books = new List<Book>();

        books.Add(new Book
        {
            Id = 1,
            Title =  "Morometii",
            Pages = 300
        });

        books.Add(new Book
        {
            Id = 2,
            Title = "Ion",
            Pages = 455
        });

        books.Add(new Book
        {
            Id = 3,
            Title = "Enigma Otiliei",
            Pages = 476
        });

        try
        {
            var favouriteBook = books[2];

            Console.WriteLine(favouriteBook.Title);
            Console.WriteLine(favouriteBook.Author.Name);

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The user doesn't have a favourite book");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("The author doesn't exist");
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong");
        }
        finally
        {
            books.Clear();
        }
    }
}