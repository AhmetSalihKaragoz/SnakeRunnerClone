using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLineColor : MonoBehaviour
{
    [SerializeField] Renderer graphicsRenderer;
    

    [SerializeField] public Color lineColor;
    


    

     void Awake()
    {
        
        graphicsRenderer.material.color = lineColor;
    }
}
