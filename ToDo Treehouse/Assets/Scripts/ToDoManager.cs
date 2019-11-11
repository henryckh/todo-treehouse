using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoManager : MonoBehaviour
{

    private Task task = new Task("Work on game project", 80);

    public void showAllTasks(){
    	task.print();
    }
}
