using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace spaceshhoter
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        private KeyboardState kState;

        public Player(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,
            pixelSize,pixelSize);

        }
    public void Update(){
        kState = Keyboard.GetState();
       Move();
       shoot();
    }


    private void shoot(){
        
        if(kState.IsKeyDown(Keys.Space)){
            bullet bullet = new bullet();
        }
    }
    private void Move(){
    

        if(kState.IsKeyDown(Keys.A)){
            position.X -= 1;
        }
        else if(kState.IsKeyDown(Keys.D)){
            position.X +=1;
        }
        hitbox.Location = position.ToPoint();
    }



    public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture,hitbox,Color.White);
    }
    }
}


