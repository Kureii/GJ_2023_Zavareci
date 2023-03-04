using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private int intesity;
    private float defaultsize;
    bool zoom;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        zoom = true;
        i = 0;
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
            gameObject.transform.localScale += new Vector3(0.0001f, 0.0001f, 0)*intesity;
            gameObject.transform.Rotate(new Vector3(0, 0, 0.001f));
            i++;
            if (i == 200) zoom = false;
        }
       else if (!zoom)
        {
            gameObject.transform.localScale -= new Vector3 (0.0001f, 0.0001f, 0) * intesity;
            gameObject.transform.Rotate(new Vector3(0, 0, -0.001f));
            i--;
            if (i == 0) zoom = true;
        }
    }
}
