using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(640, 360, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
