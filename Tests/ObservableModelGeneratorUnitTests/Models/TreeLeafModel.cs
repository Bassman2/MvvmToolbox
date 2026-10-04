namespace ObservableModelGeneratorUnitTests.Models;

public class TreeLeafModel(string? name = null)
{
    public string Name { get; set; } = name ?? string.Empty;

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is TreeLeafModel other)
        {
            return Name == other.Name;
        }
        return false;
    }
}
