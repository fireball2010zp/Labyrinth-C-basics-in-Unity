using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public sealed class Player : Unit
    // sealed - запечатанный (конечный) класс, от него не можем наследоватьс€
    {

        private void Awake()
        {
            _transform = transform;
            /* вызываем ссылку на transform (объекта Player)
             либо _transform = gameObject.transform;
             либо _transform = GetComponent<Transform>();
             всЄ одно и то же, но более нагруженные варианты 
             определ€ем до начала игры */

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            
            isDead = false;
            Health = 100;
        }

        public override void Move(float x, float y, float z)
        /* переопределили (заглушка, реализуем контракт кода),
         если метод абстрактный или виртуальный,
         то через override можем его расширить или изменить
         (уже с телом), должен иметь сигнатуру, как у базового метода.
         сам метод будет вызыватьс€ в InputController */
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3 (x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }
        /* перемещаемс€ по физике, через импульс */
        }



    }
}

