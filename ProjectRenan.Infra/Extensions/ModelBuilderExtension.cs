using Microsoft.EntityFrameworkCore;
using ProjectRenan.Domain.Entities;

namespace ProjectRenan.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            //a cada migration executado, insere um usuário padrão
            builder.Entity<User>()
                .HasData(
                new User
                {
                    Id = Guid.Parse("3c666d3e-80ea-4470-b420-ad35533655cd"),
                    Name = "User Default",
                    Email = "user.default@projectrenan.com",
                    DateCreated = new DateTime(2023, 06, 14),
                    DateUpdated = null,
                    IsDeleted = false
                }); 

            return builder;
        }
    }
}
