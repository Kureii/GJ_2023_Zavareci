using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDisabler : MonoBehaviour
{
    BoxCollider2D bc;

    private void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnMouseEnter()
    {
       Debug.Log("EnteredButton");
       GameObject.Find("Player").GetComponent<Char_Controller>().MouseOnMenu = true;
    }
    
    private void OnMouseExit()
    {
        GameObject.Find("Player").GetComponent<Char_Controller>().MouseOnMenu = false;
    }
}
