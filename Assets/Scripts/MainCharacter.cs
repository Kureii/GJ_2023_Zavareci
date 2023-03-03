using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private KeyCode UpLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode UpUp = KeyCode.UpArrow;
    [SerializeField] private KeyCode UpRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode UpDown = KeyCode.DownArrow;
    [SerializeField] private KeyCode DownLeft = KeyCode.A;
    [SerializeField] private KeyCode DownUp = KeyCode.W;
    [SerializeField] private KeyCode DownRight = KeyCode.D;
    [SerializeField] private KeyCode DownDown = KeyCode.S;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private string StuckedObjectTag = "Wall";
    [SerializeField] private GameObject UpCharacter;
    [SerializeField] private GameObject DownCharacter;
    

    private bool conected = true;
    private Vector3 position;
    private List<GameObject> children = new List<GameObject>();
    private Rigidbody upRb;
    private Rigidbody downRb;
    private FixedJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        upRb = UpCharacter.GetComponent<Rigidbody>();
        print(upRb);
        downRb = DownCharacter.GetComponent<Rigidbody>();
        joint = UpCharacter.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = downRb;
        joint = DownCharacter.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = upRb;
    }

    // Update is called once per frame
    void Update()
    {
        if (conected)
        {

            moveAll();
        }
        else
        {
            MoveOne();
        }
    }

    private void moveAll()
    {
        if (Input.GetKey(UpLeft) || Input.GetKey(UpRight))
        {
            joint = DownCharacter.transform.GetComponent<FixedJoint>();
            Destroy(joint);
            joint = UpCharacter.transform.GetComponent<FixedJoint>();
            Destroy(joint);
            conected = false;
        }
        if (Input.GetKey(UpDown) || Input.GetKey(UpUp))
        {
            joint = DownCharacter.transform.GetComponent<FixedJoint>();
            Destroy(joint);
            joint = UpCharacter.transform.GetComponent<FixedJoint>();
            Destroy(joint);
            conected = false;
        }

        position = transform.position;
        if (Input.GetKey(DownLeft))
        {
            /*downCharacter.*/transform.Translate(new Vector3(-speed * 3 * Time.deltaTime, 0, 0));
            return;
        }
        if (Input.GetKey(DownRight))
        {
            /*downCharacter.*/transform.Translate(new Vector3(speed * 3 * Time.deltaTime, 0, 0));
            
            return;
        }
        if (Input.GetKey(DownDown))
        {
            return;
        }
        if (Input.GetKey(DownUp))
        {
            return;
        }
    }

    private void MoveOne()
    {
        position = transform.position;
        if (Input.GetKey(DownLeft))
        {
            DownCharacter.transform.Translate(new Vector3(-speed * 3 * Time.deltaTime, 0, 0));
            
        }
        if (Input.GetKey(DownRight))
        {
            DownCharacter.transform.Translate(new Vector3(speed * 3 * Time.deltaTime, 0, 0));
            Destroy(joint);
        }
        if (Input.GetKey(DownDown))
        {
        }
        if (Input.GetKey(DownUp))
        {
        }
        if (Input.GetKey(UpLeft))
        {
            UpCharacter.transform.Translate(new Vector3(-speed * 3 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(UpRight))
        {
            UpCharacter.transform.Translate(new Vector3(speed * 3 * Time.deltaTime, 0, 0));
            
        }
        if (Input.GetKey(UpUp))
        {
        }
        if (Input.GetKey(DownUp))
        {
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherTag = collision.gameObject.tag;

        if (StuckedObjectTag == otherTag)
        {
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRigidbody != null)
            {
                otherRigidbody.detectCollisions = true;
            }
        }
    }
}
