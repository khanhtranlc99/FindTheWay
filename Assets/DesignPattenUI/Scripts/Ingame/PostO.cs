using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostO : MonoBehaviour
{
    public int postX;
    public int postY;
    public int number;
    public int total;
    public int hstart;
    public int leftt;
    public int rightt;
    public int down;
    public int up;
    public int leftdown;
    public int leftup;
    public int rightdown;
    public int rightup;
    public Text hPointStart;
    public Text gPointFinish;
    public Text fTotal;
    private int hnumber1;
    private int gnumber1;
    private int hnumber2;
    private int gnumber2;
    private int hnumber3;
    private int gnumber3;
    private int hnumber4;
    private int gnumber4;
    private int hnumber5;
    private int gnumber5;
    private int hnumber6;
    private int gnumber6;
    private int hnumber7;
    private int gnumber7;
    private int hnumber8;
    private int gnumber8;


    private void Start()
    {
        _AI();
        //test();
    }
    public void _AI()
    {
        
                var a = SpawnMap.spawnMap;

               if (a.map[this.postX - 1, this.postY] == 4 || a.map[this.postX + 1, this.postY] == 4 || a.map[this.postX, this.postY + 1] == 4 || a.map[this.postX, this.postY - 1] == 4)
                {
            a.wasReady = true;
            Debug.Log("ok");
            return;
        
                }
                if (a.map[this.postX - 1, this.postY] == 0)
                {

            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX -1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs(postY - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs(( postX -1 )- h.flag.postX);
            var d = System.Math.Abs(postY - h.flag.postY);
            leftt = l + b + c + d;
            hnumber1 = l + b;
            gnumber1 = c + d;
        }
                else
        {
            leftt = 1000;
        }
                    if (a.map[this.postX + 1, this.postY] == 0)
                {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX + 1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs(postY - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs(( postX + 1 )- h.flag.postX);
            var d = System.Math.Abs(postY - h.flag.postY);
            rightt = l + b + c + d;
            hnumber2 = l + b;
            gnumber2 = c + d;

        }
        else
        {
            rightt = 1000;
        }
                if (a.map[this.postX , this.postY-1] == 0)
                {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs(postX  - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY -1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs(postX  - h.flag.postX);
            var d = System.Math.Abs((postY -1) - h.flag.postY);
            down = l + b + c + d;
            hnumber3 = l + b;
            gnumber3 = c + d;

        }
        else
        {
            down = 1000;
        }
                if (a.map[this.postX, this.postY + 1] == 0)
                {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs(postX - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY + 1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs(postX - h.flag.postX);
            var d = System.Math.Abs((postY + 1) - h.flag.postY);
            up = l + b + c + d;
            hnumber4 = l + b;
            gnumber4 = c + d;
        }
                else
        {
            up = 1000;
        }

        if (a.map[this.postX-1, this.postY - 1] == 0)
        {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX -1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY - 1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs((postX -1)- h.flag.postX);
            var d = System.Math.Abs((postY - 1) - h.flag.postY);
            leftdown = l + b + c + d;
            hnumber5 = l + b;
            gnumber5 = c + d;

        }
        else
        {
            leftdown = 1000;
        }
        if (a.map[this.postX -1, this.postY + 1] == 0)
        {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX -1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY + 1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs((postX -1) - h.flag.postX);
            var d = System.Math.Abs((postY + 1) - h.flag.postY);
            leftup = l + b + c + d;
            hnumber6 = l + b;
            gnumber6 = c + d;
        }
        else
        {
            leftup = 1000;
        }
        if (a.map[this.postX + 1, this.postY + 1] == 0)
        {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX + 1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY + 1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs((postX + 1) - h.flag.postX);
            var d = System.Math.Abs((postY + 1) - h.flag.postY);
            rightup = l + b + c + d;
            hnumber7 = l + b;
            gnumber7 = c + d;

        }
        else
        {
            rightup = 1000;
        }
        if (a.map[this.postX + 1, this.postY - 1] == 0)
        {
            var h = SpawnMap.spawnMap;
            var l = System.Math.Abs((postX + 1) - h.listPostO[h.listPostO.Count - 1].postX);
            var b = System.Math.Abs((postY - 1) - h.listPostO[h.listPostO.Count - 1].postY);
            var c = System.Math.Abs((postX + 1) - h.flag.postX);
            var d = System.Math.Abs((postY - 1) - h.flag.postY);
            rightdown = l + b + c + d;
            hnumber8 = l + b;
            gnumber8 = c + d;
        }
        else
        {
            rightdown = 1000;
        }






        var p = System.Math.Min(leftt, rightt);
        var o = System.Math.Min(down, up);      
        var k = System.Math.Min(leftdown, leftup);
        var q = System.Math.Min(rightdown, rightup);
        var m = System.Math.Min(p, o);
        var n = System.Math.Min(k, q);
        var  u = System.Math.Min(m, n);
        if ( u <= a.listPostO[a.listPostO.Count -1].total)
        {
            if (u == leftt)
            {
                var t = Instantiate(this, new Vector2((this.postX - 1) * a.amout + a.postX, this.postY * a.amout + a.postY), Quaternion.identity);
                t.postX = (this.postX - 1);
                t.postY = this.postY;
                t.total = leftt;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber1;
                t.gPointFinish.text = "" + gnumber1;
                t.fTotal.text = "" + leftt;
                a.map[t.postX, t.postY] = 13;

            }
            if (u == rightt)
            {
                var t = Instantiate(this, new Vector2((this.postX + 1) * a.amout + a.postX, this.postY * a.amout + a.postY), Quaternion.identity);
                t.postX = (this.postX + 1);
                t.postY = this.postY;
                t.total = rightt;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber2;
                t.gPointFinish.text = "" + gnumber2;
                t.fTotal.text = "" + rightt;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == down)
            {
                var t = Instantiate(this, new Vector2((this.postX) * a.amout + a.postX, (this.postY - 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX;
                t.postY = (this.postY - 1);
                t.total = down;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber3;
                t.gPointFinish.text = "" + gnumber3;
                t.fTotal.text = "" + down;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == up)
            {
                var t = Instantiate(this, new Vector2((this.postX) * a.amout + a.postX, (this.postY + 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX;
                t.postY = (this.postY + 1);
                t.total = up;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber4;
                t.gPointFinish.text = "" + gnumber4;
                t.fTotal.text = "" + up;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == leftdown)
            {
                var t = Instantiate(this, new Vector2((this.postX-1) * a.amout + a.postX, (this.postY - 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX-1;
                t.postY = (this.postY - 1);
                t.total = leftdown;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber5;
                t.gPointFinish.text = "" + gnumber5;
                t.fTotal.text = "" + leftdown;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == leftup)
            {
                var t = Instantiate(this, new Vector2((this.postX - 1) * a.amout + a.postX, (this.postY + 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX - 1;
                t.postY = (this.postY + 1);
                t.total = leftup;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber6;
                t.gPointFinish.text = "" + gnumber6;
                t.fTotal.text = "" + leftup;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == rightup)
            {
                var t = Instantiate(this, new Vector2((this.postX + 1) * a.amout + a.postX, (this.postY + 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX + 1;
                t.postY = (this.postY + 1);
                t.total = rightup;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber7;
                t.gPointFinish.text = "" + gnumber7;
                t.fTotal.text = "" + rightup;
                a.map[t.postX, t.postY] = 13;
            }
            if (u == rightdown)
            {
                var t = Instantiate(this, new Vector2((this.postX + 1) * a.amout + a.postX, (this.postY - 1) * a.amout + a.postY), Quaternion.identity);
                t.postX = this.postX + 1;
                t.postY = (this.postY - 1);
                t.total = rightdown;
                a.listPostO.Add(this);
                t.hPointStart.text = "" + hnumber8;
                t.gPointFinish.text = "" + gnumber8;
                t.fTotal.text = "" + rightdown;
                a.map[t.postX, t.postY] = 13;
            }
        }
     
     





    }
    public void test()
    {
        var a = SpawnMap.spawnMap;
        if (a.map[this.postX - 1, this.postY] == 4 || a.map[this.postX + 1, this.postY] == 4 || a.map[this.postX, this.postY + 1] == 4 || a.map[this.postX, this.postY - 1] == 4)
        {
            return;
        }

        if (a.map[this.postX - 1, this.postY] == 0)
        {

            var h = Instantiate(this, new Vector3((this.postX - 1) * a.amout + a.postX, this.postY * a.amout + a.postY, 0), Quaternion.identity);
            h.postX = this.postX - 1;
            h.postY = this.postY;

        }
        if (a.map[this.postX + 1, this.postY] == 0)
        {
            var h = Instantiate(this, new Vector3((this.postX + 1) * a.amout + a.postX, this.postY * a.amout + a.postY, 0), Quaternion.identity);
            h.postX = this.postX + 1;
            h.postY = this.postY;
            

        }
        if (a.map[this.postX, this.postY - 1] == 0)
        {
            var h = Instantiate(this, new Vector3(this.postX * a.amout + a.postX, (this.postY -1)* a.amout + a.postY, 0), Quaternion.identity);
            h.postX = this.postX ;
            h.postY = this.postY-1;

        }
        if (a.map[this.postX, this.postY + 1] == 0)
        {
            var h = Instantiate(this, new Vector3(this.postX * a.amout + a.postX, (this.postY+1) * a.amout + a.postY, 0), Quaternion.identity);
            h.postX = this.postX ;
            h.postY = this.postY+1;
        }
 
    }
    private void _Test2(int postX, int postY)
    {
        // slotion là check 4 xung quang điểm bắt đầu tìm điểm thỏa mãn công thức rồi đệ quy sinh ra điểm đến khi chạm đích
        var a = SpawnMap.spawnMap;
        var l = System.Math.Abs(postX - a.charecter.postX);  //charecter  = điểm bắt đầu
        var b = System.Math.Abs(postY - a.charecter.postY);
        var c = System.Math.Abs(postX - a.flag.postX);     //flag = đích
        var d = System.Math.Abs(postY - a.flag.postY);
        var n = l+b;
        var e = (l + b) + (c + d);   //tổng
   
            //nếu đã có phần tử rồi 
            if (e >= a.listPostO[a.listPostO.Count - 1].total /*&& hstart > a.listPostO[a.listPostO.Count - 1].hstart*/)
            {
        
                var h = Instantiate(this, new Vector3(this.postX * a.amout + a.postX, postY  * a.amout + a.postY, 0), Quaternion.identity);
                h.postX = this.postX;
                h.postY = this.postY + 1;
                h.total = e;
                hstart = n;
                a.listPostO.Add(h);
                a.map[postX, postY] = 13;
            }
        



    }


}
