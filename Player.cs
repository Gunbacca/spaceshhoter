using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace spaceshhoter
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;

        public Player(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,
            pixelSize,pixelSize);

        }
    public void Update(){
       Move();
    }

    private void Move(){
         KeyboardState kState =Keyboard.GetState();

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


