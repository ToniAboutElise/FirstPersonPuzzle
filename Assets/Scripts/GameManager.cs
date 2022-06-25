using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private EventSystem _eventSystem;
    private PostProcessingManager _postProcessingManager;

    public EventSystem GetEventSystem() { return _eventSystem; }
    public PostProcessingManager GetPostProcessingManager() { return _postProcessingManager; }

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
        _postProcessingManager = FindObjectOfType<PostProcessingManager>();

        _postProcessingManager.Fade(PostProcessingManager.FadeType.FADE_IN, 4);
    }
}
