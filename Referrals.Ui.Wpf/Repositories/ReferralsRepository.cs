using Referrals.Ui.Wpf.Configuration;
using System.Data;

namespace Referrals.Ui.Wpf.Repositories;

public class ReferralsRepository : IReferralsRepository
{
    private readonly IDbConnectionFactory _factory;

    public ReferralsRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
        // InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var _dbConnection = _factory.CreateConnection();
        
        if (_dbConnection.State == ConnectionState.Closed)
            _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS DUMMY_TABLE (
                Id INT PRIMARY KEY,
                Name NVARCHAR(100),
                Email NVARCHAR(100),
                Phone NVARCHAR(20),
                Address NVARCHAR(100),
                Date DATETIME
            )";
        command.ExecuteNonQuery();
    }

    public Task AddReferralAsync(Referral referral)
    {
        throw new NotImplementedException();
    }

    public Task DeleteReferralAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Referral> GetReferralAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Referral>> GetReferralsAsync()
    {
        // Get referrals from the database
        var sql = @"SELECT first_name + ' ' + last_name AS Name
    , created_datetime AS Date
    , comment AS AdditionalInfo
FROM PARENTS";

        using var _dbConnection = _factory.CreateConnection();
        if (_dbConnection.State == ConnectionState.Closed)
            _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = sql;

        var reader = command.ExecuteReader();
        var referrals = new List<Referral>();
        while (reader.Read())
        {
            referrals.Add(new Referral
            {
                Name = reader["Name"].ToString(),
                Date = (DateTime)reader["Date"],
                AdditionalInfo = reader["AdditionalInfo"].ToString()
            });
        }

        return Task.FromResult(referrals.AsEnumerable());
    }

    public Task UpdateReferralAsync(Referral referral)
    {
        throw new NotImplementedException();
    }
}
