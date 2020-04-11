using BlabberApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore
{
   public class UserMap
   {
       public UserMap(EntityTypeBuilder<User> entityBuilder)
       {
           entityBuilder.HasKey(t => t.Email);
           entityBuilder.Property(t => t.RegisterDTTM).IsRequired();
           entityBuilder.Property(t => t.LastLoginDTTM).IsRequired();
       }
   } 
}