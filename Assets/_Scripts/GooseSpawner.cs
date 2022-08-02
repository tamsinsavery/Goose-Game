using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GooseSpawner : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject[] geese;


    CharacterSelect selection;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        for (int i = 0;i < geese.Length; i++)
        {
            geese[i].gameObject.SetActive(false);
        }
        switch (CharacterSelect.finalSelection)
        {
            case 1:
                geese[0].gameObject.SetActive(true);
                cameras[0].gameObject.SetActive(true);
                break;
            case 2:
                geese[1].gameObject.SetActive(true);
                cameras[1].gameObject.SetActive(true);
                break;
            case 3:
                geese[2].gameObject.SetActive(true);
                cameras[2].gameObject.SetActive(true);
                break;
            case 4:
                geese[3].gameObject.SetActive(true);
                cameras[3].gameObject.SetActive(true);
                break;
                default:
                Debug.Log("Failure - invalid character input");
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
