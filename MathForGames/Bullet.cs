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
        private Scene _scene;

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

        public Bullet(float x, float y, float speed, int bulletXDirection, int bulletYDirection, Scene currentScene, string name = "Bullet", string path = "") :
            base(x, y, name, path)
        {
            _speed = speed;
            _xDirection = bulletXDirection;
            _yDirection = bulletYDirection;
            _scene = currentScene;
        }

        public override void Update(float deltaTime)
        {
            Vector2 moveDirection = new Vector2(_xDirection, _yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Position += Velocity;

            //float distance = Vector2.Distance()

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
                _scene.RemoveActor(actor);
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
