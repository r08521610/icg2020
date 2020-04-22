using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.painting;
using ICG2020.Instance;

namespace ICG2020.UI.Page
{
  public class Project01UI : StatefulWidget
  {
    public override State createState() => new Project01UIState();
  }

  class Project01UIState : State <Project01UI> {
    bool visible = true;
    public override Widget build (BuildContext context)
    {
      ParkingGamePointsInstance.Instance.reset();
      return new Scaffold (
        backgroundColor: visible ? Colors.black87.withAlpha(127) : Colors.transparent,
        appBar: new AppBar(
          leading: new IconButton(
            icon: new Icon(Icons.arrow_back),
            onPressed: () => {
              Navigator.pop(context);
              SceneManager.LoadScene("entry");
            }
          ),
          title: new IconButton(
            icon: new Icon(Icons.info_outline),
            onPressed: () => this.setState(() => visible = true)
          ),
          backgroundColor: Colors.transparent,
          elevation: 0
        ),
        body: visible ? new Padding(
          padding: EdgeInsets.all(30f),
          child: new Center (
            child: new Container(
              color: Colors.black87.withAlpha(127),
              padding: EdgeInsets.all(30f),
              child: new Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: new List <Widget> {
                  new Text(
                    "上下左右鍵控制車子，倒車入庫一次得 15 分；路邊停車 25 分；擦撞護欄扣 10 分。按 Enter 開始遊戲及返回開始畫面，遊戲中按 Esc 回開始畫面。",
                    textScaleFactor: 2
                  ),
                  new OutlineButton(
                    child: new Text("關閉", textScaleFactor: 2), 
                    onPressed: () => this.setState(() => visible = false)
                  )
                }
              )
            )
          )
        ) : null
      );
    }
  }
}
