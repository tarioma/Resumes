using System.Text.RegularExpressions;

namespace Resumes.Domain.Entities;

public class Email
{
    private const string EmailAddressRegexPattern = "^.+@.+$";
    
    public Guid Id { get; }
    public string Value { get; }

    private Email(Guid id, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException();
        }
        
        if (!IsEmail(value))
        {
            throw new ArgumentException("Email невалиден");
        }

        (Id, Value) = (id, value);
    }

    public static Email Create(string value)
    {
        var id = Guid.NewGuid();
        return new Email(id, value);
    }

    private static bool IsEmail(string text) => Regex.IsMatch(text, EmailAddressRegexPattern);
}