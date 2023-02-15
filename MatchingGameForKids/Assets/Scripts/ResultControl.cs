using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ResultControl : MonoBehaviour
{
    Vector3 correctPosition;
    GameObject GO;
    public GameObject trueT;
    public GameObject falseF;
    [SerializeField] List<Button> buttons;

    void Start()
    {
        GO=GameObject.Find("Animal-Img");
        correctPosition = GO.transform.position;
        Debug.Log(correctPosition);
    }


    void Update()
    {
        
    }

    public void CorrectFind(int whichButton)
    {
        StartCoroutine(CorrectFindContinue(whichButton));
    }

    public IEnumerator CorrectFindContinue(int whichButton)
    {
        if (CreateLevel.randomNumCorrect == whichButton)
        {
            buttons[whichButton].interactable = false;
            CreateLevel.StaticList[whichButton].transform.DOMove(correctPosition,1f);
            CreateLevel.StaticList[whichButton].transform.DOScale(new Vector3(1.5f,1.5f,1.5f),1f);
            yield return new WaitForSeconds(1f);
            CreateLevel.StaticList[whichButton].transform.DOPunchScale(new Vector3(-0.2f, -0.2f, 0), 1f, 4, 1f);
            yield return new WaitForSeconds(0.6f);
            trueT.SetActive(true);
            trueT.transform.DOPunchScale(new Vector3(-0.2f, -0.2f, 0), 0.3f, 1, 0.5f);
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            buttons[whichButton].interactable = false;
            falseF.SetActive(true);
            falseF.transform.DOPunchScale(new Vector3(-0.2f, -0.2f, 0), 0.3f, 1, 0.5f);
            yield return new WaitForSeconds(0.8f);
            falseF.SetActive(false);
            buttons[whichButton].interactable = true;
        }
    }

}
