using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
    public void Print() {
        print("shbabsas");
    }

    public void UpdateXP(int num, int total) {
        GameObject.Find("XP").GetComponent<Text>().text = "XP: " + num + "/" + total;
    }

    public void UpdateLevel(string level) {
        GameObject.Find("Level").GetComponent<Text>().text = level;
    }

    public void UpdateEnergy(string energy) {
        GameObject.Find("Energy").GetComponent<Text>().text = energy;
    }
}
