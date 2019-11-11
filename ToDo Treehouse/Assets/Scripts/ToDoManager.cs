using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoManager : MonoBehaviour
{

	// temp construction
	static int totalTasks = 10;
	int[] complexities = {0, 1, 2, 3, 5, 8, 11, 20, 40, 80, 100};
    Task[] task = new Task[totalTasks];
    List<Task> tasks = new List<Task>();

    public ToDoManager(){
	    for(int i = 0; i < totalTasks; i++){
	    	System.Random rnum = new System.Random();
	    	string name = "This is task no." + i;
	    	tasks.Add(new Task(name, complexities[rnum.Next(11)]));
	    }
    }

    public void addTask(){
        
    }

    public void showAllTasks(){
    	// Iterate over 'tasks' collection
        foreach (Task task in tasks){
            task.print();
        }
    }
}
