using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public sealed class Player : Unit
    // sealed - запечатанный (конечный) класс, от него не можем наследоваться
    {

        private void Awake()
        {
            _transform = transform;
            // либо _transform = gameObject.transform;
            // либо _transform = GetComponent<Transform>();
            // всё одно и то же, определяем до начала игры

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            
            isDead = false;
            Health = 100;
        }

        public override void Move(float x, float y, float z)
        // переопределили (заглушка, контракт кода), если метод аьстрактный или виртуальный,
        // то через override можем его расширить или изменить
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3 (x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }

        }

    }
}

