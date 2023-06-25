using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FatherControl : MonoBehaviour
{
    private int TimeCount = 0;
    float XYrat = 0;
    float Yrat = 0;
    bool XYDirection = true;
    bool YDireation = true;
    
    void Start()
    {

    }
    
    void FixedUpdate()
    {

        if (XYrat >= 10 || XYrat <= -10)
        {
            XYDirection = !XYDirection;
        }
        if (YDireation)
        {
            XYrat += Time.deltaTime * 1;
            Yrat += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(XYrat, Yrat, -XYrat);
        }
        else
        {
            XYrat -= Time.deltaTime * 1;
            Yrat -= Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(XYrat, Yrat, -XYrat);
        }
        if (Yrat > 90 || Yrat < -90)
        {
            YDireation = !YDireation;
        }
        TimeCount++;
    }
}
