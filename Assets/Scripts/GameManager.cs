using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool setupPhase, battlePhase;
    public GameObject setupPanel, battlePanel;
    public PlayerClock clock;
    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
        setupPhase = true;
        battlePhase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (setupPhase)
        {
            setupPanel.active = true;
            battlePanel.active = false;
            
            

        }
        else
        {
            setupPanel.active = true;
            battlePanel.active = false;
        }

    }
}
