using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupNewTask : MonoBehaviour {
    public GameObject inputFieldText;
    GameplayManager gameManager;

    public void DestroyPopup() {
        Debug.Log("Destroying popup...");
        Destroy(gameObject);
    }

    public void FetchTaskDetails() {
        string taskText = inputFieldText.GetComponent<Text>().text;
        Debug.Log(taskText);
        gameManager = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        gameManager.CreateNewTask(taskText);
    }
}
