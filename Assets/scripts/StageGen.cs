using UnityEngine;

public class StageGen : MonoBehaviour
{
    public Texture2D image; // Assign your image in the Inspector
    public float cubeSize = 1f; // Adjust the size of each cube

    void Start()
    {
        Color[] pixels = image.GetPixels();
        int width = image.width;
        int height = image.height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color pixelColor = pixels[y * width + x];

                // Only create black cubes
                if (pixelColor == Color.black)
                {
                    // Create a cube for each black pixel
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x * cubeSize, 0f, y * cubeSize); // Align cubes horizontally
                    cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize); // Set cube size
                    cube.GetComponent<Renderer>().material.color = Color.black; // Set cube color
                }
            }
        }
    }
}
