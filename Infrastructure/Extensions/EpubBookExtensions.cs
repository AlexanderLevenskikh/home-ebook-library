using System.Collections.Generic;
using System.Linq;
using VersOne.Epub;

namespace Infrastructure.Extensions
{
    public static class EpubBookExtensions
    {
        public static List<(EpubNavigationItem, int)> ToPlainList(
            this List<EpubNavigationItem> nav,
            int level = 1
        )
        {
            return nav.SelectMany(
                n =>
                {
                    var list = new List<(EpubNavigationItem, int)>()
                    {
                        (n, level),
                    };

                    if (n.NestedItems.Any())
                    {
                        list.AddRange(n.NestedItems.ToPlainList(level + 1));
                    }

                    return list;
                }
            ).ToList();
        }
    }
}
