using Sledge.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using System.Drawing;

namespace Sledge
{
    public class Window : GameWindow
    {

        Screen currentScreen = new Screen("Start");
        InterfaceRenderer uiRenderer = new InterfaceRenderer();

        Topbar topbar;

        Container sidebar;
        Container main;

        Container colors;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {

            CenterWindow();

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

            topbar = new Topbar(this) { maxButtonEnabled = false };

            sidebar = new Container(new FixedConstraint(260), new FixedConstraint(Size.Y), new Color("#" + StyleSettingsData.singleton.background1));
            main = new Container(new FixedConstraint(Size.X - 260), new FixedConstraint(Size.Y), new Color("#" + StyleSettingsData.singleton.background0));

            colors = new Container(new FixedConstraint(200), new FixedConstraint(40 * 7), new Color("#FFFFFF"));

            colors.incrementX = false;
            colors.incrementY = true;

            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.yellow)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.orange)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.red)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.magenta)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.violet)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.blue)));
            colors.children.Add(new Container(new FixedConstraint(200), new FixedConstraint(40), new Color("#" + StyleSettingsData.singleton.cyan)));

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            Input.Update(MouseState, KeyboardState);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            sidebar.Render(this, 0, 0);
            main.Render(this, 260, 0);
            topbar.Render(this, 0, 0);

            colors.Render(this, 280, 20);

            InterfaceRenderer.DrawText(this, 20, 40, 10, "Welcome to Sledge... ", new Color("#" + StyleSettingsData.singleton.background7));

            SwapBuffers();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X * 2, Size.Y * 2);
        }

        protected override void OnUnload()
        {

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            uiRenderer.Unload();

            base.OnUnload();
        }
    }
}