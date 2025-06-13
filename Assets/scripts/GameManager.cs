using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    #endregion

    public float CurrentScore = 0f;

    public bool IsPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();


    private void Update()
    {
        if (IsPlaying) {
            CurrentScore += Time.deltaTime;
        }       
    }

    public void StartGame()
    {
        onPlay.Invoke();
        IsPlaying = true;

    }

    public void GameOver()
    {
        onGameOver.Invoke();
        CurrentScore = 0;
        IsPlaying = false;
        Debug.Log("Game Over!");
    }

    public string Score ()
    {
        return Mathf.RoundToInt(CurrentScore).ToString();
    }

}
