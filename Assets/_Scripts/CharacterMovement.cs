using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 20;
    public float rotateSpeed = 120;
    public float maxSpeed = 50;

    CharacterController cc;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        cc = GetComponent<CharacterController>();
        sceneName = currentScene.name;
        


}

    // Update is called once per frame
    void Update()
    {
        
        if (sceneName == "Scene1")
        {
            if (Input.GetKeyDown(KeyCode.Return)){

            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle A");
        }
        

        if (sceneName == "ExampleRace")
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);

            cc.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }
        cc.SimpleMove(Physics.gravity);
        //if (Input.GetAxis("Horizontal") !=0)
        //{
        //    animator.Play("Walk");
        //} else
        //{
        //    animator.Play("Idle A");
        //}
    }
}
