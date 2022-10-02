using Inventory.Infra.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infra.Db
{
    internal class InventoryDbSeeder
    {
        public static void Seed(InventoryDbContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.books.Add(new BookModel()
            {
                Title = "Jungle Book",
                Author = "Rudyard Kipling",
                CoverPageImpageName = "JungleBook.jpg",
                FrontMatter = "Mowgli is a boy brought up in the jungle by a pack of wolves. When Shere Khan, a tiger, threatens to kill him, a panther and a bear help him escape his clutches.",
                Quantity = 10
            });
        }
    }
}
