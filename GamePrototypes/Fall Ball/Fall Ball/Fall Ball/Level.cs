﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics.Contacts;

namespace Fall_Ball
{

    // base class for levels
    class Level
    {

        public Vector2 size;
        public World world;
        public Field gamefield;
        public Field addObjects;
        public GameObject ball1;
        public GameObject ball2;

        public Level(List<Texture2D> textures, SpriteBatch batch)
        {
            this.size = new Vector2(1, 1);
            this.world = new World(new Vector2(0.0f, 10.0f));
            this.gamefield = new Field();
            this.addObjects = new Field();
        }

        public virtual bool MyOnCollision(Fixture f1, Fixture f2, Contact contact)
        {
            return true;
        }

        public void addToMyOnCollision(GameObject gameObject)
        {
            foreach (Fixture fix in gameObject.body.FixtureList)
            {
                fix.OnCollision += MyOnCollision;
            }
        }

        public void removeFromMyOnCollision(GameObject gameObject)
        {
            foreach (Fixture fix in gameObject.body.FixtureList)
            {
                fix.OnCollision -= MyOnCollision;
            }
        }

    }
}