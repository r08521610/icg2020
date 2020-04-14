using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using ICG2020.Instance;

namespace ICG2020.UI.Page
{
  public class Project01UI : StatefulWidget
  {
    public override State createState() => new Project01UIState();
  }

  class Project01UIState : State <Project01UI> {
    public override Widget build (BuildContext context)
    {
      ParkingGamePointsInstance.Instance.reset();
      return new Scaffold (
        backgroundColor: Colors.transparent,
        appBar: new AppBar(
          leading: new IconButton(
            icon: new Icon(Icons.arrow_back),
            onPressed: () => {
              Debug.Log("Button pressed");
              Navigator.pop(context);
              SceneManager.LoadScene("entry");
            }
          ),
          title: new Text(ParkingGamePointsInstance.Instance != null ? ParkingGamePointsInstance.Instance.Points.ToString() : null),
          backgroundColor: Colors.transparent,
          elevation: 0
        ),
        body: new Container ()
      );
    }
  }
}
