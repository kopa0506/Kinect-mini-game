using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用UI

public class gamefunction : MonoBehaviour {
    private List<GameObject> emeny_copylist = new List<GameObject>();
    public GameObject emeny; //宣告物件，名稱Emeny
    public GameObject ship; //宣告物件，名稱Ship
    public float time; //宣告浮點數，名稱time

    bool product_emeny = true;

    public GameObject LoseText;
    public Text ScoreText; //宣告一個ScoreText的text
    public int Score = 0; // 宣告一整數 Score
    public Text LifeText; //宣告一個LifeText的text
    public int Life = 3; // 宣告一整數 Life
    public static gamefunction Instance; // 設定Instance，讓其他程式能讀取GameFunction裡的東西
    void Start () {
        Instance = this; //指定Instance這個程式
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime; //時間增加
        if (time > 0.5f) //如果時間大於0.5(秒)
        {
            Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            if(product_emeny == true)
            {
                GameObject thisobject = Instantiate(emeny, pos, transform.rotation) as GameObject;
                emeny_copylist.Add(thisobject);//產生敵人
            }
            time = 0f; //時間歸零
        }
    }

    public void AddScore()
    {
        Score += 1; //分數+1
        ScoreText.text = "Score: " + Score; // 更改ScoreText的內容
    }
    public void MinusScore()
    {
        Score -= 1; //分數+1
        ScoreText.text = "Score: " + Score; // 更改ScoreText的內容
    }
    public void MinusLife()
    {
        StartCoroutine(TurnRed());
        Life -= 1; //分數+1
        if (Life == 0)
            EndGame();
        LifeText.text = "Life: " + Life; // 更改ScoreText的內容
    }
    
    public void EndGame()
    {
        product_emeny = false;
        foreach(GameObject d in emeny_copylist)
        {
            Destroy(d);
        }
        emeny_copylist.Clear();
        ship.SetActive(false);
        LoseText.SetActive(true);
    }
    private IEnumerator TurnRed()
    {
        Color _red = Color.red;
        _red.a = 0.5f;
        Color col = ship.GetComponent<SpriteRenderer>().color;
        ship.GetComponent<SpriteRenderer>().color = _red;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = col;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = _red;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = col;
        yield return new WaitForSeconds(0.2f);
    }
}
