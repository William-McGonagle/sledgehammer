using System.Collections.Generic;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Topbar : InterfaceObject
{

    public Vector2 mouseLockPosition;
    public bool mouseLocked = false;

    public Button closeButton;
    public Button minButton;
    public Button maxButton;

    public Container background;
    public Container border;

    public bool minButtonEnabled = true;
    public bool maxButtonEnabled = true;
    public bool drawBackground = true;

    public Topbar(GameWindow window)
    {

        closeButton = new Button(
            new FixedConstraint(20),
            new FixedConstraint(20),
            Application.PersistentDataPath() + "/res/icons/close.png"
        );

        minButton = new Button(
            new FixedConstraint(20),
            new FixedConstraint(20),
            Application.PersistentDataPath() + "/res/icons/min.png"
        );

        maxButton = new Button(
            new FixedConstraint(20),
            new FixedConstraint(20),
            Application.PersistentDataPath() + "/res/icons/max.png"
        );

        background = new Container(
            new FixedConstraint(window.Size.X),
            new FixedConstraint(20),
            new Color("#" + StyleSettingsData.singleton.background1)
        );

        border = new Container(
            new FixedConstraint(window.Size.X),
            new FixedConstraint(1),
            new Color("#" + StyleSettingsData.singleton.background0)
        );

        closeButton.onClick += delegate ()
        {

            window.Close();

        };

        minButton.onClick += delegate ()
        {

            window.WindowState = OpenTK.Windowing.Common.WindowState.Minimized;

        };

        maxButton.onClick += delegate ()
        {

            if (window.WindowState == OpenTK.Windowing.Common.WindowState.Normal) window.WindowState = OpenTK.Windowing.Common.WindowState.Fullscreen;
            if (window.WindowState == OpenTK.Windowing.Common.WindowState.Fullscreen) window.WindowState = OpenTK.Windowing.Common.WindowState.Normal;

        };

    }

    public override void Render(GameWindow window, int x, int y)
    {

        if (Input.MouseX > x && Input.MouseY > y && Input.MouseX < x + background.widthConstraint.GetSize() && Input.MouseY < y + background.heightConstraint.GetSize() && Input.GetMouseButtonDown(0))
        {

            mouseLockPosition = window.MouseState.Position;
            mouseLocked = true;

        }

        if (mouseLocked)
        {

            if (Input.GetMouseButton(0))
            {

                window.Location += (Vector2i)(window.MouseState.Position - mouseLockPosition);

            }
            else
            {

                mouseLocked = false;

            }

        }

        if (drawBackground)
        {

            background.Render(window, 0, 0);
            border.Render(window, 0, 19);

        }

        closeButton.Render(window, 0, 0);
        if (minButtonEnabled) minButton.Render(window, 20, 0);
        if (maxButtonEnabled) maxButton.Render(window, 40, 0);

    }

}