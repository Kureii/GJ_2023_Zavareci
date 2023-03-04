using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDisabler : MonoBehaviour
{
    private void OnMouseEnter(Collider2D collision)
    {
        Debug.Log("EnteredButton");
       GameObject.Find("Player").GetComponent<Char_Controller>().MouseOnMenu = true;
    }
    
    private void OnMouseExit(Collider2D collision)
    {
        GameObject.Find("Player").GetComponent<Char_Controller>().MouseOnMenu = false;
    }
}
