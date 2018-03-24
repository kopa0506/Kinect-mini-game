using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invader : MonoBehaviour {
    public float velocity = 0.03f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, -velocity, 0);
    }
    void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
    {
        if (col.tag == "ship") //如果碰撞的標籤是Ship
        {
            gamefunction.Instance.MinusLife(); //呼叫GameFunction底下的MinusLife()
            Destroy(gameObject); //消滅物件本身
        }
        if (col.tag == "bullet") //如果碰撞的標籤是Bullet
        {
            Destroy(col.gameObject); //消滅碰撞的物件
            gamefunction.Instance.AddScore(); //呼叫GameFunction底下的AddScore()
            Destroy(gameObject); //消滅物件本身
        }
    }
}
