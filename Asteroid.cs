using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace asteroids
{
    public class Asteroid : MonoBehaviour
    {

        public GameObject asteroidparticle;
        private Text scoreGT;

        public GameObject powerupLife;
        //public List<GameObject> powerup;

        private void Start()
        {
            scoreGT = GameObject.Find("Score Text").GetComponent<Text>(); ;
        }

        void OnCollisionEnter(Collision collision)
        {
            Instantiate(asteroidparticle, transform.position, Quaternion.identity);
            //GameManager.instance.DestroyAsteroids();
            Destroy(gameObject);

            PlayerPrefs.SetInt("Score", GameManager.Score); //?
            GameManager.Score += 20;
            scoreGT.text = "Score:" + GameManager.Score.ToString();

            if (GameManager.Score > HighScore.score)
            {
                HighScore.score = GameManager.Score;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            //this is not happening

            gameObject.SetActive(false);

            GameManager.AsteroidsAlive--;
        }


    }
}