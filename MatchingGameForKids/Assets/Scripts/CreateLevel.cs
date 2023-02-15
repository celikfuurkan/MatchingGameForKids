using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateLevel : MonoBehaviour
{
    [SerializeField] Image correctAnimalImage;
    [SerializeField] List<Sprite> allAnimals;
    [SerializeField] List<Image> randomAnimalImage;
    public static List<Image> StaticList = new();

    public static int randomNumCorrect;
    int correctNum, randomNum1, randomNum2;

    void Start()
    {
        StaticList = randomAnimalImage;
        ChooseCorrectAnimal();
        ChooseRandomNumber();
        PutRandomAnimal();
    }


    void Update()
    {
        
    }

    /*
    public static void NewGame()
    {
        var ng = new CreateLevel();
        ng.ChooseCorrectAnimal();
        ng.ChooseRandomNumber();
        ng.PutRandomAnimal();
    }*/

    public void ChooseCorrectAnimal()
    {
        

        correctNum = Random.Range(0, allAnimals.Count);
        correctAnimalImage.sprite = allAnimals[correctNum];

        randomNumCorrect = Random.Range(0, 3);
        randomAnimalImage[randomNumCorrect].sprite = allAnimals[correctNum];
    }

    public void ChooseRandomNumber()
    {
        randomNum1 = Random.Range(0, allAnimals.Count);
        randomNum2 = Random.Range(0, allAnimals.Count);

        for (int i = 0; i < 10 && randomNum1 == randomNum2; i++)
            randomNum2 = Random.Range(0, allAnimals.Count);

        if (randomNum1 == correctNum || randomNum2 == correctNum)
            ChooseRandomNumber();
    }

    public void PutRandomAnimal()
    {
        if (randomNumCorrect == 0)
        {
            randomAnimalImage[1].sprite = allAnimals[randomNum1];
            randomAnimalImage[2].sprite = allAnimals[randomNum2];
        }
        else if (randomNumCorrect == 1)
        {
            randomAnimalImage[0].sprite = allAnimals[randomNum1];
            randomAnimalImage[2].sprite = allAnimals[randomNum2];
        }
        else if (randomNumCorrect == 2)
        {
            randomAnimalImage[0].sprite = allAnimals[randomNum1];
            randomAnimalImage[1].sprite = allAnimals[randomNum2];
        }
    }

}