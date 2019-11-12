using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject actor;
    public Actor actorScript;

    void Start() {
        actor = Instantiate(Resources.Load("Actor")) as GameObject;
        actorScript = actor.GetComponent<Actor>();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(actor);
        actorScript.printVal();
        actorScript.setVal(50);
        actorScript.printVal();
    }
}
