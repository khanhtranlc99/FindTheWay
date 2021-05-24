using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Charecter : MonoBehaviour
{

    public int postX;
    public int postY;
    public bool wasClick;
    public Vector2 post;
    [SerializeField] GameObject charec;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _Down();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _Up();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _Right();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _Left();
        }
       


    }
    public void _Down()
    {
        var a = SpawnMap.spawnMap;
        if (a.map[this.postX, this.postY - 1] == 0 || a.map[this.postX, this.postY - 1] == 13 || a.map[this.postX, this.postY - 1] == 15 || a.map[this.postX, this.postY - 1] == 4)
        {
            this.transform.DOMoveY((this.postY - 1) * a.amout + a.postY, 0.5f);
            this.postY = this.postY - 1;
        }
        charec.gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
        _CheckFinish();
        Debug.Log("down " +a.map[this.postX, this.postY - 1]);
    }
    public void _Up()
    {
        var a = SpawnMap.spawnMap;
        if (a.map[this.postX, this.postY + 1] == 0 || a.map[this.postX, this.postY + 1] == 13 || a.map[this.postX, this.postY + 1] == 15 || a.map[this.postX, this.postY + 1] == 4)
        {
            this.transform.DOMoveY((this.postY + 1) * a.amout + a.postY, 0.5f);
            this.postY = this.postY + 1;
        }
        charec.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        Debug.Log("Up " + a.map[this.postX, this.postY + 1]);
        _CheckFinish();
    }
    public void _Right()
    {
        var a = SpawnMap.spawnMap;
        if (a.map[this.postX + 1, this.postY] == 0 || a.map[this.postX + 1, this.postY] == 13 || a.map[this.postX + 1, this.postY] == 15 || a.map[this.postX + 1, this.postY] == 4)
        {
            this.transform.DOMoveX((this.postX + 1) * a.amout + a.postX, 0.5f);
            this.postX = this.postX + 1;
        }
        charec.gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);
        Debug.Log("Right " + a.map[this.postX +1, this.postY ]);
        _CheckFinish();
    }
    public void _Left()
    {
        var a = SpawnMap.spawnMap;
        if (a.map[this.postX - 1, this.postY] == 0 || a.map[this.postX - 1, this.postY] == 13 || a.map[this.postX - 1, this.postY] == 15 || a.map[this.postX - 1, this.postY] == 4)
        {
            this.transform.DOMoveX((this.postX - 1) * a.amout + a.postX, 0.5f);
            this.postX = this.postX - 1;
        }
        charec.gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
        Debug.Log("left " + a.map[this.postX - 1, this.postY]);
        _CheckFinish();
    }
    public void _CheckFinish() 
    {
        var a = SpawnMap.spawnMap;
        if (a.flag.postX ==  this.postX && a.flag.postY == this.postY )
        {
            Debug.Log("EndGame");
            this.FireEvent(GameEvent.EndGame);
        }
    }
    private void _Swipe()
    {
        if( Input.GetMouseButtonDown(0))
        {
            wasClick = true;
            post = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if ( Input.GetMouseButton(0))
        {
            if ( wasClick == true)
            {
                var a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (a.x > post.x && a.y == post.y)
                {
                    _Right();
                    wasClick = false;
                    return;
                }
                if ( a.x < post.x && a.y == post.y)
                {
                    _Left();
                    wasClick = false;
                    return;
                }
                if (a.y > post.y && a.x == post.x)
                {
                    _Up();
                    wasClick = false;
                    return;
                }
                if (a.y < post.y && a.x == post.x)
                {
                    _Down();
                    wasClick = false;
                    return;
                }

            }
         
        }
        if ( Input.GetMouseButtonUp(0))
        {
            wasClick = false;
        }



    }
 
}
