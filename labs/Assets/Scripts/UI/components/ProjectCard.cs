using UnityEngine.SceneManagement;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using ICG2020.Model;

namespace ICG2020.UI.Component
{
  public class ProjectCard : StatelessWidget
  {
    public ProjectCard (
      Project project
    )
    {
      this.project = project;
    }

    public Project project;

    public override Widget build (BuildContext context)
    {
      return new InkWell(
        onTap: () => {
          Navigator.pushNamed(context, project.sceneName);
          SceneManager.LoadScene(project.sceneName);
        },
        child: new Card (
          child: new ListTile(
            title: new Text(project.name),
            subtitle: new Text(project.description)
          )
        )
      );
    }
  }
}