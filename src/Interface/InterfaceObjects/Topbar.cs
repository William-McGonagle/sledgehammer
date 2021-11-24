using System.Collections.Generic;
using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public class Topbar : InterfaceObject
{

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

            if (window.WindowState == OpenTK.Windowing.Common.WindowState.Normal) window.WindowState = OpenTK.Windowing.Common.WindowState.Maximized;
            if (window.WindowState == OpenTK.Windowing.Common.WindowState.Maximized) window.WindowState = OpenTK.Windowing.Common.WindowState.Normal;

        };

    }

    public override void Render(GameWindow window, int x, int y)
    {

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