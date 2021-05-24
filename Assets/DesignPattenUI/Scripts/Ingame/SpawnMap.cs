using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMap : GameUIMannager
{
    public static SpawnMap spawnMap;
    [SerializeField] private  LineRenderer lineRenderer;
    [SerializeField] private Transform[,] postlineRenders; 
    [SerializeField] private PostObject goTranform;
    [SerializeField] private GameObject gameObjectParent;
    [SerializeField] private LineRenderer lineFindWay;
    [SerializeField] private List<GameObject> fouredge;
    [SerializeField] private Charecter charecterPre;
    public Charecter charecter;
    [SerializeField] private SmartPoint smartPoint;
    public  float postX;
    public  float postY;
    public float amout;
    public Flag flagPre;
    public Flag flag;
    public List<SmartPoint> listSmartPoint;
    public PostO postO;
    public List<PostO> listFindWay;
    public List<PostO> listPostO;
    public int[,] map;
    public List<PostO> tesst;
    private  int leftt;
    private int rightt;
    private int down;
    private int up;
    private int hnumber1;
    private int gnumber1;
    private int hnumber2;
    private int gnumber2;
    private int hnumber3;
    private int gnumber3;
    private int hnumber4;
    private int gnumber4;
    public bool wasReady;
    /// <summary>
    /// //EndGame
    /// </summary>
    public Text textNumberState;
    public Image imageTime;
    public float time;
    Coroutine coroutineTime;
    public int numberOfState;
    public int scoreOfState;
    public GameObject[] star;
    Coroutine startTime;
    Coroutine checkMap;
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
    private void Awake()
    {
        spawnMap = this;
    }
    void Start()
    {
        this.FireEvent(GameEvent.StartGame);

        //_SetUpMap();

    }
    void Update()
    {
      if( Input.GetKeyDown(KeyCode.Space))
        {
            //_FindWay();
            _FindWay();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //_FindWay();
            _DeleteMap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _SuportDelete();


        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _FindWay();


        }
    }

    public void _SetUpMap()
    {
        map = new int[11, 15];
      
        for ( int i = 0; i < map.GetLength(0); i++)
        {
            for ( int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = 0;

                map[1, 13] = 2; //char 
               
                if ( map[i,j] == 1)
                {
                   var a = Instantiate(goTranform, new Vector3(i * amout + postX, j * amout+ postY, 0), Quaternion.identity);
                    a.postX = i;
                    a.postY = j;
                    a.transform.SetParent(gameObjectParent.transform);
                    fouredge.Add(a.gameObject);
                }
                if ( map[i,j] == 2)
                {
                    var charec = Instantiate(charecterPre, new Vector3(i * amout + postX, j * amout + postY, 0), Quaternion.identity);
                    charec.postX = i;
                    charec.postY = j;
                    charecter = charec;
                }
              
            }
        }    
        _RadomMap();
        _RandomFinish();
        _FindWay();
    
      if ( checkMap != null)
        {
            StopCoroutine(_CheckMap());
            checkMap = null;
        }
        checkMap = StartCoroutine(_CheckMap());   
        
      
        //map[1, 13] = 0;
    }
    private void _RandomFinish()
    {
       

        for (int h = 1; h < 10; h++)
        {
            var a = Random.Range(1, 14);
            //y
            if (map[h, a] == 0 && charecter.postX +1 != h && charecter.postY -1 != a)
            {
                map[h, a] = 4;
    
                var g = Instantiate(flagPre, new Vector3(h * amout + postX, a * amout + postY, 0), Quaternion.identity);
              
                 flag = g;
                flag.postX = h;
                flag.postY = a;
                break;
            }

        }




    }
    private void _RadomMap()
    {


        for (int g = 0; g < 3; g++)
        {
            for (int h = 1; h < 10; h++)
            {
                var a = Random.Range(1, 13);
                //y
                if (map[h, a] == 0)
                {
                    map[h, a] = 3;

                }

            }
            //var a = Random.Range(1, 14);
            //if (map[3, 13] == 0)
            //{
            //    map[3, 13] = 3;

            //}


        }

        for ( int i = 0; i < map.GetLength(0); i ++)
        {
            for ( int j =0; j < map.GetLength(1); j++)
            {
                map[0, 0] = 3;
                map[0, j] = 3;
                map[i, 0] = 3;
                map[i, map.GetLength(1) - 1] = 3;
                map[map.GetLength(0) - 1, j] = 3;
                if ( map[i,j] == 3)
                {
                    var b = Instantiate(smartPoint, new Vector3(i * amout + postX, j * amout + postY, 0), Quaternion.identity);
                    b.postX = i;
                    b.postY = j;
                    b.number = map[i, j]; 
                    listSmartPoint.Add(b);
                }
                //if (map[i, j] == 0)
                //{
                //    var b = Instantiate(postO, new Vector3(i * amout + postX, j * amout + postY, 0), Quaternion.identity);
                //    b.postX = i;
                //    b.postY = j;
                //    b.number = map[i, j];
                //    listPostO.Add(b);
                //}

            



            }

        }

    }
    public void _DeleteMap()
    {
        var a = GameObject.FindGameObjectsWithTag("O");
        for( int i = 0; i < a.Length; i ++)
        {
            Destroy(a[i]);
        }
        var b = GameObject.FindGameObjectsWithTag("postO");
        for (int i = 0; i < b.Length; i++)
        {
            Destroy(b[i]);
        }
        _SetUpMap();

    }
    public void _FindWay()
    {
        Debug.Log(map[charecter.postX - 1, charecter.postY]);

              if (map[charecter.postX - 1, charecter.postY ] == 0)
                {
                    var a = System.Math.Abs((charecter.postX - 1) - charecter.postX);
                    var b = System.Math.Abs(charecter.postY - charecter.postY);
                    var c = System.Math.Abs((charecter.postX - 1) - flag.postX);
                    var d = System.Math.Abs(charecter.postY - flag.postY);
                    leftt = (a + b) + (c + d); //h +g
            hnumber1 = a + b;
            gnumber1 = c + d;
            Debug.Log(map[charecter.postX - 1, charecter.postY]);



                }
              else
        {
            leftt = 1000;
        }
                if (map[charecter.postX + 1, charecter.postY] == 0)
                {
                    var a = System.Math.Abs((charecter.postX + 1) - charecter.postX);
                    var b = System.Math.Abs(charecter.postY - charecter.postY);
                    var c = System.Math.Abs((charecter.postX + 1) - flag.postX);
                    var d = System.Math.Abs(charecter.postY - flag.postY);
                 rightt = (a + b) + (c + d);
            hnumber2 = a + b;
            gnumber2 = c + d;
            

      

        }
                else
        {
            rightt = 1000;
        }
                if (map[charecter.postX , charecter.postY-1] == 0)
                {
                    var a = System.Math.Abs(charecter.postX  - charecter.postX);
                    var b = System.Math.Abs((charecter.postY -1)- charecter.postY);
                    var c = System.Math.Abs(charecter.postX  - flag.postX);
                    var d = System.Math.Abs((charecter.postY - 1) - flag.postY);
                    down = (a + b) + (c + d);
            hnumber3 = a + b;
            gnumber3 = c + d;

        }
                else
        {
            down = 1000;
        }
                if (map[charecter.postX, charecter.postY + 1] == 0)
                {
                    var a = System.Math.Abs(charecter.postX - charecter.postX);
                    var b = System.Math.Abs((charecter.postY + 1) - charecter.postY);
                    var c = System.Math.Abs(charecter.postX - flag.postX);
                    var d = System.Math.Abs((charecter.postY + 1) - flag.postY);
                   up = (a + b) + (c + d);
            hnumber4 = a + b;
            gnumber4 = c + d;


        }
                else
        {
            up = 1000;
        }
               var p = System.Math.Min(leftt, rightt);
               var o = System.Math.Min(down, up);
               var  u = System.Math.Min(p, o);
        Debug.Log(u);
        if (u == leftt)
        {
            var a = Instantiate(postO, new Vector2((charecter.postX - 1) * amout + postX, charecter.postY * amout + postY), Quaternion.identity);
            a.postX = (charecter.postX - 1);
            a.postY = charecter.postY;
            a.total = leftt;
            listPostO.Add(a);
            a.hPointStart.text = "" + hnumber1;
            a.gPointFinish.text = "" + gnumber1;
            a.fTotal.text = "" + leftt;
            map[a.postX, a.postY] = 15;
        }
        if (u == rightt)
        {
            var a = Instantiate(postO, new Vector2((charecter.postX + 1) * amout + postX, charecter.postY * amout + postY), Quaternion.identity);
            a.postX = (charecter.postX + 1);
            a.postY = charecter.postY;
            a.total = rightt;
            listPostO.Add(a);
            a.hPointStart.text = "" + hnumber2;
            a.gPointFinish.text = "" + gnumber2;
            a.fTotal.text = "" + rightt;
            map[a.postX, a.postY] = 15;

        }
        if (u == down)
        {
            var a = Instantiate(postO, new Vector2(charecter.postX   * amout + postX, (charecter.postY - 1) * amout + postY), Quaternion.identity);
            a.postX = charecter.postX ;
            a.postY = charecter.postY - 1;
            a.total = down;
            listPostO.Add(a);
            a.hPointStart.text = "" + hnumber3;
            a.gPointFinish.text = "" + gnumber3;
            a.fTotal.text = "" + down;
            map[a.postX, a.postY] = 15;
        }
        if (u == up)
        {
            var a = Instantiate(postO, new Vector2(charecter.postX * amout + postX, (charecter.postY + 1) * amout + postY), Quaternion.identity);
            a.postX = charecter.postX;
            a.postY = charecter.postY + 1;
            a.total = up;
            listPostO.Add(a);
            a.hPointStart.text = "" + hnumber4;
            a.gPointFinish.text = "" + gnumber4;
            a.fTotal.text = "" + up;
            map[a.postX, a.postY] = 15;
        }







    }
    public IEnumerator _CheckMap()
    {
        yield return new WaitForSeconds(1);
        if (wasReady == true)
        {
            StopCoroutine(_CheckMap());
            this.FireEvent(GameEvent.InGame);
            _SuportDelete();
            time = 1;
            if (startTime != null)
            {
                StopCoroutine(_HandleTime()) ;
                startTime = null;
            }
            startTime = StartCoroutine(_HandleTime());
        }
        else
        {
            _DeleteMap();
            checkMap = StartCoroutine(_CheckMap());
        }


    }
    public void _SuportDelete()
    {
        for (int i = 0; i < listPostO.Count; i++)
        {
            map[listPostO[i].postX, listPostO[i].postY] = 0;
        }
        var b = GameObject.FindGameObjectsWithTag("postO");
        for (int i = 0; i < b.Length; i++)
        {
            Destroy(b[i]);
        }
        listPostO.Clear();
    }
    public IEnumerator _HandleTime()
    {  //nho hon 0.724 la 2 sao, nho hon 0.448 la 1 sao, nho hon 0.192 la O sao
        yield return new WaitForSeconds(1);
        time -= 0.02f;
        imageTime.fillAmount = time;
        if (time <= 0)
        {
            this.FireEvent(GameEvent.EndGame);
            StopCoroutine(coroutineTime);
        
        }
        else
        {
            coroutineTime = StartCoroutine(_HandleTime());
        }

    }
    public void _HandleEndGameState()
    {
        var a = DataManager.dataManager;
        textNumberState.text = "" + numberOfState;
        if (time < 0.724f)
        {
            scoreOfState = 2;
        }
        if (time < 0.448f)
        {
            scoreOfState = 1;
        }
        if (time < 0.192f)
        {
            scoreOfState = 0;
        }
        if (time > 0.724f)
        {
            scoreOfState = 3;
        }
        switch (scoreOfState)
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

        for (int i = 0; i < a.listStates.Count; i++)
        {
            if (a.listStates[i].id == numberOfState)
            {
                a.listStates[i].score = this.scoreOfState;        
                break;
            }
        }
        
    }
    public override void _HandleStartGame(object param)
    {
        base._HandleStartGame(param);
  
    }
    public override void _HandleLoadGame(object param)
    {
        base._HandleLoadGame(param);
        _SetUpMap();
     

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
        var a = GameObject.FindGameObjectsWithTag("O");
        for (int i = 0; i < a.Length; i++)
        {
            Destroy(a[i]);
        }
        var b = GameObject.FindGameObjectsWithTag("postO");
        for (int i = 0; i < b.Length; i++)
        {
            Destroy(b[i]);
        }
        StopAllCoroutines();
        _HandleEndGameState();
    }
    public override void _HandleGameMode(object param)
    {
        base._HandleGameMode(param);
        DataManager.dataManager.SpawnBtnState();
    }
    public override void _HandleShop(object param)
    {
        base._HandleShop(param);

    }
    ///Data
    public void _Down()
    {
        charecter._Down();
    }
    public void _Up()
    {
        charecter._Up();
    }
    public void _Left()
    {
        charecter._Left();
    }
    public void _Right()
    {
        charecter._Right();
    }

}
