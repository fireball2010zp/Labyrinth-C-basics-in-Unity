using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public struct PlayerData
    {
        public string PlayerName;
        public int PlayerHealth;
        public bool PlayerDead;
        public SVect3 PlayerPosition;
    }

    public sealed class Player : Unit
    // sealed - запечатанный (конечный) класс, от него не можем наследоваться
    {
        PlayerData SinglePlayerData = new PlayerData();

        private ISaveData _data;


        [Header("Метки")]
        [SerializeField] Transform PlayerDot;


        private void Awake()
        {
            _transform = transform;
            /* вызываем ссылку на transform (объекта Player)
             либо _transform = gameObject.transform;
             либо _transform = GetComponent<Transform>();
             всё одно и то же, но более нагруженные варианты 
             определяем до начала игры */

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }
            
            isDead = false;
            Health = 100;

            SinglePlayerData.PlayerHealth = Health;
            SinglePlayerData.PlayerDead = isDead;
            SinglePlayerData.PlayerName = gameObject.name;

            // _data = new JSONData();

            // _data = new StreamData();

            _data = new XMLData();
        }

        public override void Move(float x, float y, float z)
        /* переопределили (заглушка, реализуем контракт кода),
         если метод абстрактный или виртуальный,
         то через override можем его расширить или изменить
         (уже с телом), должен иметь сигнатуру, как у базового метода.
         сам метод будет вызываться в InputController */
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3 (x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }
            /* перемещаемся по физике, через импульс */

            PlayerDot.position = new Vector3(transform.position.x, PlayerDot.position.y, transform.position.z);

            SinglePlayerData.PlayerPosition = _transform.position;
        }

        public override void SavePlayer()
        {
            _data.SaveData(SinglePlayerData);
            PlayerData NewPlayer = _data.Load();

            Debug.Log(NewPlayer.PlayerName);
            Debug.Log(NewPlayer.PlayerPosition);
            Debug.Log(NewPlayer.PlayerHealth);
        }

    }
}

