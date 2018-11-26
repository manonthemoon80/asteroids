using UnityEngine;
using System.Collections;
namespace asteroids
{
    public class Touchcontrol : MonoBehaviour {


        private bool dragging = false;
        private float distance;
        int touchCount = 0;
        Touch lastTouch;

        float input;

        public float speed = 150;

        public Transform LeftTransform;
        public Transform RightTransform;

        void OnMouseDown()
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }

        private void OnGUI()
        {
            if (Input.touchCount > 0)
            {
                GUI.Label(new Rect(10, 10, 200, 50), "position" +
                    lastTouch.position);
                GUI.Label(new Rect(10, 10, 200, 50), "Finger Id" +
                  lastTouch.fingerId);
                GUI.Label(new Rect(10, 10, 200, 50), "Position Change" +
                  lastTouch.deltaPosition);
                GUI.Label(new Rect(10, 10, 200, 50), "Time Passed" +
                  lastTouch.deltaTime);
                GUI.Label(new Rect(10, 10, 200, 50), "Tap Count" +
                   lastTouch.tapCount);
                GUI.Label(new Rect(10, 10, 200, 50), "Phase" +
                   lastTouch.phase);

            }
        }
        void OnMouseUp()
        {
            dragging = false;
        }

        void Update()
        {

            if (Input.touchCount > 0)
            {
                input = Input.touches[0].position.x >= Screen.width / 2 ? 1f : -1f;
            }

            transform.Translate(new Vector2(input * speed * Time.deltaTime, 0));

            float x = Mathf.Clamp(transform.position.x, LeftTransform.position.x, RightTransform.position.x);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            if (dragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                Vector3 myvec = new Vector3(rayPoint.x, transform.position.y, transform.position.z);
                transform.position = myvec;

            }

            if (transform.position.x < LeftTransform.position.x)
            {
                transform.position = new Vector3(LeftTransform.position.x, transform.position.y, transform.position.z);
            }
            if (transform.position.x > RightTransform.position.x)
            {
                transform.position = new Vector3(RightTransform.position.x, transform.position.y, transform.position.z);
            }
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            }

        }

    }
}