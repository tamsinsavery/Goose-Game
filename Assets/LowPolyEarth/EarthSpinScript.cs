using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;

    void Update() {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.left, Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
    }
}