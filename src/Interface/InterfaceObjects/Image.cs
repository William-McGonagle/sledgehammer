using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Image : InterfaceObject
{

    public Texture texture;

    public int x;
    public int y;
    public int width;
    public int height;

    public Color defaultColor;

    public Image(string path, Color color)
    {

        texture = Texture.LoadFromFile(path);
        defaultColor = color;

    }

    public Image(Constraint _width, Constraint _height, string path, Color color)
    {

        widthConstraint = _width;
        heightConstraint = _height;

        texture = Texture.LoadFromFile(path);
        defaultColor = color;

    }

    public override void Render(GameWindow window, int x, int y)
    {

        int _x = widthConstraint.GetPosition(x);
        int _y = heightConstraint.GetPosition(y);
        int _width = widthConstraint.GetSize();
        int _height = heightConstraint.GetSize();

        InterfaceRenderer.DrawImageToScreen(window, _x, _y, _width, _height, texture, defaultColor);

    }

}