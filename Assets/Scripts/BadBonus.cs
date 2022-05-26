using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotation
    {

        private float heightFly;
        public float speedRotation;
        // переменные для движения

        private void Awake()
        {
            heightFly = Random.Range(1f, 5f);
            speedRotation = Random.Range(13f, 40f);
            // задали значения высоты полёта и скорости вращения
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly), _transform.position.z); 
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up*(Time.deltaTime*speedRotation), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {

        }
    }
}

