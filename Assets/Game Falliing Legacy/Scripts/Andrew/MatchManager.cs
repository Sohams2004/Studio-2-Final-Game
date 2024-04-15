using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public Death p1Lives;
    public Death p2Lives;

    public GameObject p1WinUI;
    public GameObject p2WinUI;

    //Needs the death border prefab with Death script attached
    public GameObject deathBound;

    private void Awake()
    {
        p1WinUI.SetActive(false);
        p2WinUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        p1Lives = deathBound.GetComponent<Death>();
        p2Lives = deathBound.GetComponent<Death>();
    }

    public void WinCondition()
    {
        if (p1Lives.player1Lives <= 0)
        {
            p1WinUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (p2Lives.player2Lives <= 0)
        {
            p2WinUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
