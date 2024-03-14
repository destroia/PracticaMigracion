using Entitys;
using Microsoft.EntityFrameworkCore;

namespace Datas
{
    public static class ModelsBuildersPMDB
    {
        public static ModelBuilder AddModelsBuilders(this ModelBuilder modelBuilder) {

            
            modelBuilder.Entity<Product>(ent => { ent.HasNoKey(); });
            return modelBuilder;
        }
    }
}
