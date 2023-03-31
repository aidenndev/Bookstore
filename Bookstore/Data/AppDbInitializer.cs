using Bookstore.Models;

namespace Bookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Add an admin
                if (!context.Customers.Any())
                {
                    context.Customers.Add(new Customer()
                    {
                        Name = "Admin",
                        Email = "admin@bookstore.com",
                        Password = "123"
                    });
                    context.SaveChanges();
                }

                //Add some initial books to the bookstore
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Id = "9b0896fa-3880-4c2e-bfd6-925c87f22878",
                            Name = "CQRS for Dummies",
                            PhotoURL = "https://d2sofvawe08yqg.cloudfront.net/cqrs/s_hero2x?1620376184"
                        },

                        new Book()
                        {
                            Id = "0550818d-36ad-4a8d-9c3a-a715bf15de76",
                            Name = "Visual Studio Tips",
                            PhotoURL = "https://dwtr67e3ikfml.cloudfront.net/bookCovers/d3714759e6b2b5dc65223f8f7ec2a84f85b680d8"
                        },

                        new Book()
                        {
                            Id = "8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1",
                            Name = "NHibernate Cookbook",
                            PhotoURL = "https://m.media-amazon.com/images/I/61jOuQUW9cL._AC_UF894,1000_QL80_.jpg"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
