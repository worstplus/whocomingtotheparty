using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMeneger : MonoBehaviour
{
    public GameObject panelSetting;

    private void Start()
    {
        panelSetting.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void Back() 
    {
        SceneManager.LoadScene("Game");
    }
    public void Setting()
    {
        if (panelSetting.activeSelf == false)
        {
            panelSetting.SetActive(true);
        }
        else if (panelSetting.activeSelf == true)
        {
            panelSetting.SetActive(false);
        }
    }

        public void Exit()
        {
            Application.Quit();
        }
    
}
