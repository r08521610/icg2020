namespace ICG2020.Model
{
  public class Project
  {
    public string name, description = "", sceneName;
    public Project (string name, string description, string sceneName)
    {
      this.name = name;
      this.description = description;
      this.sceneName = sceneName;
    }
  }

  public class Lab : Project
  {
    public Lab (string name, string description, string sceneName) : base(name: name, description: description, sceneName: sceneName) {}
  }
}
