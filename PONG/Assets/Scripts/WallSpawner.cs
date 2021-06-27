using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject TopWall, BottomWall, LeftWall, RightWall;

    float extremeLeft, extremeRight, extremeTop, extremeBottom;
    Vector3 topWallPos, bottomWallPos, leftWallPos, rightWallPos;
    void Start()
    {
        extremeBottom = -Utilities.GetWorldHeight() / 2 - BottomWall.transform.localScale.y * 0.5f ;
        extremeTop = Utilities.GetWorldHeight() / 2 + TopWall.transform.localScale.y * 0.5f;
        extremeLeft = -Utilities.GetWorldWidth() / 2 - LeftWall.transform.localScale.x * 0.5f ;
        extremeRight = Utilities.GetWorldWidth() / 2 + RightWall.transform.localScale.x * 0.5f;

        topWallPos = new Vector3(0, extremeTop, 0);
        bottomWallPos = new Vector3(0, extremeBottom, 0);
        rightWallPos = new Vector3(extremeRight, 0, 0);
        leftWallPos = new Vector3(extremeLeft, 0, 0);

        TopWall.transform.localScale = new Vector3(Utilities.screenWidthInPoints, 1, 0);
        BottomWall.transform.localScale = new Vector3(Utilities.screenWidthInPoints, 1, 0);
        LeftWall.transform.localScale = new Vector3(1, Utilities.screenHeightInPoints, 0);
        RightWall.transform.localScale = new Vector3(1, Utilities.screenHeightInPoints, 0);

        


        GameObject topWallClone = Instantiate(TopWall, topWallPos,Quaternion.identity);
        topWallClone.name = "Top_Wall";
        topWallClone.transform.parent = transform;
        GameObject bottomWallClone = Instantiate(BottomWall, bottomWallPos, Quaternion.identity);
        bottomWallClone.name = "Bottom_Wall";
        bottomWallClone.transform.parent = transform;
        GameObject rightWallClone = Instantiate(RightWall, rightWallPos, Quaternion.identity);
        rightWallClone.name = "Right_Wall";
        rightWallClone.transform.parent = transform;
        GameObject leftWallClone = Instantiate(LeftWall, leftWallPos, Quaternion.identity);
        leftWallClone.name = "Left_Wall";
        leftWallClone.transform.parent = transform;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
