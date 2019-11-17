using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private Vector3 moveDirection;
    private Vector3 targetFlyRotation;

    void Update() {
        float yawMouse = Input.GetAxis("Mouse X");
        float pitchMouse = Input.GetAxis("Mouse Y");

        targetFlyRotation = Vector3.zero;

        if (Mathf.Abs(yawMouse) > 0.1f || Mathf.Abs(pitchMouse) > 0.1f) {
            targetFlyRotation = yawMouse * transform.right + pitchMouse * transform.up;
            Vector3.zero.Normalize();
            targetFlyRotation *= Time.deltaTime * 3.0f;

            //limit x rotation if looking too much up or down
            //Log out the limitX value for this to make sense
            float limitX = Quaternion.LookRotation(moveDirection + targetFlyRotation).eulerAngles.x;

            //70 sets the rotation limit in the down direction
            //290 sets limit for up direction
            if ((limitX < 90 && limitX > 70) || (limitX > 270 && limitX < 290)) {
                Debug.Log("restrict motion");
            }

            else {
                moveDirection += targetFlyRotation;
                //does the actual rotation on the object if no limits are breached
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

        }
    }
}

