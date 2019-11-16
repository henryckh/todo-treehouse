using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour {
    void UpdateXP(int num, int total) {
        GameObject.Find("TextXp").GetComponent<Text>().text = "XP: " + num + "/" + total;
    }

    void UpdateLevel(int level) {
        GameObject.Find("TextLevel").GetComponent<Text>().text = "Level: " + level;
    }

    void UpdateEnergy(int energy) {
        GameObject.Find("TextEnergy").GetComponent<Text>().text = "Energy: " + energy;
    }

    public void UpdateScoreboard(Dictionary<string, int> stats) {
        UpdateXP(stats["xp"], stats["next_xp"]);
        UpdateLevel(stats["level"]);
        UpdateEnergy(stats["energy"]);
    }
}
