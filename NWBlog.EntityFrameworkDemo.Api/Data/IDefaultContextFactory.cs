namespace NWBlog.EntityFrameworkDemo.Api.Data
{
    public interface IDefaultContextFactory
    {
        DefaultContext CreateContext();
    }
}
