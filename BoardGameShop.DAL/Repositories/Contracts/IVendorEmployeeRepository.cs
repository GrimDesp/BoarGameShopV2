namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IVendorEmployeeRepository : IDisposable
    {
        Task<int> GetVendorId(int employeeId);
    }
}
