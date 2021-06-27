using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float extremeLeft, extremeRight;
    Vector2 target;
    void Start()
    {
        extremeLeft = -Utilities.GetWorldWidth() / 2 * 0.73f;
        extremeRight = Utilities.GetWorldWidth() / 2 *0.73f;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movement *speed *Time.deltaTime, 0, 0));
       



        if (Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector2(target.x,transform.position.y) ;
        }

        if (transform.position.x >extremeRight)
        {
            transform.position = new Vector3(extremeRight, transform.position.y, 0);

        }
        if (transform.position.x<extremeLeft)
        {
            transform.position = new Vector3(extremeLeft, transform.position.y, 0);
        }
    }
}
