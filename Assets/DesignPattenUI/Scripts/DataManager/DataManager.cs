using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{ public static DataManager dataManager;
    public int coinGame;
    public int diamonGame;
    [SerializeField] BtnState Btnstate;
    [SerializeField] public List<State> listStates;
    [SerializeField] private List<BtnState> listBtnStates;
    public GameObject conten;
    public bool wasSpawnBtn;
    string path;
    
    private void Awake()
    {
        dataManager = this;
        path = Application.persistentDataPath + "dataMap";
        //File.Delete(path);
    }
    private void Start()
    {
        _Load();
    }
    private void OnEnable()
    {
    
    }
    private void Update()
    {
        
    }
    
    public void SpawnBtnState()
    {    if ( wasSpawnBtn == false)
        {
            for (int i = 0; i < listStates.Count; i++)
            {
                listStates[i].id = i;             
                var a = Instantiate(Btnstate);
                a.transform.SetParent(conten.transform);
                a.id = i;
                a.textId.text = "" + a.id;
                listBtnStates.Add(a);

            }
            _HandelListState();
            wasSpawnBtn = true;
        }
       else
        {
            _HandelListState();
          
            return;
        }
    }
    private void _HandelListState()
    {


        for (int i = 0; i < listBtnStates.Count; i++)
        {
            listBtnStates[i].score = listStates[i].score;
            listBtnStates[i].wasUnlock = listBtnStates[i].wasUnlock;
            listBtnStates[0].wasUnlock = true;
            if (listBtnStates[i].score >= 1)
            {
                listBtnStates[i + 1].wasUnlock = true;
                listStates[i + 1].wasUnlock = true;
            }
            listBtnStates[i]._HandleBtn();
            _Save();


        }
      


    }

    public void _ResetData()
    {
        File.Delete(path);
        path = Application.persistentDataPath + "dataMap";
        for (int i = 0; i < listBtnStates.Count; i++)
        {
            listStates[i].score = 0;
            listStates[i].wasUnlock = false;
            listBtnStates[0].wasUnlock = true;
            listBtnStates[i].score = listStates[i].score;
            listBtnStates[i].wasUnlock = listBtnStates[i].wasUnlock;
            listBtnStates[i]._HandleBtn();
          
        }
        _Save();
        SceneManager.LoadScene(0);
    }
    public void _Tutorial()
    {
        SceneManager.LoadScene(1);
    }    
    public void AddCoinOrDiamon( int coin , int diamon )
    {
        coinGame += coin;
        diamonGame += diamon;    
        _Save();
    }    
    public void _Save()
    {

        SaveMap saveMap = new SaveMap(this);
        SaveSystem.SaveData<SaveMap>(saveMap, path);

    }
    public void _Load()
    {
        if (File.Exists(path))
        {
            SaveMap data = SaveSystem.LoadData<SaveMap>(path);
            coinGame = data.coin;
            diamonGame = data.coin;
            for (int i = 0; i < listStates.Count; i++)
            {
                listStates[i].score = data.score[i];
                listStates[i].wasUnlock = data.wasUnlock[i];
            }


        }

    }

}
[System.Serializable]
public class State
{     
    public int id;
    public bool wasUnlock;
    public int score;
}
