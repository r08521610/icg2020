using System.Linq;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using ICG2020.UI.Component;
using ICG2020.Instance;

namespace ICG2020.UI.Page
{
  public class EntryUI : StatefulWidget
  {
    public override State createState() => new _EntryUIState();
  }

  public class _EntryUIState : State<EntryUI> {
    public override Widget build(BuildContext context) {
      return new Scaffold(
        appBar: new AppBar(
          title: new Center(
            child: new Text("ICG 2020 Lobby")
          ),
          backgroundColor: Colors.transparent,
          elevation: 0
        ),
        body: new Container(
          padding: EdgeInsets.symmetric(horizontal: 30),
          child: new Column(
            children: ProjectInstance.Instance.projects.Select(project => (Widget) new ProjectCard(project: project)).ToList()
          )
        )
      );
    }
  }
}