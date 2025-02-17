using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "GlobalStateManager", menuName = "GlobalStateManager")]
public class GlobalStateManager : ScriptableObject
{
    UnityEvent onGameOver = new UnityEvent();
    public UnityEvent OnGameOver => onGameOver;

    UnityEvent onPause = new UnityEvent();
    public UnityEvent OnPause => onPause;

    UnityEvent onResume = new UnityEvent();
    public UnityEvent OnResume => onResume;

    [SerializeField] InputActionMap inputActionMap;
    [SerializeField] ScenesManager scenesManager;

    public void GameOver()
    {
        onGameOver?.Invoke();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        inputActionMap.Disable();
        onPause?.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        inputActionMap.Enable();
        onResume?.Invoke();
    }

    public void SwitchPause()
    {
        if (Time.timeScale == 0)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Restart()
    {
        scenesManager.ReloadScene();
    }
}