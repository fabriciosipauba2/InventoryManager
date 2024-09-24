using InventoryManager.Data;
using InventoryManager.Models;

namespace InventoryManager
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Categorias.Any())
            {
                var categorias = new List<Categoria>
            {
                new Categoria { Nome = "Eletrônicos" },
                new Categoria { Nome = "Roupas" },
                new Categoria { Nome = "Brinquedos" },
                new Categoria { Nome = "Calçados" }

            };

                context.Categorias.AddRange(categorias);
                context.SaveChanges();
            }
        }


    }
}
