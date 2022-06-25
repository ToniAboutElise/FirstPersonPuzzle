using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private EventSystem _eventSystem;

    public EventSystem GetEventSystem() { return _eventSystem; }

    private void Awake()
    {
        if(instance == null)
        instance = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _eventSystem = FindObjectOfType<EventSystem>();
    }
}
