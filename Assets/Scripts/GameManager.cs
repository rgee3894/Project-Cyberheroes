using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool setupPhase, battlePhase;
    public GameObject setupPanel, battlePanel;
    public PlayerClock clock;

    public GameObject previewCamera;

    private Animator anim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (setupPhase)
        {
            setupPanel.SetActive(true);
            battlePanel.SetActive(false);
        }
        else if(battlePhase)
        {
            setupPanel.SetActive(false);
            battlePanel.SetActive(true);
        }

    }

    IEnumerator playAndWaitForAnim(GameObject target, string stateName)
    {
        int animLayer = 0;

        Animator anim = target.GetComponent<Animator>();
        anim.Play(stateName);

        //Wait until Animator is done playing
        while (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
        {
            //Wait every frame until animation has finished
            yield return null;
        }

        //Done playing. Do something below!
        Debug.Log("Done Playing");
    }

}
