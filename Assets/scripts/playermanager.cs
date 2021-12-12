using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playermanager : MonoBehaviour
{
    public static  int playerhp = 100;// just to not make player hp change over compilation of script
    public TextMeshProUGUI playerhptext;
    public GameObject bloodoverlay;
    public static bool isgameover;
    void Start()
    {
        isgameover = false;
        playerhp = 100;
    } 

    void Update()
    {
        playerhptext.text = "+" + playerhp;
        if(isgameover)
        {
            //display gameover in screen
            SceneManager.LoadScene("level1");

        }
    }
    public  IEnumerator takadamage(int damageamount)
    {
        bloodoverlay.SetActive(true);
        playerhp -= damageamount;
        if(playerhp <= 0)
        {
            isgameover = true;
        }
            yield return new WaitForSeconds(1);
            bloodoverlay.SetActive(false);
        }
    }
