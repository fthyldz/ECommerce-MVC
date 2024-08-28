using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Extensions;

public class InitialData
{
    public static IEnumerable<Category> Categories =>
        new List<Category>
        {
            new Category(CategoryId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "Elektronik"),
            new Category(CategoryId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "Kitap")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            new Product(ProductId.Of(new Guid("ef16011e-9a02-4406-b5a6-55367475cc0f")), "Laptop", "ASUS Laptop",
                new Money(1000, CurrencyType.USD), 10,
                CategoryId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa"))),
            new Product(ProductId.Of(new Guid("0c561b2d-7e71-42e5-9ffc-ebda321f8408")), "Komik Fıkralar", "Fıkralarla dolu bir kitap",
                new Money(100, CurrencyType.TRY), 122, CategoryId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"))),
            new Product(ProductId.Of(new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b")), "iPhone", "Bir telefondan fazlası.",
                new Money(2000, CurrencyType.EUR), 300, CategoryId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")))
        };

    public static IEnumerable<Role> Roles =>
        new List<Role>
        {
            new Role()
            {
                Id = new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), Name = "Admin", NormalizedName = "ADMIN"
            },
            new Role()
            {
                Id = new Guid("4160657b-b1cd-49a2-9a66-62890b7e571c"), Name = "User", NormalizedName = "USER"
            },
            new Role()
            {
                Id = new Guid("b73b0849-8298-4604-90ab-3c575ef270ce"), Name = "VipUser", NormalizedName = "VIPUSER"
            }
        };

    public static IEnumerable<User> Users =>
        new List<User>()
        {
            new User()
            {
                Id = new Guid("AEF93D94-6914-4B03-82C5-7EC006970E53"),
                UserName = "fth.yldz.admin@outlook.com.tr",
                NormalizedUserName = "FTH.YLDZ.ADMIN@OUTLOOK.COM.TR",
                Email = "fth.yldz.admin@outlook.com.tr",
                NormalizedEmail = "FTH.YLDZ.ADMIN@OUTLOOK.COM.TR",
                EmailConfirmed = true,
                FirstName = "Fatih",
                LastName = "YILDIZ",
                PasswordHash = "AQAAAAIAAYagAAAAEDItj1QI0+x4UJZVh/Rqz9zEXEhyOPhvBIIoYTpyhsE7yU20bl1Iljyf1fuJzSnfEg==",
                SecurityStamp = "5GV6OQBAT7XAGFWBZQUEVY4V7HNZGQTU",
                ConcurrencyStamp = "5a991664-2370-4615-be43-b5b923be53de",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new User()
            {
                Id = new Guid("af822b5e-8e1f-4244-9093-0806ab76e947"),
                UserName = "fth.yldz.user@outlook.com.tr",
                NormalizedUserName = "FTH.YLDZ.USER@OUTLOOK.COM.TR",
                Email = "fth.yldz.user@outlook.com.tr",
                NormalizedEmail = "FTH.YLDZ.USER@OUTLOOK.COM.TR",
                EmailConfirmed = true,
                FirstName = "Cengiz",
                LastName = "HAN",
                PasswordHash = "AQAAAAIAAYagAAAAEDItj1QI0+x4UJZVh/Rqz9zEXEhyOPhvBIIoYTpyhsE7yU20bl1Iljyf1fuJzSnfEg==",
                SecurityStamp = "5GV6OQBAT7XAGFWBZQUEVY4V7HNZGQTY",
                ConcurrencyStamp = "afa4fd36-20b0-4023-9576-42f494bd58c8",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new User()
            {
                Id = new Guid("472e5647-1a13-4e4f-973c-5904b6856091"),
                UserName = "fth.yldz.vip@outlook.com.tr",
                NormalizedUserName = "FTH.YLDZ.VIP@OUTLOOK.COM.TR",
                Email = "fth.yldz.vip@outlook.com.tr",
                NormalizedEmail = "FTH.YLDZ.VIP@OUTLOOK.COM.TR",
                EmailConfirmed = true,
                FirstName = "Cengiz",
                LastName = "HAN",
                PasswordHash = "AQAAAAIAAYagAAAAEDItj1QI0+x4UJZVh/Rqz9zEXEhyOPhvBIIoYTpyhsE7yU20bl1Iljyf1fuJzSnfEg==",
                SecurityStamp = "5GV6OQBAT7XAGFWBZQUEVY4V7HNZGQTZ",
                ConcurrencyStamp = "31837e71-c428-4e90-b1a8-c48383948d34",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            }
        };

    public static IEnumerable<IdentityUserRole<Guid>> UserRoles =>
        new List<IdentityUserRole<Guid>>()
        {
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                UserId = new Guid("AEF93D94-6914-4B03-82C5-7EC006970E53")
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("4160657b-b1cd-49a2-9a66-62890b7e571c"),
                UserId = new Guid("af822b5e-8e1f-4244-9093-0806ab76e947")
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = new Guid("b73b0849-8298-4604-90ab-3c575ef270ce"),
                UserId = new Guid("472e5647-1a13-4e4f-973c-5904b6856091")
            }
        };

    public static IEnumerable<Discount> Discounts =>
        new List<Discount>()
        {
            new Discount
            (
                DiscountId.Of(new Guid("4d6ae1d8-8624-46e8-9d99-c8c00fac4f98")),
                ProductId.Of(new Guid("0c561b2d-7e71-42e5-9ffc-ebda321f8408")),
                new Guid("b73b0849-8298-4604-90ab-3c575ef270ce"),
                10
            ),
            new Discount
            (
                DiscountId.Of(new Guid("56d16b66-5992-4332-9363-3be430da28dc")),
                ProductId.Of(new Guid("ef16011e-9a02-4406-b5a6-55367475cc0f")),
                null,
                20
            )
        };
}