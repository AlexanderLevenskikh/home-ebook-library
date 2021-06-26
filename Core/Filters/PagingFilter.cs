namespace Core.Filters
{
    public class PagingFilter
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool? IgnoreLimit { get; set; }

        public void ResetPagingAndIgnoreLimits()
        {
            Limit = null;
            Offset = null;
            IgnoreLimit = true;
        }
    }
}
