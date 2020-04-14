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
        description: "Make a simple and complete text-based game with Unity console.",
        sceneName: "lab02"
      ),
      new Lab (
        name: "2D Car Simulation",
        description: "☞ Complete a car visualization which can allow users to rotate its wheels.\n☞ Complete car behavior which can allow users to speed-up, break, and make turn.\n☞ Complete a tracing camera support camera-window.",
        sceneName: "lab03"
      ),
      new Lab (
        name: "2D Parking Simulation",
        description: "",
        sceneName: "lab04"
      ),
      new Project(
        name: "2D Parking Simulator",
        description: "In this project, you will develop a virtual parking garage and a car motion simulator.\nThe virtual parking garage is created by using the provided images. Your car will drive in the virtual parking garage and has to avoid obstacles to complete parking.\nThe physics model in the Lab04 needs to be included in the car motion simulator. Collision detection need also be included.",
        sceneName: "project01"
      )
    };
  }
}