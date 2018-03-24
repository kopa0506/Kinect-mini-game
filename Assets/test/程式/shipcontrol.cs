using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipcontrol : MonoBehaviour {
    public GameObject Bullet;
    public float Speed = 1f;
    private float time = 0;
    private float cdTime = 0.2f;

    private Vector3 playerPos = new Vector3(0, -3f, 0);

    // Update is called once per frame
    void Update () {

        time += Time.deltaTime;
        float xPos = transform.position.x;

        if (KinectManager.instance.IsAvailable)
        {
            xPos = KinectManager.instance.ShipPosition;
            if (KinectManager.instance.IsFire && time > cdTime)
            {
                Vector3 pos = gameObject.transform.position + new Vector3(0, 0.6f, 0);
                Instantiate(Bullet, pos, gameObject.transform.rotation);
                time = 0;
            }
        }
        else
        {
            xPos = transform.position.x + (Input.GetAxis("Horizontal") * Speed);
        }

        playerPos = new Vector3(Mathf.Clamp(xPos, -3f, 3f), -3f, 0f);

        transform.position = playerPos;
    }
}
/*if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0, 0.6f, 0);

            Instantiate(Bullet, pos, gameObject.transform.rotation);

        }*/