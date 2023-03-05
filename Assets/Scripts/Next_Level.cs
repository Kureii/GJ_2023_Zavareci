using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next_Level : MonoBehaviour
{
    private bool CharacterConnected { get; set; }
    public int LevelChooser { get; set; }

    // Start is called before the first frame update

    void Start()
    {
        CharacterConnected = true;
        LevelChooser = 1;
    }

    void InvertCharacterConnected()
    {
        CharacterConnected = !CharacterConnected;
    }

    public void SwitchScenesTransition()
    {
        if (CharacterConnected)
        {
            GetComponent<GameManager>().TransitionStart();
            Invoke("SwitchScenes", 1);
        }
    }

    void SwitchScenes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelChooser);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
