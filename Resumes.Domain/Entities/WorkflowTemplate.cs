namespace Resumes.Domain.Entities;

public class WorkflowTemplate
{
    public Guid Id { get; }
    public string Name { get; }
    public ICollection<WorkflowStepTemplate> Steps { get; }

    private WorkflowTemplate(Guid id, string name, ICollection<WorkflowStepTemplate> steps)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("Максимальная длина названия шаблона рабочего процесса: 100 символов");
        }

        (Id, Name, Steps) = (id, name, steps);
    }

    public static WorkflowTemplate Create(string name)
    {
        var id = Guid.NewGuid();
        var steps = new HashSet<WorkflowStepTemplate>();
        return new WorkflowTemplate(id, name, steps);
    }
}