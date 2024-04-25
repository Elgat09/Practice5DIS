using UnityEngine;

public class VoxelGen : MonoBehaviour
{
    public Texture2D image; // Assign your image in the Inspector
    public float cubeSize = 1f; // Adjust the size of each cube
    private bool gravityApplied = false;

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
                if (pixelColor.a > 0f)
                {

                    // Create a cube for each pixel
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x * cubeSize, y * cubeSize, 0f); // Align cubes
                cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize); // Set cube size
                cube.GetComponent<Renderer>().material.color = pixelColor; // Set cube color
                Rigidbody rb = cube.AddComponent<Rigidbody>();
                rb.useGravity = false;
                }
            }
        }


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gravityApplied)
        {
            ApplyGravityToCubes();
            gravityApplied = true;
        }
    }

    void ApplyGravityToCubes()
    {
        // Enable gravity for all cubes
        Rigidbody[] rigidBodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in rigidBodies)
        {
            rb.useGravity = true;
        }
    }

}

