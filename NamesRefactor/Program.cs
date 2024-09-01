var names = new Names();
var path = names.BuildFilePath();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    names.ReadFromTextFile();
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    names.WriteToTextFile();
}
Console.WriteLine(names.Format());

Console.ReadLine();

public class Names
{
    private readonly List<string> _names = new List<string>();
    private readonly NameValidator _nameValidator= new NameValidator();

    public void AddName(string name)
    {
        if (_nameValidator.IsValid(name))
        {
            _names.Add(name);
        }
    }





    public string BuildFilePath()
    {
        //we could imagine this is much more complicated
        //for example that path is provided by the user and validated
        return "names.txt";
    }

    public string Format() =>
        string.Join(Environment.NewLine, _names);
}

class NameValidator
{
    public bool IsValid(string name)
    {
        return
            name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}

class StringsTextualRepository
{
    private static readonly string Separator = Environment.NewLine;
    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Separator).ToList();

    }

    public void Write(string filePath, List<string> strings) =>
        File.WriteAllText(filePath, string.Join(Separator, strings));
}