using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using SharpDX.MediaFoundation;

namespace spaceshhoter
{
    public class enemy
    {
        private Texture2D texture;
        private Microsoft.Xna.Framework.Vector2 position;
        private Microsoft.Xna.Framework.Rectangle hitbox;
        private float speed; 

        public Microsoft.Xna.Framework.Rectangle Hitbox{
            get{return hitbox;}
        }

        public enemy(Texture2D texture){
            this.texture = texture;
            Random rand = new Random(); 
            int size = rand.Next(10,50);
            speed = rand.NextFloat(5,100);
            position.X = rand.NextFloat(0,750);
            position.Y = -50;
            hitbox = new Microsoft.Xna.Framework.Rectangle((int)position.X,(int)position.Y,size,size);
        }


        public void update(){
            position.Y +=speed*1f/60f;

            hitbox.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture,hitbox,Microsoft.Xna.Framework.Color.Red);
    }
    }
}