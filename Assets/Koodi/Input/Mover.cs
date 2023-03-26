using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Mover : MonoBehaviour
    {
        // Define lanes
        [SerializeField]
        private float[] lanePositions = { -0.06f, -1.81f, -3.31f };

        // Starts at the middle
        private int currentLane = 1;

        private Vector2 startTouchPosition;
        private Vector2 endTouchPosition;
        private Vector2 currentPosition;
        private bool stopTouch = false;

        // how long of a swipe to detect 
        [SerializeField]
        private float swipeRange;
        [SerializeField]
        private float tapRange;

        // the duration of the lane change animation
        [SerializeField]
        private float laneChangeDuration;

        // Starts at the middle put in use
        private void Awake()
        {
            transform.position = new Vector3(transform.position.x, lanePositions[currentLane]);
        }

        void Update()
        {
            Swipe();
        }

        public void Swipe()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;

                if (!stopTouch)
                {
                    // Move up if not at the 0 lane
                    if (Distance.y > swipeRange)
                    {
                        //Debug.Log("Up");
                        if (currentLane > 0)
                        {
                            currentLane--;
                            StartCoroutine(MoveToLane(lanePositions[currentLane]));
                        }
                        else if (currentLane <= 0)
                        {
                            currentLane = 0;
                            StartCoroutine(MoveToLane(lanePositions[currentLane]));
                        }

                        stopTouch = true;

                    }
                    // Move down if not at the 2 lane
                    else if (Distance.y < -swipeRange)
                    {
                        //Debug.Log("Down");
                        if (currentLane < 2)
                        {
                            currentLane++;
                            StartCoroutine(MoveToLane(lanePositions[currentLane]));
                        }
                        else if (currentLane >= 2)
                        {
                            currentLane = 2;
                            StartCoroutine(MoveToLane(lanePositions[currentLane]));
                        }

                        stopTouch = true;
                    }
                }
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                stopTouch = false;

                endTouchPosition = Input.GetTouch(0).position;

                Vector2 Distance = endTouchPosition - startTouchPosition;

                // Tap 
                if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
                {
                    //Debug.Log("Tap");
                }
            }
        }

        private IEnumerator MoveToLane(float targetPositionY)
        {
            float startTime = Time.time;
            float startPositionY = transform.position.y;

            while (Time.time < startTime + laneChangeDuration)
            {
                float t = (Time.time - startTime) / laneChangeDuration;
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(startPositionY, targetPositionY, t));
                yield return null;
            }

            transform.position = new Vector3(transform.position.x, targetPositionY);
        }
    }
}