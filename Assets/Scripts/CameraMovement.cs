using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera camera;
    private float defaultsize;
    bool zoom;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        defaultsize = camera.orthographicSize;
        zoom = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        TwistCamera();
    }

    void TwistCamera()
    {
      if(zoom)
        {
            camera.orthographicSize += 0.001f;
            camera.transform.Rotate(new Vector3(0, 0, 0.005f));
            i++;
            if (i == 200) zoom = false;
        }
       else if (!zoom)
        {
            camera.orthographicSize -= 0.001f;
            camera.transform.Rotate(new Vector3(0, 0, -0.005f));
            i--;
            if (i == 0) zoom = true;
        }
    }
}
