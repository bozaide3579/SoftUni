namespace BookShop
{
	using BookShop.Models.Enums;
	using Data;
    using Initializer;
	using Microsoft.EntityFrameworkCore;
	using System.Globalization;
	using System.Text;

	public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            //DbInitializer.ResetDatabase(db); 

            Console.WriteLine(GetMostRecentBooks(context));
        }

		public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            if(!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return string.Empty;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray(); 

            return string.Join(Environment.NewLine, bookTitles);
        }

		public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToArray();

			return string.Join(Environment.NewLine, goldenBooks.Select(b => b.Title));
		}

		public static string GetBooksByPrice(BookShopContext context)
        {
            var mostExpensiveBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

			return string.Join(Environment.NewLine, mostExpensiveBooks.Select(a => $"{a.Title} - ${a.Price:f2}"));

		}

		public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                        b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy (b => b.BookId)
                .ToArray();

			return string.Join(Environment.NewLine, books.Select(b => b.Title));

		}

		public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(t=>t)
                .ToArray();

            return string.Join(Environment.NewLine, booksByCategory);
        }

		public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dt)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

		public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(n => n);

            return string.Join(Environment.NewLine, authors);
        }

		public static string GetBookTitlesContaining(BookShopContext context, string input)
		{
			var bookTitles = context.Books
				.Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
				.Select(b => b.Title)
				.OrderBy(t => t)
				.ToArray();

			return string.Join(Environment.NewLine, bookTitles);
		}

		public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string inputLowered = input.ToLower();

            var booksAndAuthorsInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputLowered))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

			return string.Join(Environment.NewLine, booksAndAuthorsInfo);
		}

		public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }

		public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Select(a => new
            {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
            })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            return string.Join(Environment.NewLine, authorsCopies.Select(ac => $"{ac.FirstName} {ac.LastName} - {ac.Copies}"));
        }

		public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesByProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => 
                            cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            return string.Join(Environment.NewLine, categoriesByProfit.Select(cbp => $"{cbp.Name} ${cbp.Profit:f2}"));
        }

		public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesWithLatest3Books = context.Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")
                }).ToArray()
                .OrderBy(c => c.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var c in categoriesWithLatest3Books)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine(b);
                }
            }

            return sb.ToString().TrimEnd();
        }

		public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

		public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(booksToDelete);
            context.SaveChanges();

            return booksToDelete.Length;
        }
	}
}


