using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПомощникПовара.Model
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconSource { get; set; }
        public List<Product> Products { get; set; }
        public List<Extra> Extras { get; set; }
    }
}
