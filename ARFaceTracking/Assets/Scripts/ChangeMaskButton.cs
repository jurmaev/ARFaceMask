using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeMaskButton : MonoBehaviour
{
    public Material faceMaterial;
    public ARFaceManager faceManager;
    
    // Start is called before the first frame update
    
    public void SwitchFace()
    {
        foreach (ARFace face in faceManager.trackables)
            face.GetComponent<Renderer>().material = faceMaterial;
    }
}
