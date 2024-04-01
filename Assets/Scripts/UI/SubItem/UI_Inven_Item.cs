using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UIBase
{
   enum Gameobjects
    {
        ItemIcon,
        ItemNameText
    }
    string _name;
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(Gameobjects));
        Get<GameObject>((int)Gameobjects.ItemNameText).GetComponent<Text>().text = _name;

        Get<GameObject>((int)Gameobjects.ItemIcon).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭@ {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
