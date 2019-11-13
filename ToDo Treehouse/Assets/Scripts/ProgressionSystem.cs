using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystem : MonoBehaviour {

    int xp, level, energy, maxLevel;
    readonly Dictionary<string, int> MapActionXP = new Dictionary<string, int>();
    readonly Dictionary<string, int> MapActionEnergy = new Dictionary<string, int>();
    readonly Dictionary<int, int> MapLevelXP = new Dictionary<int, int>();
    readonly Dictionary<int, string> MapLevelTreeSprite = new Dictionary<int, string>();


    public ProgressionSystem() {
        xp = 0;
        energy = 0;
        level = 0;
        maxLevel = 4;

        MapActionXP.Add("task_created", 5);
        MapActionXP.Add("task_finished", 15);
        MapActionXP.Add("streak_day_3", 30);
        MapActionXP.Add("streak_day_7", 75);

        MapActionEnergy.Add("task_created", 1);
        MapActionEnergy.Add("task_finished", 3);
        MapActionEnergy.Add("streak_day_3", 5);
        MapActionEnergy.Add("streak_day_7", 7);

        MapLevelXP.Add(0, 0);
        MapLevelXP.Add(1, 50);
        MapLevelXP.Add(2, 150);
        MapLevelXP.Add(3, 350);
        MapLevelXP.Add(4, 750);

        MapLevelTreeSprite.Add(0, "Level_0.png");
        MapLevelTreeSprite.Add(1, "Level_1.png");
        MapLevelTreeSprite.Add(2, "Level_2.png");
        MapLevelTreeSprite.Add(3, "Level_3.png");
        MapLevelTreeSprite.Add(4, "Level_4.png");
    }

    void Start() {
        UpdateStats("task_created");
    }

    public void UpdateStats(string action) {
        UpdateXP(action);
        UpdateEnergy(action);
        UpdateLevel();
    }
    public void UpdateXP(string action) {
        xp += MapActionXP.ContainsKey(action) ? MapActionXP[action] : 0;
    }

    public void UpdateLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;

        if (MapLevelXP.ContainsKey(nextLevel) && (xp >= MapLevelXP[nextLevel])) {
            level++;
        }
    }

    public void UpdateEnergy(string action) {
        energy += MapActionEnergy.ContainsKey(action) ? MapActionEnergy[action] : 0;
    }

    public Dictionary<string, int> GetStats() {
        Dictionary<string, int> stats = new Dictionary<string, int>();

        stats.Add("xp", GetXP());
        stats.Add("next_xp", GetXpToNextLevel());
        stats.Add("level", GetLevel());
        stats.Add("energy", GetEnergy());

        return stats;
    }

    public int GetXP() {
        return xp;
    }

    public int GetXpToNextLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;
        return MapLevelXP.ContainsKey(nextLevel) ? MapLevelXP[nextLevel] : xp;
    }

    public int GetLevel() {
        return energy;
    }

    public int GetEnergy() {
        return level;
    }
}
