using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
    int val;

    public Actor() {
        this.val = 5;
    }

    public void printVal() {
        Debug.Log(val);
    }

    public void setVal(int val) {
        this.val = val;
    }
}
