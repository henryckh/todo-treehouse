using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour {
    Dictionary<string, int> stats;

    public GameObject textXp;
    public GameObject textLevel;
    public GameObject textEnergy;
    public Slider progressBarLevel;
    public GameObject progression;

    void Update() {
        stats = progression.GetComponent<ProgressionController>().GetStats();
        UpdateScoreboard();
        UpdateLevelProgress();
    }

    void UpdateXP(int num, int total) {
        textXp.GetComponent<Text>().text = "XP: " + num + "/" + total;
    }

    void UpdateLevel(int level) {
        textLevel.GetComponent<Text>().text = "Level: " + level;
    }

    void UpdateEnergy(int energy) {
        textEnergy.GetComponent<Text>().text = "Energy: " + energy;
    }

    void UpdateLevelProgress() {
        float progress = (float)stats["xp"] / (float)stats["next_xp"] * 100.0f;
        progressBarLevel.value = progress;
        print(progress);
    }

    void UpdateScoreboard() {
        UpdateXP(stats["xp"], stats["next_xp"]);
        UpdateLevel(stats["level"]);
        UpdateEnergy(stats["energy"]);
    }
}
