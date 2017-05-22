using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {


    private float speed = 25.0f;
    private int coridorNum;
    private float maxHorizontal;
    private float maxVertical;
    private Vector2 startposition;
    private int couldBeSwipe;
    private  float startTime;
    private float comfortZone;

	// Use this for initialization
	void Start () {


        maxVertical = Camera.main.orthographicSize;
        maxHorizontal = maxVertical * Camera.main.aspect;
        coridorNum = 0;
        couldBeSwipe = 0;
        comfortZone = 100.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f);

        Vector3 newPosition =
            new Vector3(Mathf.Clamp(transform.position.x, -maxHorizontal, maxHorizontal),
                        Mathf.Clamp(transform.position.y, -maxVertical, maxVertical),
                        0.0f);

        transform.position = newPosition;
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    couldBeSwipe = 1;
                    startposition = t.position;
                    startTime = Time.time;
                    break;
                case TouchPhase.Moved:
                    if (Mathf.Abs(t.position.y - startposition.y) > comfortZone)
                    {
                        couldBeSwipe = 0;
                    }
                    break;
                case TouchPhase.Stationary:
                    couldBeSwipe = 0;
                    break;
                case TouchPhase.Ended:
                    float swipeTime = Time.time - startTime;
                    float swipeDist = (t.position - startposition).magnitude;

                    if ((swipeDist > 0))
                    {
                        // It's a swipe!
                        float swipeDirection = Mathf.Sign(t.position.x - startposition.x);
                        if (swipeDirection >0)
                        {
                            if (coridorNum < 1)
                            {
                                coridorNum++;
                            }

                        }
                        else if (swipeDirection < 0)
                        {

                            if (coridorNum > -1)
                            {
                                coridorNum--;
                            }
                        }
                    }
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (coridorNum < 1)
            {
                coridorNum++;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if (coridorNum > -1)
            {
                coridorNum--;
            }
        }
       
        changeCoridorNum(coridorNum);
	}


    private void changeCoridorNum(int coridorNum)
    {
        Vector3 newPosition = new Vector3(0.0f,((coridorNum ) * 2.0f), 0.0f);
        transform.position = newPosition;
    }
}
