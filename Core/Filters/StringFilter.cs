namespace Core.Filters
{
    public class StringFilter
    {
        public string Data { get; set; }
        public StringMatchingType MatchingType { get; set; }
    }

    public enum StringMatchingType
    {
        Substring = 1,
        Exact = 2
    }
}
