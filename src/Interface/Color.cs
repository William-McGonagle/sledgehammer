using System.Drawing;

public class Color
{

    public float R = 1.0f;
    public float G = 1.0f;
    public float B = 1.0f;
    public float A = 1.0f;

    public Color(string hex)
    {

        R = ((int)ColorTranslator.FromHtml(hex).R) / 255.0f;
        G = ((int)ColorTranslator.FromHtml(hex).G) / 255.0f;
        B = ((int)ColorTranslator.FromHtml(hex).B) / 255.0f;

    }

}