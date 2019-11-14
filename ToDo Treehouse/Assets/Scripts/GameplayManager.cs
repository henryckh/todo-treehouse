using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {
    public GameObject scoreboard;
    public GameObject popupNewTask;

    void Start() {
        scoreboard.GetComponent<Scoreboard>().UpdateXP(400, 700);
    }

    public void OnClickShowCreateTask() {
        //popupNewTask.SetActive(true);
        Instantiate(popupNewTask, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void CreateNewTask(string task) {
        Debug.Log("Game Manager is creating...");
        Debug.Log(task);
    }
}
