using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {
    public float velocity = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, -velocity * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
    {
        if (col.tag == "ship") //如果碰撞的標籤是Ship
        {
            gamefunction.Instance.MinusLife(); //呼叫GameFunction底下的MinusLife()
            Destroy(gameObject); //消滅物件本身
        }
    }
}
