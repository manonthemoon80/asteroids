using UnityEngine;
using System.Collections;

namespace asteroids
{
    public class Player : MonoBehaviour
    {

        private void Update()
        {

          
        }
        public void StopPlayer()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}

