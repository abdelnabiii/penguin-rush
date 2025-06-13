using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler ()
    {
        gm.StartGame();

    }

    private void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);

    }
    private void OnGUI()
    {
        scoreUI.text = gm.Score();
    }

}
