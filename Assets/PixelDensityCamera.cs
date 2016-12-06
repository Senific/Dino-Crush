using UnityEngine;
using System.Collections;

public class PixelDensityCamera : MonoBehaviour
{

    public float pixelsToUnits = 100;
    public Camera cam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cam.orthographicSize = Screen.height / pixelsToUnits / 2;
    }
}
