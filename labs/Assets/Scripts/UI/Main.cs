using UnityEngine;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.material;
using Unity.UIWidgets.animation;
using ICG2020.UI.Page;

namespace UIWidgetsSample {
  public class Main : UIWidgetsPanel {
    protected override void OnEnable() {
      FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");

      base.OnEnable();
    }
    protected override Widget createWidget ()
    {
      return new MaterialApp(
        theme: ThemeData.dark(),
        showPerformanceOverlay: false,
        initialRoute: "/",
        routes: new Dictionary <string, WidgetBuilder>
        {
          {"/", context => new EntryUI()},
          {"lab01", context => new LabUI()},
          {"lab02", context => new LabUI()},
          {"lab03", context => new LabUI()},
          {"lab04", context => new LabUI()},
          {"project01", context => new Project01UI()}
        }
      );
    }
  }
}