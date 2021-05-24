using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveMap
{
    public int coin;
    public int diamon;
    public int[] score;
    public bool[] wasUnlock;
    public SaveMap(DataManager dataManager)
    {
        coin = dataManager.coinGame;
        diamon = dataManager.diamonGame;

        score = new int[dataManager.listStates.Count];
        wasUnlock = new bool[dataManager.listStates.Count];
        for ( int i = 0; i < dataManager.listStates.Count; i ++)
        {
            score[i] = dataManager.listStates[i].score;
            wasUnlock[i] = dataManager.listStates[i].wasUnlock;
        }
       
    }
}
