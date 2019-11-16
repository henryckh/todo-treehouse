using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour {
    public GameObject toggle;
    public GameObject progressionController;

    void Start() {
        progressionController = GameObject.Find("ProgressionController");
    }

    public void OnTaskStatusChange() {
        bool status = toggle.GetComponent<Toggle>().isOn;
        string command = status ? "task_finished" : "task_unfinished";
        progressionController.GetComponent<ProgressionController>().UpdateProgress(command);
    }
}
