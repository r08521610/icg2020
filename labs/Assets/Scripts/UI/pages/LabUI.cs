using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;

namespace ICG2020.UI.Page
{
  public class LabUI : StatelessWidget
  {
    public override Widget build (BuildContext context)
    {
      return new Scaffold (
        backgroundColor: Colors.transparent,
        appBar: new AppBar(
          leading: new IconButton(
            icon: new Icon(Icons.arrow_back),
            onPressed: () => {
              Navigator.pop(context);
              SceneManager.LoadScene("entry");
            }
          ),
          backgroundColor: Colors.transparent,
          elevation: 0
        ),
        body: new Container ()
      );
    }
  }
}
