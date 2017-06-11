using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anamorphism : MonoBehaviour
{
    public int pixelWidth;
    public int pixelHeight;
    public int multiplier;
    public GameObject pixel;
    public Vector3 startPoint;
    public Texture2D texture;

	void Start ()
    {
        Invoke("Go", 1);
	}

    void Go()
    {
        //Going row by row.
        for (int i = 0; i < pixelWidth; i++)
        {
            for (int j = 0; j < pixelHeight; j++)
            {
                //1 GameObject per pixel
                GameObject p = Instantiate(pixel, startPoint + new Vector3(1, i, j), Quaternion.identity);

                //Color of texture's pixel
                p.GetComponent<Renderer>().material.color = texture.GetPixel(j*multiplier, i*multiplier);

                //Delete if color is transparent
                if (p.GetComponent<Renderer>().material.color.a == 0)
                    Destroy(p);

                Vector3 unit = p.transform.position;

                //Get the direction from the viewing point
                Vector3 n = (unit - transform.position).normalized;

                //Move it back along the line
                p.transform.position += (Random.Range(1, 200) * n);

                //Debug.Log(Vector3.Distance(transform.position, p.transform.position) / Vector3.Distance(transform.position, unit) + " :: " + Vector3.Distance(transform.position, p.transform.position) + " : " + Vector3.Distance(transform.position, unit));

                float f = (Vector3.Distance(transform.position, p.transform.position) / Vector3.Distance(transform.position, unit) );
                p.transform.localScale = new Vector3(f, f, f);


            }
        }
    }

    public Texture2D GetRTPixels(RenderTexture rt)
    {
        // Remember currently active render texture
        RenderTexture currentActiveRT = RenderTexture.active;

        // Set the supplied RenderTexture as the active one
        RenderTexture.active = rt;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        // Restorie previously active render texture
        RenderTexture.active = currentActiveRT;
        return tex;
    }
}
