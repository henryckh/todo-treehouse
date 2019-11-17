using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour {
    readonly StringCollection listTasks = new StringCollection();

    public GameObject task;
    public GameObject contentAreaTasks;
    public GameObject inputField;

    void Start() {
        listTasks.Add("Read a book");
        listTasks.Add("Clean attic tomorrow");
        listTasks.Add("Write 3 pages of descriptive writing");
        listTasks.Add("Go to shopping");

        inputField.GetComponent<InputField>().onEndEdit.AddListener(CreateTask);
        RenderTasks();
    }

    void CleanUp() {
        foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("PrefabTask")) {
            Destroy(prefab);
        }
    }
    void RenderTasks() {
        CleanUp();

        for (int i = 0; i < listTasks.Count; i++) {
            GameObject prefab;

            float defaultY = -24.0f;
            float factorY = -56.0f;
            float y = (defaultY + (i * factorY)); // Y Co-ordinate of each subsequent task

            // Instantiate task prefab and attach it to 'content' area (game object) of 'ScrollPane' UI component
            prefab = Instantiate(task, Vector3.zero, Quaternion.identity) as GameObject;
            contentAreaTasks.GetComponent<RectTransform>().SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            prefab.transform.SetParent(contentAreaTasks.transform, false);

            // Render prefab content:
            prefab.transform.Find("Text").GetComponent<Text>().text = listTasks[i];

            // Render pefab's transformations
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(800.0f, 40.0f);
            prefab.GetComponent<RectTransform>().position = new Vector3(0.0f, y, 0.0f);
            prefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, y, 0.0f);
        }
    }

    public void CreateTask(string task) {
        listTasks.Add(task);
        RenderTasks();
    }
}
