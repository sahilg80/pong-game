using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAdjustment : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer boundary;

    // Start is called before the first frame update
    void Start()
    {
        float screenRatio = (float)Screen.width/(float)Screen.height;
        float targetRatio = boundary.bounds.size.x / boundary.bounds.size.y;
        if (screenRatio>=targetRatio)
        {
            Camera.main.orthographicSize = boundary.bounds.size.y/2;   
        }
        else
        {
            float differenceINSize = targetRatio/screenRatio;
            Camera.main.orthographicSize = boundary.bounds.size.y/2 * differenceINSize;
        }
        // float orthoSize = boundary.bounds.size.x * Screen.height/Screen.width * 0.5f;
        // Camera.main.orthographicSize = orthoSize;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
