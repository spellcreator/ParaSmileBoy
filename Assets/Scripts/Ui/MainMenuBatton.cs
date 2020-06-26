using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBatton : MonoBehaviour
{
    public LevelLoader restarter;
    public Button mainMenuBatton;

    private void Start()
    {
        mainMenuBatton.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        restarter.LoadLevel(0);
    }
}
