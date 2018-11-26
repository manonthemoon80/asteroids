using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace asteroids {
    public class HighScore : MonoBehaviour
    {

        static public int score = 0;
        // Use this for initialization
        void Awake() {
            if (PlayerPrefs.HasKey("AsteroidHighScore"))
            {
                score = PlayerPrefs.GetInt("AsteroidHighScore");
            }
            PlayerPrefs.SetInt("AsteroidHighScore", GameManager.Score);
        }

        // Update is called once per frame
        void Update() {
            GUIText gt = this.GetComponent<GUIText>();
            gt.text = "High Score" + GameManager.Score;

            if(GameManager.Score > PlayerPrefs.GetInt ("AsteroidHighScore"))
            {
                PlayerPrefs.SetInt("AsteroidHighScore", GameManager.Score);
            }
        }
    }
}