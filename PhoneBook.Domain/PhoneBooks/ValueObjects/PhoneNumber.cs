using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.PhoneBooks.Exceptions;

namespace PhoneBook.Domain.PhoneBooks.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Value { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private PhoneNumber()
    {
    }

    public PhoneNumber(string value)
    {
        IsNullOrEmptyValidation(value);
        Value = value;
    }

    private void IsNullOrEmptyValidation(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new EmptyOrNullPhoneNumberException();
    }

    private void LengthValidation(string value)
    {
        if (value.Length is < 5 or > 150) throw new PhoneNumberLengthException();
    }
}