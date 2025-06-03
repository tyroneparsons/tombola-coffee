using Microsoft.EntityFrameworkCore;
using Tombola.Coffee.WebApi.Entities;

namespace Tombola.Coffee.WebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
    }

    public DbSet<Bean> Beans { get; set; }

    public DbSet<BeanOfTheDay> BeanOfTheDays { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=TombolaCoffee.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bean>().HasData(
            new Bean
            {
                Id = "66a374596122a40616cb8599",
                Name = "TURNABOUT",
                Description = "Ipsum cupidatat nisi do elit veniam Lorem magna. Ullamco qui exercitation fugiat pariatur sunt dolore Lorem magna magna pariatur minim. Officia amet incididunt ad proident. Dolore est irure ex fugiat. Voluptate sunt qui ut irure commodo excepteur enim labore incididunt quis duis. Velit anim amet tempor ut labore sint deserunt.\r\n",
                Cost = 39.26m,
                Colour = "dark roast",
                Country = "Peru",
                Image = "https://images.unsplash.com/photo-1672306319681-7b6d7ef349cf"
            },
            new Bean
            {
                Id = "66a374591a995a2b48761408",
                Name = "ISONUS",
                Description = "Dolor fugiat duis dolore ut occaecat. Excepteur nostrud velit aute dolore sint labore do eu amet. Anim adipisicing quis ut excepteur tempor magna reprehenderit non ut excepteur minim. Anim dolore eiusmod nisi nulla aliquip aliqua occaecat.\r\n",
                Cost = 18.57m,
                Colour = "golden",
                Country = "Vietnam",
                Image = "https://images.unsplash.com/photo-1641399756770-9b0b104e67c1"
            },
            new Bean
            {
                Id = "66a374593ae6cb5148781b9b",
                Name = "ZILLAN",
                Description = "Cillum nostrud mollit non ad dolore ad dolore veniam. Adipisicing anim commodo fugiat aute commodo occaecat officia id officia ullamco. Dolore irure magna aliqua fugiat incididunt ullamco ea. Aliqua eu pariatur cupidatat ut.\r\n",
                Cost = 33.87m,
                Colour = "green",
                Country = "Colombia",
                Image = "https://images.unsplash.com/photo-1522809269485-981d0c303355"
            },
            new Bean
            {
                Id = "66a37459771606d916a226ff",
                Name = "RONBERT",
                Description = "Et deserunt nisi in anim cillum sint voluptate proident. Est occaecat id cupidatat cupidatat ex veniam irure veniam pariatur excepteur duis labore occaecat amet. Culpa adipisicing nisi esse consequat adipisicing anim. Fugiat tempor enim ullamco sint anim qui enim. Voluptate duis proident reprehenderit et duis nisi. In consectetur nisi eu cupidatat voluptate ullamco nulla esse cupidatat dolore sit. Cupidatat laboris adipisicing ullamco mollit culpa cupidatat ex laborum consectetur consectetur.\r\n",
                Cost = 17.69m,
                Colour = "dark roast",
                Country = "Brazil",
                Image = "https://images.unsplash.com/photo-1598198192305-46b0805890d3"
            },
            new Bean
            {
                Id = "66a3745945fcae53593c42e7",
                Name = "EARWAX",
                Description = "Labore veniam amet ipsum eu dolor. Aliquip Lorem et eiusmod exercitation. Amet ex eu deserunt labore est ex consectetur ut fugiat. Duis veniam voluptate elit consequat tempor nostrud enim mollit occaecat.\r\n",
                Cost = 26.53m,
                Colour = "green",
                Country = "Vietnam",
                Image = "https://images.unsplash.com/photo-1512568400610-62da28bc8a13"
            },
            new Bean
            {
                Id = "66a37459591e872ce11c3b41",
                Name = "EVENTEX",
                Description = "Reprehenderit est laboris tempor quis exercitation laboris. Aute nulla aliqua consectetur nostrud ullamco cupidatat do cillum amet reprehenderit mollit non voluptate. Deserunt consectetur reprehenderit nostrud enim proident ea. Quis quis voluptate ex dolore non reprehenderit minim veniam nisi aute do incididunt voluptate. Duis aliquip commodo cupidatat anim ut ullamco eiusmod culpa velit incididunt.\r\n",
                Cost = 36.56m,
                Colour = "light roast",
                Country = "Vietnam",
                Image = "https://images.unsplash.com/photo-1692299108834-038511803008"
            },
            new Bean
            {
                Id = "66a374599018ca32d01fee66",
                Name = "NITRACYR",
                Description = "Mollit deserunt tempor qui consectetur excepteur non. Laborum voluptate voluptate laborum non magna et. Ea velit ipsum labore occaecat ea do cupidatat duis adipisicing. Ut eiusmod dolor anim et ea ea. Aliquip mollit aliqua nisi velit consequat nisi. Laborum velit anim non incididunt non qui commodo. Ea voluptate dolore pariatur eu enim.\r\n",
                Cost = 22.92m,
                Colour = "green",
                Country = "Brazil",
                Image = "https://images.unsplash.com/photo-1692296115158-38194aafa7df"
            },
            new Bean
            {
                Id = "66a37459cca42ce9e15676a3",
                Name = "PARAGONIA",
                Description = "Veniam laborum consequat minim laborum mollit id ea Lorem in. Labore aliqua dolore quis sunt aliquip commodo aute excepteur. Voluptate tempor consequat pariatur do esse consectetur sunt ut mollit magna enim.\r\n",
                Cost = 37.91m,
                Colour = "medium roast",
                Country = "Colombia",
                Image = "https://images.unsplash.com/photo-1522120378538-41fb9564bc75"
            },
            new Bean
            {
                Id = "66a374590abf949489fb28f7",
                Name = "XLEEN",
                Description = "Commodo veniam voluptate elit reprehenderit incididunt. Ut laboris dolor sint cupidatat ut adipisicing. Nostrud magna labore voluptate commodo in sunt proident sunt deserunt dolor ullamco officia tempor dolor. Laboris exercitation est mollit eiusmod nostrud. Sit qui ullamco minim cillum officia irure cillum tempor eu. Et cupidatat proident amet dolore non minim.\r\n",
                Cost = 17.59m,
                Colour = "golden",
                Country = "Colombia",
                Image = "https://images.unsplash.com/photo-1442550528053-c431ecb55509"
            },
            new Bean
            {
                Id = "66a374593a88b14d9fff0e2e",
                Name = "LOCAZONE",
                Description = "Deserunt consequat ea incididunt aliquip. Occaecat excepteur minim occaecat aute amet adipisicing. Tempor id veniam ipsum et tempor pariatur anim elit laboris commodo mollit. Ipsum incididunt Lorem veniam id fugiat incididunt consequat est et. Id deserunt eiusmod esse duis cupidatat Lorem. Ullamco Lorem ullamco cupidatat nostrud amet id minim ut voluptate adipisicing ipsum. Fugiat reprehenderit laborum proident eiusmod esse sint adipisicing fugiat ex.\r\n",
                Cost = 25.49m,
                Colour = "green",
                Country = "Vietnam",
                Image = "https://images.unsplash.com/photo-1549420751-ea3f7ab42006"
            },
            new Bean
            {
                Id = "66a37459b7933d86991ce243",
                Name = "ZYTRAC",
                Description = "Qui deserunt adipisicing nulla ad enim commodo reprehenderit id veniam consequat ut do ea officia. Incididunt ex esse cupidatat consequat. Sit incididunt ex magna sint reprehenderit id minim non.\r\n",
                Cost = 10.27m,
                Colour = "light roast",
                Country = "Vietnam",
                Image = "https://images.unsplash.com/photo-1508690207469-5c5aebedf76d"
            },
            new Bean
            {
                Id = "66a374592169e1bfcca2fb1c",
                Name = "FUTURIS",
                Description = "Incididunt exercitation mollit duis consectetur consequat duis culpa tempor. Fugiat nisi fugiat dolore irure in. Fugiat nulla amet dolore labore laboris sint laborum pariatur commodo amet. Ut velit sit proident fugiat cillum cupidatat ea.\r\n",
                Cost = 16.44m,
                Colour = "medium roast",
                Country = "Colombia",
                Image = "https://images.unsplash.com/photo-1694763768576-0c7c3af6a4d8"
            },
            new Bean
            {
                Id = "66a37459cc0f1fb1d1a24cf0",
                Name = "KLUGGER",
                Description = "Pariatur qui Lorem sunt labore Lorem nulla nulla ea excepteur Lorem cillum amet. Amet ea officia incididunt culpa non. Do reprehenderit qui eiusmod dolore est deserunt labore do et dolore eiusmod quis elit.\r\n",
                Cost = 32.77m,
                Colour = "green",
                Country = "Peru",
                Image = "https://images.unsplash.com/photo-1692299108333-471157a30882"
            },
            new Bean
            {
                Id = "66a37459caf60416d0571db4",
                Name = "ZANITY",
                Description = "Velit quis veniam velit et sint. Irure excepteur officia ipsum sint. Est ipsum pariatur exercitation voluptate commodo. Ex irure commodo exercitation labore nulla qui dolore ad quis.\r\n",
                Cost = 19.07m,
                Colour = "dark roast",
                Country = "Honduras",
                Image = "https://images.unsplash.com/photo-1673208127664-23a2f3b27921"
            },
            new Bean
            {
                Id = "66a3745997fa4069ce1b418f",
                Name = "XEREX",
                Description = "Esse ad eiusmod eiusmod nisi cillum magna quis non voluptate nulla est labore in sunt. Magna aliqua pariatur commodo deserunt. Pariatur pariatur pariatur id excepteur ex elit veniam.\r\n",
                Cost = 29.42m,
                Colour = "green",
                Country = "Brazil",
                Image = "https://images.unsplash.com/photo-1544486864-3087e2e20d91"
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}