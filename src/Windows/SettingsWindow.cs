using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Sledge;

namespace Sledge.Windows
{

    public class SettingsWindow : GameWindow
    {

        Topbar topbar;
        Container background;

        Container generalScreen;
        Container colorScreen;
        Container keyScreen;

        public int currentScreen = 0;

        public SettingsWindow() : base(GameWindowSettings.Default, new NativeWindowSettings()
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
            topbar = new Topbar(this) { maxButtonEnabled = false };

            background = new Container(new Color("#" + StyleSettingsData.singleton.background0));
            background.heightConstraint = new FixedConstraint(600);
            background.widthConstraint = new FixedConstraint(800);

            background.children.Add(
                new Container(
                    new FixedConstraint(260),
                    new FixedConstraint(600),
                    new Color("#" + StyleSettingsData.singleton.background1),
                    new InterfaceObject[] {
                        new TextBackgroundButton(
                            new FixedConstraint(260),
                            new FixedConstraint(50),
                            "General"
                        ) {

                            onClick = delegate () {

                                currentScreen = 0;

                            }

                        },
                        new TextBackgroundButton(
                            new FixedConstraint(260),
                            new FixedConstraint(50),
                            "Key Bindings"
                        ) {

                            onClick = delegate () {

                                currentScreen = 1;

                            }

                        },
                        new TextBackgroundButton(
                            new FixedConstraint(260),
                            new FixedConstraint(50),
                            "Color Scheme"
                        ) {

                            onClick = delegate () {

                                currentScreen = 2;

                            }

                        },
                        new TextBackgroundButton(
                            new FixedConstraint(260),
                            new FixedConstraint(50),
                            "Plugins"
                        ) {

                            onClick = delegate () {

                                currentScreen = 3;

                            }

                        },
                    }
                )
                { incrementX = false, incrementY = true }
            );

            generalScreen = new Container(
                new FixedConstraint(800 - 260),
                new FixedConstraint(600),
                new Color("#FF0000")
            );

            keyScreen = new Container(
                new FixedConstraint(800 - 260),
                new FixedConstraint(600),
                new Color("#0000FF")
            );

            colorScreen = new Container(
                new FixedConstraint(800 - 260),
                new FixedConstraint(600),
                new Color("#00FF00")
            );

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            Input.Update(MouseState);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            background.Render(this, 0, 20);
            topbar.Render(this, 0, 0);

            switch (currentScreen)
            {

                case 0:

                    generalScreen.Render(this, 260, 20);

                    break;

                case 1:

                    keyScreen.Render(this, 260, 20);

                    break;

                case 2:

                    colorScreen.Render(this, 260, 20);

                    break;

            }

            SwapBuffers();

        }

    }

}