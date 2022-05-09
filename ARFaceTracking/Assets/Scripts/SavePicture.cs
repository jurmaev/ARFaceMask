using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SavePicture : MonoBehaviour
{
    public bool takingScreenshot = false;
    private ARCameraBackground _arCameraBackground;
    private ARCameraManager _arCameraManager;
    [SerializeField] private RenderTexture texture;
    
    private void Start()
    {
        _arCameraBackground = GetComponent<ARCameraBackground>();
        _arCameraManager = GetComponent<ARCameraManager>();
        // camera = GetComponent<Camera>();
    }

    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        takingScreenshot = true;
        yield return new WaitForEndOfFrame();

        // var s = new Texture2D(_webCamTexture.width, _webCamTexture.height);
        // s.SetPixels(_webCamTexture.GetPixels());
        // s.Apply();
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        
        // // Make a new texture and read the active Render Texture into it.
        // Texture2D image = new Texture2D(texture.width, texture.height);
        // image.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        // image.Apply();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
        takingScreenshot = false;
    }
}