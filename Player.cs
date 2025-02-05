using System.Collections.Generic;
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
        private List<bullet> bullets = new List<bullet>();

        public List<bullet> Bullets{
            get{return bullets;}
        }

        public Player(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,
            pixelSize,pixelSize);

        }
    public void Update(){
        kState = Keyboard.GetState();
       Move();
       Shoot();

       foreach(bullet b in bullets){
        b.Update();
       }
    }


    private void Shoot(){
        
        if(kState.IsKeyDown(Keys.Space)){
            bullet bullet = new bullet(texture,position);
            bullets.Add(bullet);
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
        foreach(bullet b in bullets){
            b.Draw(spriteBatch);
        }
    }
    }
    
}


