using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void TransitionStart()
    {
        startingSceneTransition.SetActive(true);
        endingSceneTransition.SetActive(false);
        Invoke("TransitionEnd",1);
    }
    public void TransitionEnd()
    {
        endingSceneTransition.SetActive(true);
        startingSceneTransition.SetActive(false);
    }
}
