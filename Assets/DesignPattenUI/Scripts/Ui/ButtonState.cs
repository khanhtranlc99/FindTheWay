using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
{
    public GameEvent gameEvent;
    public void _HandleOnClick()
    {
       switch(gameEvent)
        {

            case GameEvent.StartGame:
                this.FireEvent(GameEvent.StartGame);
                break;
            case GameEvent.LoadGame:
                this.FireEvent(GameEvent.LoadGame);
                break;
            case GameEvent.InGame:
                this.FireEvent(GameEvent.InGame);
                break;
            case GameEvent.Pause:
                this.FireEvent(GameEvent.Pause);
                break;
            case GameEvent.EndGame:
                this.FireEvent(GameEvent.EndGame);
                break;
            case GameEvent.Shop:
                this.FireEvent(GameEvent.Shop);
                break;
            case GameEvent.GameMode:
                this.FireEvent(GameEvent.GameMode);
                break;


        }



    }
}
