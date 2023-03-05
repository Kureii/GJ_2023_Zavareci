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
        LevelChooser = 0;
    }

    void InvertCharacterConnected()
    {
        CharacterConnected = !CharacterConnected;
    }

    public void SwitchScenesTransition()
    {
        if (CharacterConnected == true)
        {
            GetComponent<GameManager>().TransitionStart();
            Invoke("SwitchScenes", 1);
        }
    }

    public void Play()
    {
        GetComponent<GameManager>().TransitionStart();
        Invoke("SwitchScenes", 1);
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SceneChooserTransition(int scene)
    {

        LevelChooser = scene;
        GetComponent<GameManager>().TransitionStart();
        Invoke("SceneChooser", 1);
    }

    public void SceneChooser()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelChooser);
        LevelChooser = 0;
    }


    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
