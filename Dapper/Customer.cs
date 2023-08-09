using System.Data.SqlClient;

namespace Dapper
{
    public class Customer : ICustomer
    {

        readonly string connectionString = @"Server=LAPTOP-JQR66TAF\SQL2019;Initial Catalog=Dapper_CRUAD;Integrated security=true";
        public bool add(CustomerDto customer)
        {
            string sql = "Insert INTO Tb_Customers (Name,LastName) Values(@Name,@LastName)";
            var connection = new SqlConnection(connectionString);
            connection.Execute(sql, new { Name = customer.Name, LastName = customer.LastName });
            return true;
        }

        public bool delete(int customerId)
        {
            string sql = "DELETE FROM Tb_Customers WHERE Id =@Id";
            var connection = new SqlConnection(connectionString);
            connection.Execute(sql, new { Id = customerId });
            return true;
        }

        public CustomerDto Find(int customerId)
        {
            string sql = "SELECT Id, Name, LastName FROM Tb_Customers WHERE Id =@Id";
            var connection = new SqlConnection(connectionString);
            var customer = connection.QuerySingleOrDefault<CustomerDto>(sql, new {Id=customerId});
            return customer;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            string sql = "SELECT * FROM Tb_Customers";
            var connection = new SqlConnection(connectionString);
            var customers = connection.Query<CustomerDto>(sql);
            return customers.ToList();


        }

        public bool update(CustomerDto customer)
        {
            string sql = "UPDATE Tb_Customers SET Name = @Name, LastName = @LastName WHERE Id=@Id;";
            var connection = new SqlConnection(connectionString);
            connection.Execute(sql, new { Id = customer.Id, Name = customer.Name, LastName = customer.LastName });
            return true;
        }

    }
}