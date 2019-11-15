using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float rotateSpeed = 500.0f;
    public GameObject cube;

    private void Start() {
        Debug.Log(cube);
    }

    private void Rotate() {
        float rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float rotateY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        cube.transform.Rotate(Vector3.up, -rotateX);
        cube.transform.Rotate(Vector3.right, rotateY);
    }

    private void OnMouseOver() {
        Rotate();
    }

    private void OnMouseDrag() {
        Rotate();
    }
}
