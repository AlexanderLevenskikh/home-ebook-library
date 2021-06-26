using System.Collections.Generic;

namespace Web.ViewModels
{
    public class DtoList<T> where T : class
    {
        public List<T> Items { get; set; }
        public long Count { get; set; }
    }
}
