using Sledge.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using System.Drawing;
using System.Reflection;

namespace Sledge
{
    public class LaunchScreen : GameWindow
    {

        InterfaceRenderer uiRenderer = new InterfaceRenderer();

        Container background;

        double runTime = 0;

        public string version = "1.0.0";

        public LaunchScreen()
            : base(GameWindowSettings.Default, new NativeWindowSettings()
            {
                Size = new Vector2i(600, 400),
                Title = "Sledge - v1.0.0",
                Flags = ContextFlags.ForwardCompatible,
            })
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

            uiRenderer.Load();

            background = new Container(new FixedConstraint(600), new FixedConstraint(400), new Color("#" + StyleSettingsData.singleton.background2));

            background.incrementX = false;

            background.children.Add(new Image(new FixedConstraint(600), new FixedConstraint(400), "./res/splash/background0.png", new Color("#" + StyleSettingsData.singleton.background1)));
            background.children.Add(new Image(new FixedConstraint(600), new FixedConstraint(400), "./res/splash/background1.png", new Color("#" + StyleSettingsData.singleton.background0)));
            background.children.Add(new Image(new FixedConstraint(600), new FixedConstraint(400), "./res/splash/text.png", new Color("#" + StyleSettingsData.singleton.background7)));

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            runTime += RenderTime;

            Input.Update(MouseState);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            background.Render(this, 0, 0);
            InterfaceRenderer.DrawText(this, 600 - ((version.Length + 2) * 8), 380, 8, "v" + version, new Color("#" + StyleSettingsData.singleton.background7));

            SwapBuffers();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            runTime += UpdateTime;

            if (runTime > 8) Close();

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