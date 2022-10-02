using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infra.DomainModel
{
    public class BookModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverPageImpageName { get; set; }
        public string FrontMatter { get; set; }
        public int Quantity { get; set; }
    }
}
