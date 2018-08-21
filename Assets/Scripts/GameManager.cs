using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool setupPhase, battlePhase;
    public GameObject setupPanel, battlePanel;
    public PlayerClock clock;

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
            setupPanel.SetActive(true);
            battlePanel.SetActive(false);
            
            

        }
        else
        {
            setupPanel.SetActive(false);
            battlePanel.SetActive(true);
        }


    }
}
