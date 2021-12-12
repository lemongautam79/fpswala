using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathscript : MonoBehaviour
{
    public TextMeshProUGUI deathtext;
    private int killrate = 0;
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    public void killratewala()
    {
        deathtext.text = killrate++.ToString();
    }
}
