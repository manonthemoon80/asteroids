using UnityEngine;
using System.Collections;
using asteroids;


public class DeadZone : MonoBehaviour
{

    public GameManager GM;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
          GM.LoseLife();
        }
    }
}
