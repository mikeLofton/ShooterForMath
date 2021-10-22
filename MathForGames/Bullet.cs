using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private int _xDirection;
        private int _yDirection;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Bullet(char icon, float x, float y, float speed, int bulletXDirection, int bulletYDirection, Color color, string name = "Bullet") :
            base(icon, x, y, color, name)
        {
            _speed = speed;
            _xDirection = bulletXDirection;
            _yDirection = bulletYDirection;
        }

        public override void Update(float deltaTime)
        {
            Vector2 moveDirection = new Vector2(_xDirection, _yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Position += Velocity;

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            
        }
    }
}
