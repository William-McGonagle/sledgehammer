using System.Drawing;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using Sledge;
using Sledge.Common;

public static class InterfaceRenderer
{

    private static float[] _vertices =
        {
            -0.0f,  1.0f, 0.0f, 1.0f, 1.0f, // top right
            -0.0f, -1.0f, 0.0f, 1.0f, 0.0f, // bottom right
            -1.0f, -1.0f, 0.0f, 0.0f, 0.0f, // bottom left
            -1.0f,  1.0f, 0.0f, 0.0f, 1.0f // top left
        };

    private static uint[] _indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

    private static int _vertexBufferObject;
    private static int _vertexArrayObject;
    private static int _elementBufferObject;

    private static Shader _shader;
    private static Texture _texture;
    private static Texture _fonts;

    public static void Load()
    {

        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);

        _texture = Texture.LoadFromFile(Application.PersistentDataPath() + "/res/white.png");
        _fonts = Texture.LoadFromFile(Application.PersistentDataPath() + "/fonts/test.png");

        _shader = new Shader(Application.PersistentDataPath() + "/shaders/ui.vert", Application.PersistentDataPath() + "/shaders/ui.frag");
        _shader.Use();

        int vertexLocation = _shader.GetAttribLocation("aPosition");
        GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        int texCoordLocation = _shader.GetAttribLocation("aTexCoord");
        GL.EnableVertexAttribArray(texCoordLocation);
        GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

    }

    public static void DrawImageToScreen(GameWindow window, int _x, int _y, int _width, int _height, Texture texture)
    {

        float x = 2.0f * (((float)_x) / window.Size.X) - 1.0f;
        float y = 2.0f * (((float)-_y) / window.Size.Y) + 1.0f;
        float width = 2.0f * ((float)_width) / window.Size.X;
        float height = 2.0f * ((float)_height) / window.Size.Y;

        _vertices = new float[]
        {
            x + width, y - height, 0.0f, 1.0f, 0.0f, // top right
            x + width, y         , 0.0f, 1.0f, 1.0f, // bottom right
            x        , y         , 0.0f, 0.0f, 1.0f, // bottom left
            x        , y - height, 0.0f, 0.0f, 0.0f  // top left
        };

        int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "color");
        GL.Uniform4(vertexColorLocation, 1.0f, 1.0f, 1.0f, 1.0f);

        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.BindVertexArray(_vertexArrayObject);

        _shader.Use();
        texture.Use(TextureUnit.Texture0);

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

    }

    public static void DrawImageToScreen(GameWindow window, int _x, int _y, int _width, int _height, Texture texture, Color color)
    {

        float x = 2.0f * (((float)_x) / window.Size.X) - 1.0f;
        float y = 2.0f * (((float)-_y) / window.Size.Y) + 1.0f;
        float width = 2.0f * ((float)_width) / window.Size.X;
        float height = 2.0f * ((float)_height) / window.Size.Y;

        _vertices = new float[]
        {
            x + width, y - height, 0.0f, 1.0f, 0.0f, // top right
            x + width, y         , 0.0f, 1.0f, 1.0f, // bottom right
            x        , y         , 0.0f, 0.0f, 1.0f, // bottom left
            x        , y - height, 0.0f, 0.0f, 0.0f  // top left
        };

        int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "color");
        GL.Uniform4(vertexColorLocation, color.R, color.G, color.B, 1.0f);

        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.BindVertexArray(_vertexArrayObject);

        _shader.Use();
        texture.Use(TextureUnit.Texture0);

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

    }

    public static void DrawText(GameWindow window, int _x, int _y, int _width, string text, Color color)
    {

        for (int i = 0; i < text.Length; i++)
        {

            if (text[i] == ' ') continue;
            DrawCharacter(window, _x + i * _width, _y, _width, _width * 2, text[i], color);

        }

    }

    public static void DrawCharacter(GameWindow window, int _x, int _y, int _width, int _height, char character, Color color)
    {

        float x = 2.0f * (((float)_x) / window.Size.X) - 1.0f;
        float y = 2.0f * (((float)-_y) / window.Size.Y) + 1.0f;
        float width = 2.0f * ((float)_width) / window.Size.X;
        float height = 2.0f * ((float)_height) / window.Size.Y;

        float charX = character % 16;
        float charY = (256 - character) / 16;
        if (charX == 0) charY -= 1;

        _vertices = new float[]
        {
            x + width, y - height, 0.0f, (charX + 1) / 16, (charY + 0) / 16, // top right
            x + width, y         , 0.0f, (charX + 1) / 16, (charY + 1) / 16, // bottom right
            x        , y         , 0.0f, (charX + 0) / 16, (charY + 1) / 16, // bottom left 
            x        , y - height, 0.0f, (charX + 0) / 16, (charY + 0) / 16  // top left
        };

        int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "color");
        GL.Uniform4(vertexColorLocation, color.R, color.G, color.B, 1.0f);

        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.BindVertexArray(_vertexArrayObject);

        _shader.Use();
        _fonts.Use(TextureUnit.Texture0);

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

    }

    public static void DrawToScreen(GameWindow window, int _x, int _y, int _width, int _height, Color color)
    {

        float x = 2.0f * (((float)_x) / window.Size.X) - 1.0f;
        float y = 2.0f * (((float)-_y) / window.Size.Y) + 1.0f;
        float width = 2.0f * ((float)_width) / window.Size.X;
        float height = 2.0f * ((float)_height) / window.Size.Y;

        _vertices = new float[]
        {
            x + width, y - height, 0.0f, 1.0f, 0.0f, // top right
            x + width, y         , 0.0f, 1.0f, 1.0f, // bottom right
            x        , y         , 0.0f, 0.0f, 1.0f, // bottom left 
            x        , y - height, 0.0f, 0.0f, 0.0f  // top left
        };

        int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "color");
        GL.Uniform4(vertexColorLocation, color.R, color.G, color.B, 1.0f);

        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.BindVertexArray(_vertexArrayObject);

        _shader.Use();
        _texture.Use(TextureUnit.Texture0);

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

    }

    public static void Unload()
    {

        // Delete all the resources.
        GL.DeleteBuffer(_vertexBufferObject);
        GL.DeleteVertexArray(_vertexArrayObject);

        GL.DeleteProgram(_shader.Handle);

    }

}