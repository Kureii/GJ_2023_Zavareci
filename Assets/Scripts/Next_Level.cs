using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next_Level : MonoBehaviour
{
    private bool CharacterConnected { get; set; }
    private bool switchinLevels;
    // Start is called before the first frame update

    [SerializeField] private GameObject startingSceneTransition;

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
            double timer = Time.fixedTimeAsDouble+1.5;
            GameObject.Find("GameManager").GetComponent<GameManager>().TransitionStart();
            Invoke("SwitchScenes", 1);
        }
    }

    void InvertCharacterConnected()
    {
        CharacterConnected = !CharacterConnected;
    }

    void SwitchScenes() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
