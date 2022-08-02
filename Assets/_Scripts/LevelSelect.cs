using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public Text infotext;
    public Text lapsText;

    public static int finalLevelSelect;

    
    // Start is called before the first frame update
    void Start()
    {
        intrigger = false;
        infotext.text = "";
        lapsText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (intrigger)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                SceneManager.LoadScene("CharacterSelect");
            }
        }
    }
    bool intrigger;
    private void OnTriggerEnter(Collider other)
    {
        intrigger = true;
        if (other.gameObject.tag == "Level1")
        {
            infotext.text = "Level 1. Press space to continue.";
            lapsText.text = "x laps";
            finalLevelSelect = 1;
        }

        if (other.gameObject.tag == "Level2")
        {
            infotext.text = "Level 2. Press space to continue.";
            lapsText.text = "xlaps";
            finalLevelSelect = 2;
        }

        if (other.gameObject.tag == "Level3")
        {
            infotext.text = "Level 3. Press space to continue.";
            lapsText.text = "8 laps";
            finalLevelSelect=3; 

        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        intrigger = false;
        infotext.text = "";
        lapsText.text = "";
    }
}
