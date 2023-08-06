using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectRenan.Domain.Entities;
using ProjectRenan.Domain.Models;

namespace ProjectRenan.Data.Extensions
{
    public static class ModelBuilderExtension
    {

        // Método para garantir as regras de preenchimento padrão dos campos comuns das entidades
        public static ModelBuilder ApplyGlobalConfiguration(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }
            return builder;
        }
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
