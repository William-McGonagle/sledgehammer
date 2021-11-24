using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Text : InterfaceObject
{

    public string data;

    public Color defaultColor;

    public int verticalAlign = 1; // 0 - top, 1 - middle, 2 - bottom
    public int horizontalAlign = 0; // 0 - left, 1 - middle, 2 - right

    public int padding = 10;

    public Text(string _data)
    {

        data = _data;

        widthConstraint = new FixedConstraint(20);
        heightConstraint = new FixedConstraint(20);

        defaultColor = new Color("#" + StyleSettingsData.singleton.background7);

    }

    public Text(Constraint _width, Constraint _height, string _data)
    {

        data = _data;

        widthConstraint = _width;
        heightConstraint = _height;

        defaultColor = new Color("#" + StyleSettingsData.singleton.background7);

    }

    public override void Render(GameWindow window, int x, int y)
    {

        int _x = widthConstraint.GetPosition(x);
        int _y = heightConstraint.GetPosition(y);
        int _width = widthConstraint.GetSize();
        int _height = heightConstraint.GetSize();

        switch (verticalAlign)
        {

            case 0:

                _y += padding;

                break;

            case 1:

                _y += (_height / 2) - 10;

                break;

            case 2:

                _y += _height - padding;

                break;

            default:
                break;

        }

        switch (horizontalAlign)
        {

            case 0:

                _x += padding;

                break;

            case 1:

                _x += (_width / 2) - 10;

                break;

            case 2:

                _x += _width - padding;

                break;

            default:
                break;

        }

        InterfaceRenderer.DrawText(window, _x, _y, 10, data, defaultColor);

    }

}