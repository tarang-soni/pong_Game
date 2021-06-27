using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static float screenWidthInPoints, screenHeightInPoints;


    // Start is called before the first frame update

    public static float GetWorldWidth()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
        
        return screenWidthInPoints;
    }

    public static float GetWorldHeight()
    {
        screenHeightInPoints = 2.0f * Camera.main.orthographicSize;
        return screenHeightInPoints;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
