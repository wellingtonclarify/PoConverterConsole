using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoConverter
{
    public static class ExtensionMethods
    {
        public static bool IsInList<T>(this T value, params T[] list)
        {
            return list.Contains(value);
        }
    }
}
