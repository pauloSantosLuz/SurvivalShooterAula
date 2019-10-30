using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int placar;

    Text text;              

    void Awake ()
    {
        text = GetComponent <Text> ();

        placar = 0;
    }


    void Update ()
    {
        text.text = "Score: " + placar;
    }
}

