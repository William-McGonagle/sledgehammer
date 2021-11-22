using OpenTK.Windowing.GraphicsLibraryFramework;

public class Input
{

    public static float MouseX;
    public static float MouseY;

    public static bool[] MouseClick;

    public static void Update(MouseState mouse)
    {

        MouseX = mouse.X;
        MouseY = mouse.Y;

        MouseClick = new bool[] {
            mouse.IsButtonDown(MouseButton.Left),
            mouse.IsButtonDown(MouseButton.Right),
            mouse.IsButtonDown(MouseButton.Middle),
        };

    }

    public static bool GetMouseButton(MouseButton button)
    {

        if (button == MouseButton.Left) return MouseClick[0];
        if (button == MouseButton.Right) return MouseClick[1];
        if (button == MouseButton.Middle) return MouseClick[2];

        return false;

    }

}