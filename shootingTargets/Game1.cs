using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace shootingTargets
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D target_Sprite;
        Texture2D crosshair_Sprite;
        Texture2D background_Spirte;

        SpriteFont gameFont;

        Vector2 targetPosition = new Vector2(0,0);
        Vector2 mousePosition;
        float mouseTargetDist;

        const int TARGET_RADIUS = 45;

        MouseState mState;
        bool mReleased = true;



        int score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            target_Sprite = Content.Load<Texture2D>("target");
            crosshair_Sprite = Content.Load<Texture2D>("crosshairs");
            background_Spirte = Content.Load<Texture2D>("sky");

            gameFont = Content.Load<SpriteFont>("galleryFont");


        }




        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mousePosition = new Vector2(mState.X, mState.Y);

            mouseTargetDist = Vector2.Distance(targetPosition, mousePosition);
            ClickingMouse();

            base.Update(gameTime);
        }

        private void ClickingMouse()
        {
            mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                if (mouseTargetDist < TARGET_RADIUS)
                {
                    score++;
                }
                mReleased = false;

            }
            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }
        }
      
            



      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            spriteBatch.Draw( background_Spirte, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(gameFont, $"Score: {score}", new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(gameFont, $"Mouse {mousePosition}", new Vector2(20, 20), Color.White);
            spriteBatch.Draw(target_Sprite, new Vector2( targetPosition.X - TARGET_RADIUS, targetPosition.Y - TARGET_RADIUS), Color.White);
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //private bool MouseOnTarger()
        //{

            
           

            
        //}
    }
}
