using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Referrals.DataProcessing.Configuration;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private SqlConnection? _connection;
    SqlConnectionOptions _options;

    public SqlConnectionFactory(IOptions<SqlConnectionOptions> options)
    {
        _options = options.Value;

        if (string.IsNullOrEmpty(_options.ConnectionString))
        {
            throw new ArgumentNullException(nameof(_options.ConnectionString));
        }

        _connection = new SqlConnection(_options.ConnectionString);
    }

    public SqlConnection CreateConnection()
    {

        if (_connection is null || _connection.ConnectionString != _options.ConnectionString)
        {
            _connection = new SqlConnection(_options.ConnectionString);
        }
        return _connection;
    }
}
