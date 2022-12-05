using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class handles the scaling of background of the game based on the screen size. 
// Thus it makes this game run on any device without any screen resolution constraints.
public class ScaleAdjustment : MonoBehaviour
{
    [SerializeField]
    GameObject backgroundImage;
    Camera mainCam;
    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        scaleBackgroundImageFitScreenSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // calculating the device screen aspect ratio
    // based on the device screen aspect ratio set camera aspect
    // scale back ground image based on camera aspect
    private void scaleBackgroundImageFitScreenSize()
    {
        // Step 1: Get Device Screen Aspect =============
        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);
        
        float srcHeight = Screen.height;
        float srcWidth = Screen.width;
        float DEVICE_SCREEN_ASPECT = srcWidth / srcHeight;

        // Step 2: Set Main Camera's aspect Device's Aspect 
        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        // Step 3: Scale Background Image to fit with Camera's Size 
        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;

        // Get Background Image Size;
        SpriteRenderer backgroundImageSR = backgroundImage.GetComponent<SpriteRenderer>();
        float bgIngH = backgroundImageSR.sprite.rect.height;
        float bgIngw = backgroundImageSR.sprite.rect.width;
        
        // Caculate Ratio for scaling...
        float bgIng_scale_ratio_Height = camHeight / bgIngH;
        float bgIng_scale_ratio_Width = camWidth / bgIngw;
        backgroundImage.transform.localScale = new Vector3(bgIng_scale_ratio_Width, bgIng_scale_ratio_Height, 1);

    }
}
