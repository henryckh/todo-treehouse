using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private string name;
    private int complexity;

    public Task(){
    	name = "";
    	complexity = 0;
    }

    public Task(string name, int complexity){
    	this.name = name;
    	this.complexity = complexity;
    }

    public void print(){
    	Debug.LogFormat("Task Name: {0}, Complexity: {1}", name, complexity);
    }
}
