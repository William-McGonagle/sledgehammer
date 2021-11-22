using System.Collections.Generic;
using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Container : InterfaceObject
{

    public Texture texture;
    public Color defaultColor;

    public bool incrementX = true;
    public bool incrementY = false;

    public List<InterfaceObject> children = new List<InterfaceObject>();

    public Container()
    {

        widthConstraint = new FixedConstraint(0);
        heightConstraint = new FixedConstraint(0);

        texture = Texture.LoadFromFile(Application.PersistentDataPath() + "/res/white.png");

    }

    public Container(Color color)
    {

        widthConstraint = new FixedConstraint(0);
        heightConstraint = new FixedConstraint(0);

        texture = Texture.LoadFromFile(Application.PersistentDataPath() + "/res/white.png");
        defaultColor = color;

    }

    public Container(Constraint _width, Constraint _height, Color color)
    {

        widthConstraint = _width;
        heightConstraint = _height;

        texture = Texture.LoadFromFile(Application.PersistentDataPath() + "/res/white.png");
        defaultColor = color;

    }

    public override void Render(GameWindow window, int x, int y)
    {

        int _x = widthConstraint.GetPosition(x);
        int _y = heightConstraint.GetPosition(y);
        int _width = widthConstraint.GetSize();
        int _height = heightConstraint.GetSize();

        InterfaceRenderer.DrawImageToScreen(window, _x, _y, _width, _height, texture, defaultColor);

        int curX = _x;
        int curY = _y;

        for (int i = 0; i < children.Count; i++)
        {

            children[i].Render(window, curX, curY);

            if (incrementX) curX += children[i].widthConstraint.GetSize();
            if (incrementY) curY += children[i].heightConstraint.GetSize();

        }

    }

}