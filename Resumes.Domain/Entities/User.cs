namespace Resumes.Domain.Entities;

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public Email Email { get; }
    public Guid RoleId { get; }

    private User(Guid id, string name, Email email, Guid roleId)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("Максимальная длина имени пользователя: 100 символов");
        }

        (Id, Name, Email, RoleId) = (id, name, email, roleId);
    }

    public static User Create(string name, Email email, Guid roleId)
    {
        var id = Guid.NewGuid();
        return new User(id, name, email, roleId);
    }
}