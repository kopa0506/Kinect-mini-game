using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomsidefunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col) //碰撞事件
    {
        if (col.tag == "emeny") //如果標籤是Emeny
        {
            gamefunction.Instance.MinusScore(); //呼叫GameFunction底下的MinusLife()
            Destroy(col.gameObject); //消滅碰撞的物件
        }
    }
}
