using System.Data;

namespace Referrals.Library.Configuration;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}