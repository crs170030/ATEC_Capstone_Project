using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWobble : MonoBehaviour
{
    public bool Wobble = false;
    
    public float scaleChangeRate = 0.002f;
    public float upperLimitAdd = 0.07f;
    public float lowerLimitAdd = 0f;
    float upperLimit, lowerLimit;
    Vector3 scaleChange;
    bool isGrowing = true;

    public bool Bounce = false;

    public float positionChangeRate = 0.2f;
    public float bounceHeight = 10f;
    Vector3 positionChange;
    bool isGoingUp = true;
    float totalChange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(scaleChangeRate, scaleChangeRate, scaleChangeRate);
        upperLimit = transform.localScale.y + upperLimitAdd;
        lowerLimit = transform.localScale.y - lowerLimitAdd;

        positionChange = new Vector3(0, positionChangeRate, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Wobble)
        {
            if (isGrowing)
            {
                transform.localScale += scaleChange;

                if(transform.localScale.y > upperLimit)
                    isGrowing = false;
            }
            else
            {
                transform.localScale -= scaleChange;

                if (transform.localScale.y < lowerLimit)
                    isGrowing = true;
            }
        }
        if (Bounce)
        {
            if (isGoingUp)
            {
                transform.position += positionChange;
                totalChange += positionChangeRate;

                if (totalChange >= bounceHeight)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                transform.position -= positionChange;
                totalChange -= positionChangeRate;

                if (totalChange <= 0)
                {
                    isGoingUp = true;
                    //totalChange = 0;
                }
            }
        }
    }
}
