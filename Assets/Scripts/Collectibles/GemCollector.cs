using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemScoreText;
    [SerializeField] public bool isHyperMode = false;
    [SerializeField] PlayerController playerController;


    [HideInInspector] public int gemScore;

    private void Start()
    {
        UpdateText();
    }

    public void TurnIntoHyper()
    {
        if(gemScore >= 3)
        {
            isHyperMode = true;
            StartCoroutine(TurnOffHyperMode());
            gemScore = 0;
        }
        else if(gemScore < 3)
        {
            isHyperMode = false;
            
        }
        
             
    }
    public void IncrementGemCount()
    {
        gemScore++;
        TurnIntoHyper();
        UpdateText();
    }

    void UpdateText()
    {
        gemScoreText.SetText(gemScore.ToString());
    }

    IEnumerator TurnOffHyperMode()
    {
        yield return new WaitForSeconds(4);
        isHyperMode = false;
    }
}
