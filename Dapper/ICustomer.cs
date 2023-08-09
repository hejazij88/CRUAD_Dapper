namespace Dapper
{
    public interface ICustomer
    {
        bool add(CustomerDto customer);
        bool update(CustomerDto customer);
        bool delete(int customerId);
        CustomerDto Find(int customerId);

        IEnumerable<CustomerDto> GetAll();
    }
}