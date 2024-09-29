using Microsoft.Data.Sqlite;
using Referrals.Library.Models;
using Referrals.Library.Repositories;
using SQLitePCL;

namespace Referrals.Library.Services;

public class ReferralsService : IReferralsService
{
    private readonly IReferralsRepository _referralsRepository;
    private const string ConnectionString = "Data Source=referrals.db";

    public ReferralsService(IReferralsRepository referralsRepository)
    {
        _referralsRepository = referralsRepository;
    }

    public void AddReferral(Referral referral)
        => _referralsRepository.AddReferral(referral);

    public Referral? GetReferral(int id)
        => _referralsRepository.GetReferral(id);

    public IEnumerable<Referral> GetReferrals()
        => _referralsRepository.GetAllReferrals();

    public void UpdateReferral(Referral referral)
        => _referralsRepository.UpdateReferral(referral);

    public void DeleteReferral(int id)
        => _referralsRepository.DeleteReferral(id);
}
