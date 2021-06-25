namespace Infrastructure.Services
{
    public interface IContentService
    {
        public void Save(string contentLocation, byte[] content);
        public byte[] Find(string contentLocation);
        public bool Exists(string contentLocation);
        public void Delete(string contentLocation);
    }
}
