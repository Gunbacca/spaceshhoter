using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spaceshhoter;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D BB;
    private Texture2D bakgrundsBild;
    private Player player;
    private Texture2D spaceShip;
    private List<enemy> enemies = new List<enemy>();
    private int liv=3;
    SoundEffect effect;
    Song theme;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        spaceShip = Content.Load<Texture2D>("spacespp");

        effect = Content.Load<SoundEffect>("shoot");
        bakgrundsBild = Content.Load<Texture2D>("istockphoto-1401387054-612x612");

        player = new Player(spaceShip,new Vector2(380,350),50, effect);

        enemies.Add(new enemy(spaceShip));
        theme = Content.Load<Song>("back-music");
        MediaPlayer.Play(theme);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        
        player.Update();
        foreach(enemy enemy in enemies){
            enemy.update();
        }
        EnemyBulletCollision();
        spawnenemy();
        playerdie();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        Rectangle bgRect = new(0,0, 800, 600);
        _spriteBatch.Draw(bakgrundsBild, bgRect, Color.White);
        player.Draw(_spriteBatch);
        foreach(enemy enemy in enemies)
        enemy.Draw(_spriteBatch);
        _spriteBatch.End();



        base.Draw(gameTime);
    }
    private void spawnenemy(){
        Random rand = new Random();
        int value = rand.Next(1,101);
        int spawnChancePercent = 5;
        if(value<=spawnChancePercent)
        enemies.Add(new enemy(spaceShip));
    }
    private void EnemyBulletCollision(){
        for(int i =0; i< enemies.Count;i++){
            for(int j=0;j<player.Bullets.Count;j++){
                if(enemies[i].Hitbox.Intersects(player.Bullets[j].Hitbox)){
                    enemies.RemoveAt(i);
                    player.Bullets.RemoveAt(j);
                    j--;
                }
            }
        }
    }
    private void playerdie(){
        for(int i =0; i< enemies.Count;i++){
            if(enemies[i].Hitbox.Intersects(player.Hitbox)){
                liv--;
                enemies.RemoveAt(i);
                if(liv <= 0){
                    Exit();
                }
                i--;

            }
        }
    }
}
