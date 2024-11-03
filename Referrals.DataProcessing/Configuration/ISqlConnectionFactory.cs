using System.Data.SqlClient;

namespace Referrals.DataProcessing.Configuration;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}