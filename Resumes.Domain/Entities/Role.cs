namespace Resumes.Domain.Entities;

public class Role
{
    public Guid Id { get; }
    public string Name { get; }

    private Role(Guid id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException();
        }

        (Id, Name) = (id, name);
    }

    public static Role Create(string name)
    {
        var id = Guid.NewGuid();
        return new Role(id, name);
    }
}