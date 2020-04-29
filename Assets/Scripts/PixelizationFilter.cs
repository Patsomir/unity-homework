using System;
using UnityEngine;

public class PixelizationFilter : MonoBehaviour
{
    [SerializeField]
    private Material mat = null;

    [SerializeField]
    private int pixelSize = 10;

    private void Update()
    {
        if(mat != null)
        {
            mat.SetInt("_Width", Screen.width / pixelSize);
            mat.SetInt("_Height", Screen.height / pixelSize);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (mat != null)
        {
            Graphics.Blit(source, destination, mat);
        } else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void SetMaterial(Material mat)
    {
        this.mat = mat;
    }
}
