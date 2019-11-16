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
    readonly Dictionary<int, string> MapLevelTreePrefab = new Dictionary<int, string>();

    public ProgressionController() {
        xp = 0;
        energy = 0;
        level = 0;
        maxLevel = 4;

        MapActionXP.Add("task_created", 5);
        MapActionXP.Add("task_finished", 10);
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

        MapLevelTreePrefab.Add(0, "Level_0.png");
        MapLevelTreePrefab.Add(1, "Level_1.png");
        MapLevelTreePrefab.Add(2, "Level_2.png");
        MapLevelTreePrefab.Add(3, "Level_3.png");
        MapLevelTreePrefab.Add(4, "Level_4.png");
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
        return level;
    }

    int GetEnergy() {
        return energy;
    }

    void renderTree() {

    }

    public void UpdateStats(string action) {
        UpdateXP(action);
        UpdateEnergy(action);
        UpdateLevel();
        Debug.LogFormat("XP: {0}\nNext XP: {1}\nLevel: {2}\nEnergy: {3}", GetXP(), GetXpToNextLevel(), GetLevel(), GetEnergy());
    }

    public Dictionary<string, int> GetStats() {
        Dictionary<string, int> stats = new Dictionary<string, int>();

        stats.Add("xp", GetXP());
        stats.Add("next_xp", GetXpToNextLevel());
        stats.Add("level", GetLevel());
        stats.Add("energy", GetEnergy());

        return stats;
    }
}
