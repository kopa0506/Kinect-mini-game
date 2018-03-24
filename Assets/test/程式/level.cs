using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour {
    public int Score;
    //private

    public static level ins;

    void Awake()
    {

        if (ins == null)
        {
            ins = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else if (ins != this)
        {

            Destroy(gameObject);
        }
    }
    void Update()
    {
        Score = gamefunction.Instance.Score;
        if (Score > 30 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("easy"))
        {
            SceneManager.LoadScene("normal", LoadSceneMode.Single);
            //KinectManager.instance.IsPlaying = false;
        }

        if (Score > 60 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("normal"))
        {
            SceneManager.LoadScene("hard", LoadSceneMode.Single);
            //KinectManager.instance.IsPlaying = false;
        }
        if(Score > 50 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("hard"))
        {
            gamefunction.Instance.WinGame();
        }

    }
}
