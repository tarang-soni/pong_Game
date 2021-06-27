using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScaler : MonoBehaviour
{
    private void Awake()
    {
        Utilities.GetWorldHeight();
        Utilities.GetWorldWidth();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Utilities bg = GetComponent<Utilities>();
        float width = Utilities.screenWidthInPoints;
        float height = Utilities.screenHeightInPoints;
        transform.localScale = new Vector3(width, height, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
