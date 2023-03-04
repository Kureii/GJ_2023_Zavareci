using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next_Level : MonoBehaviour
{
    private bool CharacterConnected { get; set; }
    // Start is called before the first frame update
    void Start()
    {
       CharacterConnected = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Finish" && CharacterConnected)
        {
            Debug.Log("Cíl!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void InvertCharacterConnected()
    {
        CharacterConnected = !CharacterConnected;
    }
}
