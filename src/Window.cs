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

        Button closeTexture;
        Button minTexture;
        Button maxTexture;

        Container sidebar;
        Container main;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {

            CenterWindow();

            // 
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

            closeTexture = new Button(new FixedConstraint(20), new FixedConstraint(20), Application.PersistentDataPath() + "/res/icons/close.png");
            minTexture = new Button(new FixedConstraint(20), new FixedConstraint(20), Application.PersistentDataPath() + "/res/icons/min.png");
            maxTexture = new Button(new FixedConstraint(20), new FixedConstraint(20), Application.PersistentDataPath() + "/res/icons/max.png");

            closeTexture.onClick += Close;
            minTexture.onClick += delegate () { WindowState = WindowState.Minimized; };
            maxTexture.onClick += delegate ()
            {
                if (WindowState == WindowState.Fullscreen)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Fullscreen;
            };

            sidebar = new Container(new FixedConstraint(260), new FixedConstraint(Size.Y), new Color("#" + StyleSettingsData.singleton.background1));
            main = new Container(new FixedConstraint(Size.X - 260), new FixedConstraint(Size.Y), new Color("#" + StyleSettingsData.singleton.background0));

            sidebar.children.Add(closeTexture);
            sidebar.children.Add(minTexture);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            Input.Update(MouseState);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            sidebar.Render(this, 0, 0);
            main.Render(this, 260, 0);

            InterfaceRenderer.DrawText(this, 20, 40, 10, "Welcome to Sledge... ", new Color("#" + StyleSettingsData.singleton.background7));

            SwapBuffers();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
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