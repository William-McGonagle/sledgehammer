using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Button : InterfaceObject
{

    public Texture texture;

    public Color defaultColor;
    public Color highlightColor;

    public delegate void OnClick();
    public OnClick onClick = null;

    public Button(string path)
    {

        widthConstraint = new FixedConstraint(20);
        heightConstraint = new FixedConstraint(20);

        texture = Texture.LoadFromFile(path);
        defaultColor = new Color("#" + StyleSettingsData.singleton.background7);
        highlightColor = new Color("#" + StyleSettingsData.singleton.background6);

    }

    public Button(Constraint _width, Constraint _height, string path)
    {

        widthConstraint = _width;
        heightConstraint = _height;

        texture = Texture.LoadFromFile(path);
        defaultColor = new Color("#" + StyleSettingsData.singleton.background7);
        highlightColor = new Color("#" + StyleSettingsData.singleton.background6);

    }

    public override void Render(GameWindow window, int x, int y)
    {

        int _x = widthConstraint.GetPosition(x);
        int _y = heightConstraint.GetPosition(y);
        int _width = widthConstraint.GetSize();
        int _height = heightConstraint.GetSize();

        if (Input.MouseX > _x && Input.MouseX < _x + _width && Input.MouseY > _y && Input.MouseY < _y + _height)
        {

            if (Input.GetMouseButton(0))
                if (onClick != null)
                    onClick();

            InterfaceRenderer.DrawImageToScreen(window, _x, _y, _width, _height, texture, highlightColor);
        }
        else
        {
            InterfaceRenderer.DrawImageToScreen(window, _x, _y, _width, _height, texture, defaultColor);
        }

    }

}