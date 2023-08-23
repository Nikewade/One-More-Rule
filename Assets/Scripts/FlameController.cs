using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    public float onTime = 4;
    public float offTime = 2;
    private int timeTicks = 0;
    private int ifOn = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeTicks++;
        if (ifOn == 1 && timeTicks >= onTime * 50)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            timeTicks = 0;
            ifOn = 0;
        }
        else if (ifOn == 0 && timeTicks >= offTime * 50)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            timeTicks = 0;
            ifOn = 1;
        }
    }
}
