using Dapper;
using Referrals.Ui.Wpf.Configuration;
using Referrals.Ui.Wpf.Models;
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

    public async Task<IEnumerable<Referral>> GetReferralsAsync()
    {
        // Get referrals from the database
        var sql = @"
              SELECT 
                first_name + ' ' + last_name AS Name
                , referral_date AS Date
                , comment AS AdditionalInfo
              FROM PARENTS p
              LEFT JOIN REFERRALS r ON r.parent_id = p.id
              ORDER BY referral_date";

        using var _dbConnection = _factory.CreateConnection();
        
        try
        {
            var referrals = await _dbConnection.QueryAsync<Referral>(sql);
            //return Task.FromResult(referrals);
            return referrals;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //return Task.FromResult(Enumerable.Empty<Referral>());
        return [];
    }

    public Task UpdateReferralAsync(Referral referral)
    {
        throw new NotImplementedException();
    }
}
