using System;
using System.Diagnostics;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Sledge;

namespace Sledge.Windows
{

    public class MainWindow : GameWindow
    {

        Topbar topbar;
        Container background;

        public MainWindow() : base(GameWindowSettings.Default, new NativeWindowSettings()
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

            background = new Container(
                new FixedConstraint(800),
                new FixedConstraint(600),
                new Color("#" + StyleSettingsData.singleton.background0),
                new InterfaceObject[] {
                    new Container(
                        new FixedConstraint(this.Size.X),
                        new FixedConstraint(20),
                        new Color("#" + StyleSettingsData.singleton.background1),
                        new InterfaceObject[] {
                            new TextBackgroundButton(
                                new FixedConstraint(80),
                                new FixedConstraint(20),
                                "File"
                            ) {
                                fontSize = 8,
                                horizontalAlign = 1
                            },
                            new TextBackgroundButton(
                                new FixedConstraint(80),
                                new FixedConstraint(20),
                                "Edit"
                            ) {
                                fontSize = 8,
                                horizontalAlign = 1
                            }
                        }
                    ),
                    new Container(
                        new FixedConstraint(this.Size.X),
                        new FixedConstraint(this.Size.Y - 20),
                        new Color("#" + StyleSettingsData.singleton.background0),
                        new InterfaceObject[] {
                            new Container(
                                new FixedConstraint(40),
                                new FixedConstraint(this.Size.Y - 20),
                                new Color("#" + StyleSettingsData.singleton.background0),
                                new InterfaceObject[] {
                                    new Button(
                                        new FixedConstraint(40),
                                        new FixedConstraint(40),
                                        Application.PersistentDataPath() + "/res/icons/mouse.png"
                                    ),
                                    new Button(
                                        new FixedConstraint(40),
                                        new FixedConstraint(40),
                                        Application.PersistentDataPath() + "/res/icons/camera.png"
                                    ),
                                    new Button(
                                        new FixedConstraint(40),
                                        new FixedConstraint(40),
                                        Application.PersistentDataPath() + "/res/icons/mouse.png"
                                    )
                                }
                            ) {
                                incrementX = false, incrementY = true
                            },
                            new Container(
                                new FixedConstraint(1),
                                new FixedConstraint(this.Size.Y - 20),
                                new Color("#" + StyleSettingsData.singleton.background1)
                            )
                        }
                    )
                    {
                        incrementX = true,
                        incrementY = false
                    }
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
            topbar.Render(this, 0, 0);

            SwapBuffers();

        }

    }

}