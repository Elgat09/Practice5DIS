using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePixelsImage : MonoBehaviour
{
    public Texture2D image;
    private Color[] originalTexture;
    public Color targetColor;
    public Color paintColor;
    public float tolerance;
  
    
    void Start()
    {
        originalTexture = image.GetPixels();
        Color[] colors = image.GetPixels();

        
        for (int i = 0; i < colors.Length; i++)
        {
            if (ColorWithinTolerance(colors[i], targetColor, tolerance))
            {
                // Replace the color within tolerance with the new color
                colors[i] = paintColor;
            }
        }

        // Apply the modified colors back to the texture
        image.SetPixels(colors);
        image.Apply();
    }
    bool ColorWithinTolerance(Color color1, Color color2, float tolerance)
    {
        float deltaR = Mathf.Abs(color1.r - color2.r);
        float deltaG = Mathf.Abs(color1.g - color2.g);
        float deltaB = Mathf.Abs(color1.b - color2.b);

        return deltaR <= tolerance && deltaG <= tolerance && deltaB <= tolerance;
    }
    private void OnDisable()
    {
        image.SetPixels(originalTexture);
        image.Apply();
    }
}
