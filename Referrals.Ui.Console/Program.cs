using Referrals.Library.Models;
using Referrals.Library.Repositories;
using Referrals.Library.Services;
using System;

namespace Referrals.Ui.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var repository = new ReferralsRepository("Data Source=referrals.db");
        var service = new ReferralsService(repository);

        System.Console.WriteLine();
        while (true)
        {
            System.Console.WriteLine("1. Add Referral");
            System.Console.WriteLine("2. Get Referral");
            System.Console.WriteLine("3. Get All Referrals");
            System.Console.WriteLine("4. Exit");
            var choice = System.Console.ReadLine();

            if (choice == "1")
            {
                var referral = new Referral
                {
                    ReferralDate = DateTime.Now,
                    ParentName = Prompt("Parent Name: "),
                    ParentEmail = Prompt("Parent Email: "),
                    ParentPhone = Prompt("Parent Phone: "),
                    OkToText = Prompt("Ok to Text (true/false): ").ToLower() == "true",
                    ChildName = Prompt("Child Name: "),
                    ChildAge = int.Parse(Prompt("Child Age: ")),
                    Comments = Prompt("Comments: ")
                };

                service.AddReferral(referral);
                System.Console.WriteLine("Referral added successfully!");
            }
            else if (choice == "2")
            {
                var referral = service.GetReferral(int.Parse(Prompt("Referral Id: ")));
                if (referral is not null)
                {
                    System.Console.WriteLine($"Referral Date: {referral.ReferralDate}");
                    System.Console.WriteLine($"Parent Name: {referral.ParentName}");
                    System.Console.WriteLine($"Parent Email: {referral.ParentEmail}");
                    System.Console.WriteLine($"Parent Phone: {referral.ParentPhone}");
                    System.Console.WriteLine($"Ok to Text: {referral.OkToText}");
                    System.Console.WriteLine($"Child Name: {referral.ChildName}");
                    System.Console.WriteLine($"Child Age: {referral.ChildAge}");
                    System.Console.WriteLine($"Comments: {referral.Comments}");
                }
                else
                {
                    System.Console.WriteLine("Referral not found!");
                }
            }
            else if (choice == "3")
            {
                var referrals = service.GetReferrals();
                foreach (var referral in referrals)
                {
                    System.Console.WriteLine($"Referral Id: {referral.Id}");
                    System.Console.WriteLine($"Referral Date: {referral.ReferralDate}");
                    System.Console.WriteLine($"Parent Name: {referral.ParentName}");
                    System.Console.WriteLine($"Parent Email: {referral.ParentEmail}");
                    System.Console.WriteLine($"Parent Phone: {referral.ParentPhone}");
                    System.Console.WriteLine($"Ok to Text: {referral.OkToText}");
                    System.Console.WriteLine($"Child Name: {referral.ChildName}");
                    System.Console.WriteLine($"Child Age: {referral.ChildAge}");
                    System.Console.WriteLine($"Comments: {referral.Comments}");
                    System.Console.WriteLine();
                }
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }

    static string? Prompt(string message)
    {
        System.Console.Write(message);
        return System.Console.ReadLine();
    }
}
