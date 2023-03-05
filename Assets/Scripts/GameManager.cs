using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;
    public static GameManager instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void TransitionStart()
    {
        startingSceneTransition.SetActive(true);
        endingSceneTransition.SetActive(false);
        Debug.Log("Opening Transition");
        Invoke("TransitionEnd",1);
    }
    public void TransitionEnd()
    {
        endingSceneTransition.SetActive(true);
        startingSceneTransition.SetActive(false);
    }
}
