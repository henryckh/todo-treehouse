using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {
    GameObject scoreboard;

    public GameplayManager() {
        scoreboard = GameObject.Find("Scoreboard");
    }

    void Start() {
        scoreboard.GetComponent<Scoreboard>().UpdateXP(400, 700);
    }
}
