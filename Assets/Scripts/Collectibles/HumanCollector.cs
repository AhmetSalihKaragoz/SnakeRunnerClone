using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumanCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI humanScoreText;


    public int humanScore;

    private void Start()
    {
        UpdateText();
    }

    public void IncrementHumanCount()
    {
        humanScore++;
        UpdateText();
    }

    void UpdateText()
    {
        humanScoreText.SetText(humanScore.ToString());
    }

    

}
