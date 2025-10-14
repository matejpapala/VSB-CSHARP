
public class Employee
{
    public string Name { get; init; } = "";
    public int? Age { get; init; }
    public PhoneNumber? Phone { get; init; }
    public int Salary { get; init; }
    public bool? IsActive { get; init; }
}

public struct PhoneNumber
{
    public string CountryCode { get; }
    public long NationalNumber { get; }
    public PhoneNumber(string countryCode, long nationalNumber)
    {
        CountryCode = countryCode;
        NationalNumber = nationalNumber;
    }
    public string PrintOut() => $"{CountryCode}{NationalNumber}";
}