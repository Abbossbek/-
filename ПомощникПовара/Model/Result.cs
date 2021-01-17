using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПомощникПовара.Model
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public Atribut Atribut { get; set; }
        public Value Value { get; set; }
        public List<AtributValuePair> Conditions { get; set; }
    }
}
