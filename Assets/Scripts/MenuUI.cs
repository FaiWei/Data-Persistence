using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class MenuUI : MonoBehaviour
{
    [SerializeField]InputField userName;
    [SerializeField]Text bestScoreText;
    public void Start()
    {
        //InfoManager.Instance.ResetSave();
        userName.text = InfoManager.Instance.lastPlayer;
        bestScoreText.text = $"Best Score : {InfoManager.Instance.leaderScore} : {InfoManager.Instance.bestScore}";
        userName.onEndEdit.AddListener(SaveName);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveName(string userName)
    {
        InfoManager.Instance.currentPlayer = userName;
    }
}
