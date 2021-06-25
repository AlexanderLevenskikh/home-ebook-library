namespace Application.Content
{
    public interface IContentPathProvider
    {
        public string GetFullPath(ContentType contentType, string path);
    }
}
