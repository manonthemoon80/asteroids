using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace asteroids
{
    public class GameManager : MonoBehaviour
    {

        public enum GameState
        {
            Start,
            Playing,
            Won,
            LostALife,
            LostAllLives,
        }

        public static int lives = 3;
        public static int Score = 0;
        public static int AsteroidsAlive = 36;
        //public int asteroids;
        // public int powerupchance = 3;
        public float resetDelay = 1f;
        public Text liveText;
        public Text scoreText;
        public GameObject winner;
        public GameObject asteroidsPrefab;
        public GameObject player;
        public GameObject ball;
        public Ball Ball;
        public Player Player;
        public Powerups powerups;
        private static GameState CurrentGameState = GameState.Start;
        private GameObject[] asteroids;

        private GameObject clonePlayer;
        // public GameObject[] powerup;
        public GameObject deadzone;
        //uses instance of the class itself
        public static GameManager instance = null;

        bool InputTaken()
        {
            return Input.touchCount > 0 || Input.GetMouseButtonUp(0);
        }

        //public void triggerPickup(Powerups powerup)
        //{
        //    switch (Powerups.type)
        //    {
        //        case Powerups.upgrades.Fast:
        //            Fast();
        //            break;
        //    }
        //}
        void CheckGameOver()
        {
            if (AsteroidsAlive < 1)
            {
                winner.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
            }
            if (lives < 1)
            {
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
            }
        }
        // Update is called once per frame
        void Reset()
        {
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);


        }

        private void Start()
        {
            //checks and see if there is one game manager instance
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            liveText = GameObject.Find("Life Text").GetComponent<Text>();
            liveText.text = "Lives:" + lives;
        }

        public void LoseLife()
        {
            if (lives > 0)
            {
                lives--;
                liveText.text = "Lives:" + lives;
                //Invoke("SpawnPlayer", resetDelay);
                Ball.ballInPlay = false;
                CheckGameOver();
            }

            if (lives == 0)
            {
                liveText.text = "Game over.";
                CurrentGameState = GameState.LostAllLives;
            }

            //Ball.StopBall();
            //Player.StopPlayer();
        }
       void SpawnPlayer()
        {
            clonePlayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
        }
        private void Update()
        {

            switch (CurrentGameState)
            {
                //start game
                case GameState.Start:
                    if (InputTaken())
                    {
                        //text.text = string.Format("Lives: {0} Score {1}", lives, Score);
                        CurrentGameState = GameState.Playing;
                        //Ball.StartBall();
                    }


                    break;

                case GameState.Playing:
                    break;

                case GameState.Won:
                    //win game
                    if (InputTaken())
                    {
                        CheckGameOver();
                        Restart();
                        //Ball.StartBall();
                        //text.text = string.Format("Lives: {0} Score {1}", lives, Score);
                        CurrentGameState = GameState.Playing;
                    }
                    break;

                case GameState.LostALife:
                    //lose 1 loife
                    if (InputTaken())
                    {
                        //text.text = string.Format("Lives: {0} Score {1}", lives, Score);
                        CurrentGameState = GameState.Playing;
                        

                    }
                    break;

                case GameState.LostAllLives:
                    //lose all life
                    if (InputTaken())
                    {
                        CheckGameOver();
                        Restart();
                        //Ball.StartBall();
                        //text.text = string.Format("Lives: {0} Score {1}", lives, Score);
                        CurrentGameState = GameState.Playing;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Restart()
        {
            foreach(var item in asteroids)
            {
                item.SetActive(true);
                item.GetComponent<Ball>();
            }
            lives = 3;
            Score = 0;
        }
        public void DestroyAsteroids()
        {
            AsteroidsAlive--;
            CheckGameOver();
        }
    }
}
