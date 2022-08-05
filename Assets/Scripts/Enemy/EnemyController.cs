using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Renderer myRenderer;
    [HideInInspector] public Color myColor;
    
    public void Die()
    {
        Destroy(gameObject);
    }

    private void SetHumanColor()
    {
        myColor = transform.parent.GetComponent<HumanGroup>().color;
        myRenderer.material.color = myColor;
    }

    private void Start()
    {
        SetHumanColor();
    }
}
