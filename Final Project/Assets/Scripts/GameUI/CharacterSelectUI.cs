using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
  [SerializeField] GameScene m_GameScene;
  [SerializeField] List <CharacterInfo> m_Characters = new List<CharacterInfo> ();
  [SerializeField] CharacterInfoButton m_CharacterInfoButtonFront;
  [SerializeField] CharacterInfoButton m_CharacterInfoButtonBack;
  [SerializeField] GameObject m_GameStartButton;

  private int m_CurrentIndex = 0;
  private int m_CurrentPlayerIndex = 0;
  void Awake ()
  {
    m_CharacterInfoButtonFront.Update (m_Characters[m_CurrentIndex].m_Name, m_Characters[m_CurrentIndex].m_Image);
    m_CharacterInfoButtonBack.Update (m_Characters[m_CurrentIndex + 1].m_Name, m_Characters[m_CurrentIndex + 1].m_Image);
    
    m_CharacterInfoButtonFront.m_Button.onClick.AddListener (delegate {
      if (m_CurrentPlayerIndex != 2)
      {
        m_CharacterInfoButtonFront.SetOrder (m_CurrentPlayerIndex + 1);
        SelectCharacter (m_CurrentPlayerIndex, m_Characters[m_CurrentIndex]);
      }
    });

    m_CharacterInfoButtonBack.m_Button.onClick.AddListener (delegate {
      if (m_CurrentPlayerIndex != 2)
      {
        m_CharacterInfoButtonBack.SetOrder (m_CurrentPlayerIndex + 1);
        SelectCharacter (m_CurrentPlayerIndex, m_Characters[m_CurrentIndex + 1]);
      }
    });
  }

  void Update ()
  {
    if (m_CurrentPlayerIndex == 2) m_GameStartButton.SetActive (true);
  }

  void OnEnable ()
  {
    m_CurrentPlayerIndex = 0;
  }
  void OnDisable ()
  {
    m_CharacterInfoButtonFront.ResetOrder ();
    m_CharacterInfoButtonBack.ResetOrder ();
  }

  void SelectCharacter (int player, CharacterInfo character)
  {
    m_GameScene.Game.EnrollPlayer (new Player (m_GameScene.Game, character.m_Name));
    m_CurrentPlayerIndex ++;
  }
}

[System.Serializable]
public class CharacterInfo
{
  public string m_Name;
  public Sprite m_Image;

  public CharacterInfo (string name, Sprite image)
  {
    m_Name = name;
    m_Image = image;
  }
}

[System.Serializable]
public class CharacterInfoButton
{
  public Button m_Button;
  public Text m_Name;
  public Image m_Image;
  public GameObject m_OrderUI;

  public CharacterInfoButton (Text name, Image image)
  {
    m_Name = name;
    m_Image = image;
  }

  public void Update (string name, Sprite image)
  {
    m_Name.text = name;
    m_Image.sprite = image;
  }
  public void SetOrder (int order)
  {
    m_OrderUI.SetActive (true);
    m_OrderUI.GetComponentInChildren<Text>().text = order.ToString ();
  }
  public void ResetOrder ()
  {
    m_OrderUI.SetActive (false);
    m_OrderUI.GetComponentInChildren<Text>().text = "";
  }
}
