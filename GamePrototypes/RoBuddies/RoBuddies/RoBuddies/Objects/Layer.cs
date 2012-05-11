﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robuddies.Objects
{

    class Layer
    {
        #region Fields and Properties

        public List<GameObject> objects;
        public void add(GameObject obj) { objects.Add(obj); }
        public void remove(GameObject obj) { objects.Remove(obj); }

        Game game;

        float scrollSpeed;
        float layerDepth;

        /// <summary>
        /// Depth or Z-Coord of this Layer 
        /// float  in [0.0 .. 1.0]
        /// 1.0 == far away
        /// 0.5 == mainLayer where bud, budi and bro live
        /// 0.0 == in front of mainLayer
        /// </summary>
        public float Depth
        {
            get { return layerDepth; }
            set { 
                layerDepth = value;
                scrollSpeed = (float)( 256.0d / Math.Pow(value*32.0d, 2.0d) );
            }
        }

        float offset;
        public float Offset
        {
            get { return offset; }
            set { offset = value * scrollSpeed; }
        }

        private SpriteBatch spriteBatch;

        Rectangle titleSafe;
        public Rectangle TitleSafe
        {
            get { return titleSafe; }
            set { titleSafe = value; }
        }

        #endregion

        #region Construction and Initialization

        public Layer(Game game)
        {
            objects = new List<GameObject>();
            this.game = game;
        }

        public void LoadContent()
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }


        public void UnloadContent() { objects.Clear();  }

        #endregion

        #region Update

        public void Update(GameTime gameTime) { }

        #endregion

        #region Rendering

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Rectangle dest = new Rectangle();
            foreach (GameObject obj in objects)
            {
                float xPos = (float)titleSafe.Width / 2.0f + obj.Position.X - offset;
                dest.X = (int)(xPos); dest.Y = (int)((float)titleSafe.Height - (obj.Position.Y + 20));
                dest.Width = (int)obj.Width; dest.Height = (int)obj.Height;
                spriteBatch.Draw(obj.Texture, dest, null, obj.Color, obj.Rotation, obj.Origin, SpriteEffects.None, layerDepth);
            }

        }

        #endregion
    }
}