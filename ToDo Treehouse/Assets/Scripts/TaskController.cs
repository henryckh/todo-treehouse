using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour {
    public GameObject task;
    public GameObject contentAreaTasks;
    readonly string[] data = {
        "Read a book",
        "Clean attic tomorrow",
        "Write 3 pages of descriptive writing",
        "Finish evil project",
        "Go to shopping"
    };

    void Start() {
        RenderTasks();
    }

    void RenderTasks() {
        for (int i = 0; i < data.Length; i++) {
            GameObject prefab;

            float defaultY = -24.0f;
            float factorY = -56.0f;
            float y = (defaultY + (i * factorY)); // Y Co-ordinate of each subsequent task

            contentAreaTasks.GetComponent<RectTransform>().SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            // Instantiate task prefab and attach it to 'content' area (game object) of 'ScrollPane' UI component
            prefab = Instantiate(task) as GameObject;
            prefab.transform.SetParent(contentAreaTasks.transform, false);
            prefab.transform.position = contentAreaTasks.transform.position;

            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(640.0f, 40.0f);
            prefab.GetComponent<RectTransform>().position = new Vector3(0.0f, y, 0.0f);

            // Render prefab content:
            prefab.transform.Find("Text").GetComponent<Text>().text = data[i];
        }
    }

    public void CreateTask() {
        Debug.Log("Creating Task...");
    }
}
