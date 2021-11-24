using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Sledge.Plugin;
using Sledge.Windows;

namespace Sledge
{
    public static class Program
    {

        static void GenerateFontImage()
        {
            int bitmapWidth = 16 * 64;
            int bitmapHeight = 16 * 128;

            using (Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                Font font;
                font = new Font(new FontFamily("Consolas"), 80);

                using (var g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    for (int p = 0; p < 16; p++)
                    {
                        for (int n = 0; n < 16; n++)
                        {
                            char c = (char)(n + p * 16);
                            g.DrawString(c.ToString(), font, Brushes.White,
                                n * 64, p * 128);
                        }
                    }
                }
                bitmap.Save(Application.PersistentDataPath() + "/fonts/test.png");
            }
            // Process.Start(Settings.FontBitmapFilename);
        }

        private static void Main()
        {

            ConsoleWindow.WriteLine("Configuring Application Paths...");
            Application.ConfigureSystem();

            ConsoleWindow.WriteLine("Configuring Plugins...");
            PluginManager.Load();

            ConsoleWindow.WriteLine("Loading Settings...");
            SettingsData settings = new SettingsData(Application.PersistentDataPath() + "/settings.cfg");
            StyleSettingsData styleSettings = new StyleSettingsData(Application.PersistentDataPath() + "/" + settings.styleScheme);

            ConsoleWindow.WriteLine("Generating Fonts...");
            GenerateFontImage();

            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "Sledge - v1.0.0",
                Flags = ContextFlags.ForwardCompatible,
            };

            if (settings.useLaunchScreen)
            {

                using (var launch = new LaunchScreen())
                {

                    launch.Run();

                }

            }

            using (var consoleWindow = new ConsoleWindow())
            {

                consoleWindow.Run();

            }

            // using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            // {

            //     window.Run();

            // }

        }
    }
}