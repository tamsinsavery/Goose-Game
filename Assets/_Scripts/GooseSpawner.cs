using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GooseSpawner : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject[] geese;


    CharacterSelect selection;

    public GameObject plain;
    public GameObject father;
    public GameObject son;
    public GameObject holyGhoost;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        switch (CharacterSelect.finalSelection)
        {
            case 1:
                Instantiate(plain, transform.position, transform.rotation);
                cameras[1].gameObject.SetActive(true);
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
