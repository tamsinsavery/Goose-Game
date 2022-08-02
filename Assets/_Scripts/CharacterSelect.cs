using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public int gooseSelected = 1;
    public int whichGooseIsThis;
    public static int finalSelection;
    public GameObject goose;
    public Vector3 sizeChange;
    Vector3 originalSize;
    Vector3 newSize;

    public LevelSelect level;

    public Text description;

    // Start is called before the first frame update
    void Start()
    {
        description.text = "";
        originalSize = goose.transform.localScale;
        newSize = goose.transform.localScale+ sizeChange;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gooseSelected);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gooseSelected -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gooseSelected+=1;
        }

        switch (gooseSelected)
        {
            case 1:
                if (whichGooseIsThis == 1)
                {
                    goose.transform.localScale = newSize;
                    description.text = "Regular goose";
                }
                else
                {
                    goose.transform.localScale  = originalSize;
                }
                break;
            case 2:
                if (whichGooseIsThis == 2)
                {
                    goose.transform.localScale = newSize;
                    description.text = "The father goose";
                }
                else
                {
                    goose.transform.localScale = originalSize;
                }
                break;
            case 3:
                if (whichGooseIsThis == 3)
                {
                    goose.transform.localScale = newSize;
                    description.text = "The son goose";
                }
                else
                {
                    goose.transform.localScale = originalSize;
                }
                break;
            case 4:
                if (whichGooseIsThis == 4)
                {
                    goose.transform.localScale = newSize;
                    description.text = "The Holy Ghoost";
                }
                else
                {
                    goose.transform.localScale = originalSize;
                }
                break;
            case 5:
                gooseSelected = 1;
                break;
            case 0:
                gooseSelected = 4;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            finalSelection = gooseSelected;
            
            switch (LevelSelect.finalLevelSelect)
            {
                case 1:
                    SceneManager.LoadScene("Level1");
                    break;
                case 2:
                    SceneManager.LoadScene("Level2");
                    break;
                case 3:
                    SceneManager.LoadScene("Level3");
                    break;
            }
        }
    }
}
