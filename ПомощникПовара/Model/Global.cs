using ПомощникПовара.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПомощникПовара.Model
{
    public class Global
    {
        public static DataBaseContext db { get; set; }
        public static T GetClone<T>(T element) where T : class, new()
        {
            var sourceProperties = typeof(T)
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite);
            var newObj = new T();
            foreach (var property in sourceProperties)
            {
                property.SetValue(newObj, property.GetValue(element, null), null);
            }
            return newObj;
        }
    }
}
