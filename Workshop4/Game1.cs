using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Workshop4
{
    public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D mytexture;
    private Vector2 spritePosition = Vector2.Zero;

    Texture2D cloud;

    Vector2[] scaleCloud;
    Vector2[] clodPos;
    int[] speedCloud;

    Random r = new Random();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        cloud = Content.Load<Texture2D>("Cloud_sprite");
        mytexture = Content.Load<Texture2D>("NatureSprite");

        clodPos = new Vector2[4];
        scaleCloud = new Vector2[4];
        speedCloud = new int[4];

        for (int i = 0; i < 4; i++)
        {
            clodPos[i].Y = r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloud.Height);
            scaleCloud[i].X = r.Next(1, 3);
            scaleCloud[i].Y = scaleCloud[i].X;
            speedCloud[i] = r.Next(5, 8);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        for (int i = 0; i < 4; i++)
        {
            clodPos[i].X += speedCloud[i];
            if (clodPos[i].X > _graphics.GraphicsDevice.Viewport.Width)
            {
                clodPos[i].X = 0;
                clodPos[i].Y = r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloud.Height);
                scaleCloud[i].X = r.Next(1, 3);
                scaleCloud[i].Y = scaleCloud[i].X;
            }

        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        for (int i = 0; i < 4; i++)
        {
            _spriteBatch.Draw(cloud, clodPos[i], null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);
        }
        spriteBatch.Draw(mytexture, new Vector2(0, 0), new Rectangle(256, 128,
                256, 256), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(320, 0), new Rectangle(0, 192,
                128, 128), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(576, 128), new Rectangle(0, 192,
                128, 128), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(320, 0), new Rectangle(0, 192,
                128, 128), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(576, 192), new Rectangle(256, 128,
                256, 256), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(64, 256), new Rectangle(192, 192,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(448, 384), new Rectangle(128, 64,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(384, 256), new Rectangle(128, 192,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(256, 384), new Rectangle(128, 192,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(448, 0), new Rectangle(128, 192,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(128, 256), new Rectangle(256, 0,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(256, 192), new Rectangle(192, 0,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(576, 0), new Rectangle(128, 256,
                128, 128), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(0, 384), new Rectangle(0, 0,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(64, 384), new Rectangle(128, 128,
                128, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(384, 192), new Rectangle(0, 128,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(192, 320), new Rectangle(128, 0,
                64, 64), Color.White);
        spriteBatch.Draw(mytexture, new Vector2(704, 128), new Rectangle(64, 0,
                64, 64), Color.White);

            _spriteBatch.End();

        base.Draw(gameTime);
    }
}
}
