using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Sledge;

namespace Sledge.Windows
{

    public class ConsoleWindow : GameWindow
    {

        Topbar topbar;
        Container background;
        TextInput input;

        int scrollOffset;

        public static string[] output = { };

        public int currentScreen = 0;

        public static void WriteLine(string line)
        {

            List<string> tempString = new List<string>(output);
            tempString.Add(line);
            output = tempString.ToArray();

        }

        public ConsoleWindow() : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            Size = new Vector2i(800, 620),
            Title = "Sledge - v1.0.0",
            Flags = ContextFlags.ForwardCompatible,
        })
        {

            WindowBorder = WindowBorder.Hidden;

        }

        protected override void OnLoad()
        {

            base.OnLoad();

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.Viewport(0, 0, Size.X * 2, Size.Y * 2);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            InterfaceRenderer.Load();

            // Load Components
            topbar = new Topbar(this) { maxButtonEnabled = true };

            background = new Container(new Color("#" + StyleSettingsData.singleton.background0));
            background.heightConstraint = new FixedConstraint(600);
            background.widthConstraint = new FixedConstraint(800);

            input = new TextInput(
                new FixedConstraint(800),
                new FixedConstraint(30),
                "Test"
            )
            {

                onEnter = delegate (string inputData)
                {

                    // Clear Input
                    input.data = "";

                    // Add Input Data to Console
                    WriteLine("$~ " + inputData);

                    // Check for Commands
                    CommandBase.ParseCommandString(inputData);

                }

            };

            background = new Container(
                new FixedConstraint(800),
                new FixedConstraint(600),
                new Color("#" + StyleSettingsData.singleton.background0),
                new InterfaceObject[] {
                    new Container(
                        new FixedConstraint(800),
                        new FixedConstraint(600 - 30),
                        new Color("#" + StyleSettingsData.singleton.background0)
                    ),
                    new Container(
                        new FixedConstraint(800),
                        new FixedConstraint(30),
                        new Color("#" + StyleSettingsData.singleton.background1)
                    )
                }
            )
            {
                incrementX = false,
                incrementY = true
            };

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            Input.Update(MouseState, KeyboardState);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            background.Render(this, 0, 20);

            scrollOffset -= (int)Input.mouseScrollWheel;

            if (scrollOffset > ((output.Length + 1) * 24) + 30 - Size.Y) scrollOffset--;
            if (scrollOffset < 0) scrollOffset++;

            // InterfaceRenderer.DrawText(this, 500, 20, 6, "" + scrollOffset, new Color("#" + StyleSettingsData.singleton.red));
            // InterfaceRenderer.DrawText(this, 480, 20, 6, "" + (((output.Length + 2) * 24) - Size.Y), new Color("#" + StyleSettingsData.singleton.green));

            for (int i = 0; i < output.Length; i++)
            {

                InterfaceRenderer.DrawText(this, 10, 20 + (i * 24) - scrollOffset, 8, output[i], new Color("#" + StyleSettingsData.singleton.background7));

            }

            topbar.Render(this, 0, 0);
            input.Render(this, 0, this.Size.Y - 30);

            SwapBuffers();

        }

    }

}