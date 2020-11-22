namespace Bookeasy.Application.Common.Interfaces
{
    public interface IIrisDbContext
    {
        IBusinessUserRepository BusinessUser { get; }
    }
}
