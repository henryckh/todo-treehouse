using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
    int xp;
    int level;
    int energy;
    int maxLevel;
    readonly Dictionary<string, int> MapActionXP = new Dictionary<string, int>();
    readonly Dictionary<string, int> MapActionEnergy = new Dictionary<string, int>();
    readonly Dictionary<int, int> MapLevelXP = new Dictionary<int, int>();

    public GameObject scoreboardController;
    public GameObject treeController;

    public ProgressionController() {
        xp = 0;
        energy = 0;
        level = 0;
        maxLevel = 6;

        MapActionXP.Add("task_created", 5);
        MapActionXP.Add("task_finished", 100);
        MapActionXP.Add("streak_day_3", 15);
        MapActionXP.Add("streak_day_7", 20);

        MapActionEnergy.Add("task_created", 1);
        MapActionEnergy.Add("task_finished", 3);
        MapActionEnergy.Add("streak_day_3", 5);
        MapActionEnergy.Add("streak_day_7", 7);

        MapLevelXP.Add(0, 0);
        MapLevelXP.Add(1, 50);
        MapLevelXP.Add(2, 150);
        MapLevelXP.Add(3, 350);
        MapLevelXP.Add(4, 750);
        MapLevelXP.Add(5, 1500);
        MapLevelXP.Add(6, 5000);
    }

    void Start() {
        Dictionary<string, int> stats = GetStats();

        scoreboardController.GetComponent<ScoreboardController>().UpdateScoreboard(stats);
        treeController.GetComponent<TreeController>().UpgradeTreeToLevel(stats["level"]);
    }

    void UpdateXP(string action) {
        xp += MapActionXP.ContainsKey(action) ? MapActionXP[action] : 0;
    }

    void UpdateLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;

        if (MapLevelXP.ContainsKey(nextLevel) && (xp >= MapLevelXP[nextLevel])) {
            level++;
        }
    }

    void UpdateEnergy(string action) {
        energy += MapActionEnergy.ContainsKey(action) ? MapActionEnergy[action] : 0;
    }

    int GetXP() {
        return xp;
    }

    int GetXpToNextLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;
        return MapLevelXP.ContainsKey(nextLevel) ? MapLevelXP[nextLevel] : xp;
    }

    int GetLevel() {
        return level < maxLevel ? level : maxLevel;
    }

    int GetEnergy() {
        return energy;
    }

    public void UpdateProgress(string action) {
        Dictionary<string, int> stats = GetStats();

        UpdateXP(action);
        UpdateEnergy(action);
        UpdateLevel();

        scoreboardController.GetComponent<ScoreboardController>().UpdateScoreboard(stats);
        treeController.GetComponent<TreeController>().UpgradeTreeToLevel(stats["level"]);
    }

    public Dictionary<string, int> GetStats() {
        Dictionary<string, int> stats = new Dictionary<string, int> {
            { "xp", GetXP() },
            { "next_xp", GetXpToNextLevel() },
            { "level", GetLevel() },
            { "energy", GetEnergy() }
        };

        return stats;
    }
}
