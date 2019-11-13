using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {
    public GameObject scoreboard;
    public GameObject popupNewTask;

    int test = 0;

    void Start() {
        Debug.LogFormat("Test var = {0}", test);
        scoreboard.GetComponent<Scoreboard>().UpdateXP(400, 700);
    }

    public void OnClickCreateTask() {
        popupNewTask.SetActive(true);
    }
}
