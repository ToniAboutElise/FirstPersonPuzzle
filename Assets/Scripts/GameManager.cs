using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    private EventSystem _eventSystem;

    public EventSystem GetEventSystem() { return _eventSystem; }

    private void Awake()
    {
        if(instance == null)
        instance = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _eventSystem = FindObjectOfType<EventSystem>();
    }

}
