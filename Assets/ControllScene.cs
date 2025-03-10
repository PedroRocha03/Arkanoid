using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Brick");


        if (gos.Length == 0)
        {
            if (scene.name == "InicialScene")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("FirstScene");
                }
            }
            else if (scene.name == "FirstScene")
            {
                SceneManager.LoadScene("SecondScene");
            }
            else if (scene.name == "SecondScene")
            {
                SceneManager.LoadScene("FinalScene");
            }
            else if (scene.name == "FInalScene")
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("InicialScene");
                }
            }
        }
    }
}
