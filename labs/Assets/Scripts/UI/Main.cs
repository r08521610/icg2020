using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.animation;
using ICG2020.UI.Page;

namespace UIWidgetsSample {
  public class Main : UIWidgetsPanel {
    protected override Widget createWidget ()
    {
      return new MaterialApp(
        theme: ThemeData.dark(),
        showPerformanceOverlay: false,
        initialRoute: "/",
        routes: new Dictionary <string, WidgetBuilder>
        {
          {"/", context => new EntryUI()}
        }
      );
    }
  }
}