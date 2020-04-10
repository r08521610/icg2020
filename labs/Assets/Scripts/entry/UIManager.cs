using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  private static UIManager _instance;
  public static UIManager Instance
  {
    get
    {
      if (_instance == null) _instance = new UIManager();
      return _instance;
    }
  }

  // Start is called before the first frame update
  void Awake()
  {
    if (_instance == null)
    {
      _instance = this;
      DontDestroyOnLoad(this);
    } else if (this != _instance)
    {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
