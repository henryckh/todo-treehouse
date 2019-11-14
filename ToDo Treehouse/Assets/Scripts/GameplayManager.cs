using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {
    public GameObject scoreboard;
    public GameObject popupNewTask;
    public GameObject taskManager;
    public GameObject contentArea;
    public GameObject task;

    string[] data = { "Task 1", "Task 2", "Task 3", "Task 4", "Task 5", "Task 6", "Task 7" };

    void Start() {
        scoreboard.GetComponent<Scoreboard>().UpdateXP(400, 700);
        RenderTasksList();
    }

    public void OnClickShowCreateTask() {
        //popupNewTask.SetActive(true);
        Instantiate(popupNewTask, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void CreateNewTask(string task) {
        Debug.Log("Game Manager is creating...");
        Debug.Log(task);
    }

    void RenderTasksList() {
        for (int i = 0; i < data.Length; i++) {
            Debug.Log(data[i]);
            GameObject prefab;
            Transform tmp;

            float defaultY = -32.0f;
            float factorY = -80.0f;
            float y = (defaultY + (i * factorY)); // Y Co-ordinate of each subsequent task

            Debug.Log(y);
            contentArea.GetComponent<RectTransform>().SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            // Instantiate task prefab and attach it to 'content' area (game object) of 'ScrollPane' UI component
            prefab = Instantiate(task) as GameObject;
            prefab.transform.SetParent(contentArea.transform, false);
            //prefab.transform.position = contentArea.transform.position;
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(560.0f, 72.0f);
            prefab.GetComponent<RectTransform>().position = new Vector3(-40.0f, y, 0.0f);

            // Render prefab content:
            // 1. Add text
            prefab.transform.Find("Text").GetComponent<Text>().text = data[i];

            // 2. Set toggle state

        }
    }
}
