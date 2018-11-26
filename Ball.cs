using UnityEngine;
using System.Collections;

namespace asteroids
{
    public class Ball : MonoBehaviour
    {


        private Vector3 InitialLocation;
        private Rigidbody rb;
        public bool ballInPlay = false;
        public float speed;
        public Transform player;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 500);
            InitialLocation = transform.position;
            GetComponent<Rigidbody>().velocity = Vector2.up * speed;
        }

        public void increasespeed(float setspeed)
        {
            speed = setspeed;
        }
        public float getspeed() { return speed; }
        public float hit(Vector3 ballPos, Vector3 playerPos, float playerWidth)
        {
            return (ballPos.x - playerPos.x) / playerWidth;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                float x = hit(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.x);
                Vector2 dir = new Vector2(x, 1).normalized;

                GetComponent<Rigidbody>().velocity = dir * speed;
            }
        }
        private void Update()
        {
            if (!ballInPlay)
            {
                transform.position = player.position;
            }

            if (Input.GetMouseButtonDown(0))
            {
                ballInPlay = true;
                rb.isKinematic = false;
            }
            
        }

        public void StartBall()
        {
            transform.position = InitialLocation;
            GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-3.0f, 3.0f), speed);
        }

        public void StopBall()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}