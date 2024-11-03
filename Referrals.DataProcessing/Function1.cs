using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Referrals.DataProcessing.Extensions;
using Referrals.DataProcessing.Models;
using Referrals.DataProcessing.Repositories;

namespace Referrals.DataProcessing;

public class Function1
{
    private readonly ILogger<Function1> _logger;
    private readonly IFileReader _reader;
    private readonly IReferralsRepository _referralsRepository;

    public Function1(
        ILogger<Function1> logger, 
        IFileReader reader,
        IReferralsRepository referralsRepository)
    {
        _logger = logger;
        _reader = reader;
        _referralsRepository = referralsRepository;
    }

    [Function(nameof(Function1))]
    public async Task Run([BlobTrigger("referrals/{name}", Connection = "")] Stream stream, string fileName)
    {
        try
        {
            var referralsDto = await _reader.ReadFileAsync(stream);
            List<Referral> referrals = new List<Referral>();

            var content = new StringBuilder();

            foreach (var referralDto in referralsDto)
            {
                var referral = referralDto.Map();
                referrals.Add(referral);
                await _referralsRepository.AddReferralAsync(referral);

                content.AppendLine($"ReferralId: {referralDto.ReferralId}");
            }
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {fileName} \n Data: {content.ToString()}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing file");
        }
    }
}
