using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreManager : GameUIMannager
{

    // Start is called before the first frame update
    void Start()
    {
        this.FireEvent(GameEvent.StartGame);
    }
    public void OnEnable()
    {
        this.RegisterListener(GameEvent.StartGame, _HandleStartGame);
        this.RegisterListener(GameEvent.LoadGame, _HandleLoadGame);
        this.RegisterListener(GameEvent.InGame, _HandleInGame);
        this.RegisterListener(GameEvent.Pause, _HandlePause);
        this.RegisterListener(GameEvent.EndGame, _HandleEndGame);
        this.RegisterListener(GameEvent.Shop, _HandleShop);
        this.RegisterListener(GameEvent.GameMode, _HandleGameMode);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public override void _HandleStartGame(object param)
    {
        base._HandleStartGame(param);
    
    }
    public override void _HandleLoadGame(object param)
    {
        base._HandleLoadGame(param);

    }
    public override void _HandleInGame(object param)
    {
        base._HandleInGame(param);

    }
    public override void _HandlePause(object param)
    {
        base._HandlePause(param);
    }
    public override void _HandleEndGame(object param)
    {
        base._HandleEndGame(param);
    }
    public override void _HandleGameMode(object param)
    {
        base._HandleGameMode(param);

    }
    public override void _HandleShop(object param)
    {
        base._HandleShop(param);

    }

}
