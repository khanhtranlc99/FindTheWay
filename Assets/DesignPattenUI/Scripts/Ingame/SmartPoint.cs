using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPoint : MonoBehaviour
{
    public int postX;
    public int postY;
    //public Vector2 post;
    public int number;
    [SerializeField] private LineRenderer line;
    private void Start()
    {
        //_Find();
    }
    public void _Find()
    {
        var a = SpawnMap.spawnMap;
        line.positionCount = 2;
        for (int i = 0; i < a.map.GetLength(0); i++)
        {
            for (int j = 0; j < a.map.GetLength(1); j++)
            {
                if (a.map[this.postX -1, this.postY] == 3)
                {
                    line.SetPosition(0, this.transform.position);
                    line.SetPosition(1,new Vector2((a.map[this.postX - 1, this.postY] * a.amout + a.postX) * 2, this.postY * a.amout + a.postY));


                }
            }
        }
        Debug.Log(new Vector2((a.map[this.postX - 1, this.postY] * a.amout +a.postX)*2, this.postY));
    }
 
    //for (int i = 0; i < a.listSmartPoint.Count; i++)
    //{
    //    if ( this.post.x -1 == a.listSmartPoint[i].post.x )
    //    {
    //        line.SetPosition(0, this.transform.position);
    //        line.SetPosition(1,new Vector2(a.map[0,0],a.map[0,1]));


    //    }







}
