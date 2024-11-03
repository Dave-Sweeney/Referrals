using System.Data;

namespace Referrals.Ui.Wpf.Configuration;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}