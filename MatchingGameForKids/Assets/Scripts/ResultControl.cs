using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultControl : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void CorrectFind(int whichButton)
    {
        if (CreateLevel.randomNumCorrect == whichButton)
        {
            Debug.Log("DOGRU");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("YANLIÞ");
        }
    }
}
