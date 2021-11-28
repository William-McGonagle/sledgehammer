using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class TextBackgroundButton : InterfaceObject
{

    public string data;

    public Color defaultColor;
    public Color highlightColor;

    public Color textColor;

    public delegate void OnClick();
    public OnClick onClick = null;

    public int verticalAlign = 1; // 0 - top, 1 - middle, 2 - bottom
    public int horizontalAlign = 0; // 0 - left, 1 - middle, 2 - right

    public int padding = 10;
    public int fontSize = 10;

    public TextBackgroundButton(string _data)
    {

        data = _data;

        widthConstraint = new FixedConstraint(20);
        heightConstraint = new FixedConstraint(20);

        defaultColor = new Color("#" + StyleSettingsData.singleton.background1);
        highlightColor = new Color("#" + StyleSettingsData.singleton.background2);

        textColor = new Color("#" + StyleSettingsData.singleton.background7);

    }

    public TextBackgroundButton(Constraint _width, Constraint _height, string _data)
    {

        data = _data;

        widthConstraint = _width;
        heightConstraint = _height;

        defaultColor = new Color("#" + StyleSettingsData.singleton.background1);
        highlightColor = new Color("#" + StyleSettingsData.singleton.background2);

        textColor = new Color("#" + StyleSettingsData.singleton.background7);

    }

    public override void Render(GameWindow window, int x, int y)
    {

        int _x = widthConstraint.GetPosition(x);
        int _y = heightConstraint.GetPosition(y);
        int _width = widthConstraint.GetSize();
        int _height = heightConstraint.GetSize();

        int textX = 0;
        int textY = 0;

        switch (verticalAlign)
        {

            case 0:

                textY = _y + padding;

                break;

            case 1:

                textY = _y + (_height / 2) - fontSize;

                break;

            case 2:

                textY = _y + _height - padding;

                break;

            default:
                break;

        }

        switch (horizontalAlign)
        {

            case 0:

                textX = _x + padding;

                break;

            case 1:

                textX = _x + (_width / 2) - (fontSize * data.Length / 2);

                break;

            case 2:

                textX = _x + _width - padding;

                break;

            default:
                break;

        }

        if (Input.MouseX > _x && Input.MouseX < _x + _width && Input.MouseY > _y && Input.MouseY < _y + _height)
        {

            if (Input.GetMouseButton(0))
                if (onClick != null)
                    onClick();

            InterfaceRenderer.DrawToScreen(window, _x, _y, _width, _height, highlightColor);
            InterfaceRenderer.DrawText(window, textX, textY, fontSize, data, textColor);

        }
        else
        {

            InterfaceRenderer.DrawToScreen(window, _x, _y, _width, _height, defaultColor);
            InterfaceRenderer.DrawText(window, textX, textY, fontSize, data, textColor);

        }

    }

}