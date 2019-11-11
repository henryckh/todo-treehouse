using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour{
    public ToDoManager todoManager;

    // Update is called once per frame
    void Update(){
    	todoManager.showAllTasks();
        
    }

    public void inputTask(){
        
    }
}
