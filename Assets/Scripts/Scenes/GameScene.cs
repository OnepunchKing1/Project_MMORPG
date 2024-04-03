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
        //Managers.UI.ShowSceneUI<UI_Inven>();        
        
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        gameObject.GetOrAddComponent<CursorController>();

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChang");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        // Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);
                
    }
  
    public override void Clear()
    {
        
    }    
    
    void Update()
    {
        
    }}
