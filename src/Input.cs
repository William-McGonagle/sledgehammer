using System;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Input
{

    public static float MouseX;
    public static float MouseY;

    public static string currentText;
    public static bool deleteKey;
    public static bool enterKey;
    public static bool commandKey;

    public static float mouseScrollWheel;

    public static bool[] MouseClick;
    public static bool[] MouseDown;
    public static bool[] MouseUp;

    public static float GetLetterDistance(char a, char b)
    {

        string[] keyboard = new string[] {
            "1234567890-=",
            "qwertyuiop[]",
            "asdfghjkl;'",
            "zxcvbnm,./",
            "^⌥⌘ "
        };

        int rowA = -1;
        int colA = -1;
        int rowB = -1;
        int colB = -1;

        for (int y = 0; y < keyboard.Length; y++)
        {
            for (int x = 0; x < keyboard[y].Length; x++)
            {

                if (keyboard[y][x] == a)
                {

                    rowA = x;
                    colA = y;

                }

                if (keyboard[y][x] == b)
                {

                    rowB = x;
                    colB = y;

                }

            }
        }

        int distX = rowA - rowB;
        int distY = colA - colB;

        return (float)Math.Sqrt(distX * distX + distY * distY);

    }

    public static void Update(MouseState mouse, KeyboardState keyboard)
    {

        MouseX = mouse.X;
        MouseY = mouse.Y;

        currentText = "";

        if (keyboard.IsKeyPressed(Keys.A)) currentText += "a";
        if (keyboard.IsKeyPressed(Keys.B)) currentText += "b";
        if (keyboard.IsKeyPressed(Keys.C)) currentText += "c";
        if (keyboard.IsKeyPressed(Keys.D)) currentText += "d";
        if (keyboard.IsKeyPressed(Keys.E)) currentText += "e";
        if (keyboard.IsKeyPressed(Keys.F)) currentText += "f";
        if (keyboard.IsKeyPressed(Keys.G)) currentText += "g";
        if (keyboard.IsKeyPressed(Keys.H)) currentText += "h";
        if (keyboard.IsKeyPressed(Keys.I)) currentText += "i";
        if (keyboard.IsKeyPressed(Keys.J)) currentText += "j";
        if (keyboard.IsKeyPressed(Keys.K)) currentText += "k";
        if (keyboard.IsKeyPressed(Keys.L)) currentText += "l";
        if (keyboard.IsKeyPressed(Keys.M)) currentText += "m";
        if (keyboard.IsKeyPressed(Keys.N)) currentText += "n";
        if (keyboard.IsKeyPressed(Keys.O)) currentText += "o";
        if (keyboard.IsKeyPressed(Keys.P)) currentText += "p";
        if (keyboard.IsKeyPressed(Keys.Q)) currentText += "q";
        if (keyboard.IsKeyPressed(Keys.R)) currentText += "r";
        if (keyboard.IsKeyPressed(Keys.S)) currentText += "s";
        if (keyboard.IsKeyPressed(Keys.T)) currentText += "t";
        if (keyboard.IsKeyPressed(Keys.U)) currentText += "u";
        if (keyboard.IsKeyPressed(Keys.V)) currentText += "v";
        if (keyboard.IsKeyPressed(Keys.W)) currentText += "w";
        if (keyboard.IsKeyPressed(Keys.X)) currentText += "x";
        if (keyboard.IsKeyPressed(Keys.Y)) currentText += "y";
        if (keyboard.IsKeyPressed(Keys.Z)) currentText += "z";

        if (keyboard.IsKeyPressed(Keys.Comma)) currentText += ",";
        if (keyboard.IsKeyPressed(Keys.Period)) currentText += ".";
        if (keyboard.IsKeyPressed(Keys.Semicolon)) currentText += ";";
        if (keyboard.IsKeyPressed(Keys.Slash)) currentText += "/";
        if (keyboard.IsKeyPressed(Keys.Backslash)) currentText += "\\";
        if (keyboard.IsKeyPressed(Keys.D1) && keyboard.IsKeyDown(Keys.LeftShift)) currentText += "!";

        if (keyboard.IsKeyPressed(Keys.Space)) currentText += " ";
        if (keyboard.IsKeyPressed(Keys.LeftShift)) currentText = currentText.ToUpper();

        deleteKey = keyboard.IsKeyPressed(Keys.Backspace);
        enterKey = keyboard.IsKeyPressed(Keys.Enter);
        commandKey = keyboard.IsKeyDown(Keys.LeftControl);

        mouseScrollWheel = mouse.ScrollDelta.Y;

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