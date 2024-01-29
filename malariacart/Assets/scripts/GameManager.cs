using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text p1lap;
    public int p1lapcount = 0;
    [SerializeField] private TMP_Text p2lap;
    public int p2lapcount = 0;
    public int p1cp = 0;
    public int p2cp = 0;

    public void lap(){
        p1lap.text = "Player 1 Lap: " + p1lapcount;
        p2lap.text = "Player 2 Lap: " + p2lapcount;
    }
}
