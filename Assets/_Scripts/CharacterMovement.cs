using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    GameManager gameManager;
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
        finishLineCrossCount = 0;


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


        if (GameManager.canMove != false)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);

            cc.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        }
        string output = GameManager.gameTime.ToString();
        Debug.Log(output);
        Debug.Log(finishLineCrossCount);        //TESTING STUFF, REMOVE
        cc.SimpleMove(Physics.gravity);


        //if (Input.GetAxis("Horizontal") !=0)
        //{
        //    animator.Play("Walk");
        //} else
        //{
        //    animator.Play("Idle A");
        //}

        

    }
    public static int finishLineCrossCount;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "FinishLine")
        {
            finishLineCrossCount++;

        }
    }

}
