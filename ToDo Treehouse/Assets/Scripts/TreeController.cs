using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {
    public GameObject[] trees = new GameObject[7];
    public float[] scaleFactor = { 0.4f, 6.0f, 1.0f, 22.0f, 1.0f, 21.0f, 9.0f };
    public GameObject tree;
    private Mesh meshToSwap;

    public void UpgradeTreeToLevel(int level) {
        meshToSwap = trees[level].GetComponent<MeshFilter>().sharedMesh;
        tree.transform.localScale = new Vector3(1, 1, 1) * scaleFactor[level];
        tree.GetComponent<MeshFilter>().sharedMesh = meshToSwap;
    }
}