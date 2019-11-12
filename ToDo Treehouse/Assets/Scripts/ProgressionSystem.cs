using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystem : MonoBehaviour {

    int xp, level, energy;
    Dictionary<string, int> MapActionPoint = new Dictionary<string, int>();
    Dictionary<string, int> MapActionEnergy = new Dictionary<string, int>();
    Dictionary<int, int> MapLevelXP = new Dictionary<int, int>();


    public ProgressionSystem() {
        xp = 0;
        energy = 0;
        level = 0;

        MapActionPoint.Add("task_created", 5);
        MapActionPoint.Add("task_finished", 15);
        MapActionPoint.Add("streak_day_3", 30);
        MapActionPoint.Add("streak_day_7", 75);

        MapActionEnergy.Add("task_created", 1);
        MapActionEnergy.Add("task_finished", 3);
        MapActionEnergy.Add("streak_day_3", 5);
        MapActionEnergy.Add("streak_day_7", 7);

        MapLevelXP.Add(0, 0);
        MapLevelXP.Add(1, 50);
        MapLevelXP.Add(2, 150);
        MapLevelXP.Add(3, 350);
        MapLevelXP.Add(4, 750);
        MapLevelXP.Add(5, 1000);
    }

    void Start() {
        UpdateStats("task_created");
    }

    public void UpdateStats(string action) {
        UpdateXP(action);
        UpdateLevel();
        UpdateEnergy();
    }
    public void UpdateXP(string action) {
        xp += MapActionPoint.ContainsKey(action) ? MapActionPoint[action] : 0;
    }

    public void UpdateLevel() {
        // Never exceed beyond top level, which is 5.
        int nextLevel = (level + 1) < 5 ? level + 1 : 5;
        int nextXP = MapLevelXP[nextLevel];

        if (xp < nextXP) { // Do nothing
            return;
        }

        level++;
    }

    public void UpdateEnergy() {
    }

    public int GetXP() {
        return xp;
    }

    public int GetLevel() {
        return energy;
    }

    public int GetEnergy() {
        return level;
    }
}
