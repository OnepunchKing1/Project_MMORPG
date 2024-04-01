using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    Coroutine co;

    protected override void Init()
    {
        base.Init();
        _SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
                
    }
  
    public override void Clear()
    {
        
    }    
    
    void Update()
    {
        
    }}
