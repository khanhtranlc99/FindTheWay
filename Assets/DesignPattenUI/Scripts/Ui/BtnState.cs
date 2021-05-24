using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnState : MonoBehaviour
{  
    public Text textId;
    public GameObject[] star;
    public int id;
    public int score;
    public bool wasUnlock;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void _HandleBtn()
    {
        if (wasUnlock == true)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }


        switch (score)
        {
            case 0:
                star[0].SetActive(false);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;
            case 1:
                star[0].SetActive(true);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;
            case 2:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(false);
                break;
            case 3:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(true);
                break;
        }
       


    }    
    public void _HandelOnClick()
    {
        SpawnMap.spawnMap.numberOfState = id;


        this.FireEvent(GameEvent.LoadGame);
       

    }
    
}
