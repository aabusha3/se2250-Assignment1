using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color lastColor, endColor;

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color(50f / 255f, 50f / 255f, 255f / 255f));
        lastColor = GetComponent<Renderer>().material.GetColor("_Color");  
        endColor = new Color(lastColor.r += 1f / 255f, lastColor.g, lastColor.b);
    }


    private void Update()
    {
        lastColor = GetComponent<Renderer>().material.GetColor("_Color");

        if (lastColor.b == 255f / 255f && lastColor.r < 255f / 255f && lastColor.g <= 50f/255f)
            endColor = new Color(lastColor.r += 1f / 255f, lastColor.g, lastColor.b);
        else if(lastColor.r == 255f / 255f && lastColor.b > 50f / 255f)
            endColor = new Color(lastColor.r, lastColor.g, lastColor.b -= 1f / 255f);
        else if (lastColor.r == 255f / 255f && lastColor.g < 255f / 255f)
            endColor = new Color(lastColor.r, lastColor.g += 1f / 255f, lastColor.b);
        else if (lastColor.g == 255f / 255f && lastColor.r > 50f / 255f)
            endColor = new Color(lastColor.r -= 1f / 255f, lastColor.g, lastColor.b);
        else if (lastColor.g == 255f / 255f && lastColor.b < 255f / 255f)
            endColor = new Color(lastColor.r, lastColor.g, lastColor.b += 1f / 255f);
        else if (lastColor.b == 255f / 255f && lastColor.g > 50f / 255f)
            endColor = new Color(lastColor.r, lastColor.g-= 1f / 255f, lastColor.b);

        GetComponent<Renderer>().material.SetColor("_Color", endColor);
    }
}
