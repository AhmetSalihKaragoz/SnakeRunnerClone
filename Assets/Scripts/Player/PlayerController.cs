using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement; 
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] HumanCollector humanCollector;
    [SerializeField] GemCollector gemCollector;
    
    
    [HideInInspector] public bool isDead = false;

    SetHumanColor setHumanColor;
    

    private Color currentLineColor;

    void Update()
    {
        
        if (isDead)
        {
            return;
        }
        playerMovement.Movement();
        
    }
    private void Die()
    {

        isDead = true;
        gameOverUI.GameOverMenu();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (isDead)
        {
            return;
        }

        if (gemCollector.isHyperMode)
        {
            if (other.tag == "Human")
            {
                humanCollector.IncrementHumanCount();
            }
            Destroy(other.gameObject);
        }
        else
        {
            if (other.tag == "Human")
            {
                setHumanColor = other.gameObject.GetComponent<SetHumanColor>();

                if (other.gameObject.GetComponent<EnemyController>().myColor == currentLineColor)
                {
                    other.gameObject.GetComponent<EnemyController>().Die();

                    humanCollector.IncrementHumanCount();
                    Debug.Log("eat human");
                }
                else
                {
                    Die();
                }
            }
            else if (other.tag == "Gem")
            {
                gemCollector.IncrementGemCount();
                Destroy(other.gameObject);
            }
            else if (other.tag == "Obstacle")
            {
                Die();
            }
            else if (other.tag == "Line")
            {
                currentLineColor = other.GetComponent<SetLineColor>().lineColor;
            }
            else
            {
                return;
            }
        }

        


    }

    
}
