namespace Referrals.DataProcessing.Models;

public class Parent
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool OkToText { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string? Comment { get; set; }
}