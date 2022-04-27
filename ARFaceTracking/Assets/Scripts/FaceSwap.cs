using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceSwap : MonoBehaviour
{
    public List<Material> faceMaterials = new List<Material>();
    private ARFaceManager faceManager;
    private int faceMaterialIndex;

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceMaterialIndex = 0;
    }

    public void SwitchFace()
    {
        foreach (ARFace face in faceManager.trackables)
            face.GetComponent<Renderer>().material = faceMaterials[faceMaterialIndex];
        faceMaterialIndex++;
        if (faceMaterialIndex >= faceMaterials.Count)
            faceMaterialIndex = 0;
    }
}
