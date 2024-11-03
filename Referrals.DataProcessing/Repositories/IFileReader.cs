using Referrals.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referrals.DataProcessing.Repositories;

public interface IFileReader
{
    Task<List<ReferralDto>> ReadFileAsync(Stream file);
}
