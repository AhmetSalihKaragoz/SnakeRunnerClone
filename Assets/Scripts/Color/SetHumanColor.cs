using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHumanColor : MonoBehaviour
{
    [SerializeField] Renderer graphicsRenderer;
    [SerializeField] Material humanColorMaterial;

    
    [HideInInspector] public Color color;
    void Start()
    {
        SetMaterialColor();
        
    }

    private void SetMaterialColor()
    {
        color = humanColorMaterial.color;
        graphicsRenderer.material.color = color;
    }
    
}
