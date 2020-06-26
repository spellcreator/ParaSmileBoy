using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public int currentlevel;
    public LevelLoader restarter;
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        restarter.LoadLevel(currentlevel);
    }
}
