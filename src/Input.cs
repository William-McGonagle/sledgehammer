using OpenTK.Windowing.GraphicsLibraryFramework;

public class Input
{

    public static float MouseX;
    public static float MouseY;

    public static bool[] MouseClick;
    public static bool[] MouseDown;
    public static bool[] MouseUp;

    public static void Update(MouseState mouse)
    {

        MouseX = mouse.X;
        MouseY = mouse.Y;

        MouseDown = new bool[] {
            mouse.IsButtonDown(MouseButton.Left) && !MouseClick[0],
            mouse.IsButtonDown(MouseButton.Right) && !MouseClick[1],
            mouse.IsButtonDown(MouseButton.Middle) && !MouseClick[2],
        };

        MouseClick = new bool[] {
            mouse.IsButtonDown(MouseButton.Left),
            mouse.IsButtonDown(MouseButton.Right),
            mouse.IsButtonDown(MouseButton.Middle),
        };

        MouseUp = new bool[] {
            !mouse.IsButtonDown(MouseButton.Left) && MouseClick[0],
            !mouse.IsButtonDown(MouseButton.Right) && MouseClick[1],
            !mouse.IsButtonDown(MouseButton.Middle) && MouseClick[2],
        };

    }

    public static bool GetMouseButtonDown(MouseButton button)
    {

        if (button == MouseButton.Left) return MouseDown[0];
        if (button == MouseButton.Right) return MouseDown[1];
        if (button == MouseButton.Middle) return MouseDown[2];

        return false;

    }

    public static bool GetMouseButtonUp(MouseButton button)
    {

        if (button == MouseButton.Left) return MouseUp[0];
        if (button == MouseButton.Right) return MouseUp[1];
        if (button == MouseButton.Middle) return MouseUp[2];

        return false;

    }

    public static bool GetMouseButton(MouseButton button)
    {

        if (button == MouseButton.Left) return MouseClick[0];
        if (button == MouseButton.Right) return MouseClick[1];
        if (button == MouseButton.Middle) return MouseClick[2];

        return false;

    }

}