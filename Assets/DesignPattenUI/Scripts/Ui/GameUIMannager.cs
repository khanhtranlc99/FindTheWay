using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIMannager : MonoBehaviour
{
    public GameEvent gameEvent;
    public UiStartGame uiStartGame;
    public UiLoadGame uiLoadGame;
    public UiInGame uiInGame;
    public UiPause uiPause;
    public UiEndGame uiEndGame;
    public UiGameMode uiGameMode;
    public UiShop uiShop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnEnable()
    {
       
        
    }
    public void _test()
    { 
         switch(gameEvent)
        {
            case GameEvent.StartGame:
              
                break;
            case GameEvent.LoadGame: 
              
                break;
             case GameEvent.InGame:
           
                break;
            case GameEvent.Pause:
          
                break;
            case GameEvent.EndGame:
           
                break;
            case GameEvent.Shop:
           
                break;
            case GameEvent.GameMode:
             
                break;
        }
    }
    public void ChangePanel(GameEvent gameEvent)
    {
        uiStartGame.Show(gameEvent == GameEvent.StartGame);
        uiLoadGame.Show(gameEvent == GameEvent.LoadGame);
        uiInGame.Show(gameEvent == GameEvent.InGame);
        uiPause.Show(gameEvent == GameEvent.Pause);
        uiEndGame.Show(gameEvent == GameEvent.EndGame);
        uiShop.Show(gameEvent == GameEvent.Shop);
        uiGameMode.Show(gameEvent == GameEvent.GameMode); 
    }

    public virtual void _HandleStartGame(object param)
    {
        ChangePanel(GameEvent.StartGame);
        Debug.Log("StarGame");
    
    }
    public virtual void _HandleLoadGame(object param)
    {
        ChangePanel(GameEvent.LoadGame);
        Debug.Log("LoadGame");

    }
    public virtual void _HandleInGame(object param)
    {
        ChangePanel(GameEvent.InGame);
        Debug.Log("InGame");

    }
    public virtual void _HandlePause(object param)
    {
        ChangePanel(GameEvent.Pause);
        Debug.Log("Pause");

    }
    public virtual void _HandleEndGame(object param)
    {
        ChangePanel(GameEvent.EndGame);
        Debug.Log("EndGame");

    }
    public virtual void _HandleGameMode(object param)
    {
        ChangePanel(GameEvent.GameMode);
        Debug.Log("GameMode");

    }
    public virtual void _HandleShop(object param)
    {
        ChangePanel(GameEvent.Shop);
        Debug.Log("Shop");

    }



}
