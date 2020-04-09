using System.Collections.Generic;
using ICG2020.Model;

namespace ICG2020.Instance
{
  public class ProjectInstance
  {
    private static ProjectInstance _instance;
    public static ProjectInstance Instance
    {
      get
      {
        if (_instance == null) _instance = new ProjectInstance();
        return _instance;
      }
    }
    private ProjectInstance () {}

    public List<Project> projects = new List<Project>
    {
      new Lab(
        name: "Authoring Tool - Unity",
        description: "",
        sceneName: "lab01"
      ),
      new Lab(
        name: "Interactable Entities - An Escape Game",
        description: "",
        sceneName: "lab02"
      ),
      new Lab (
        name: "2D Car Simulation",
        description: "",
        sceneName: "lab03"
      ),
      new Lab (
        name: "2D Parking Simulation",
        description: "",
        sceneName: "lab03"
      )
    };
  }
}