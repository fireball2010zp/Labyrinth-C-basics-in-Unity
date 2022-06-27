using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maze
{

    public class PlayerController : ViewPlayer
    {

        private ViewPlayer _playerDot;
        private PlayerData _singlePlayerData;

        private ISaveData _data;

        public PlayerController(ViewPlayer playerDot, PlayerData singlePlayerData)
        {
            _playerDot = playerDot;
            _singlePlayerData = singlePlayerData;
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
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }
            /* перемещаемся по физике, через импульс */

            _playerDot.transform.position = new Vector3(transform.position.x, _playerDot.transform.position.y, transform.position.z);

            _singlePlayerData.PlayerPosition = _transform.position;
        }

        public override void SavePlayer()
        {
            _data.SaveData(_singlePlayerData);
            PlayerData NewPlayer = _data.Load();

            Debug.Log(NewPlayer.PlayerName);
            Debug.Log(NewPlayer.PlayerPosition);
            Debug.Log(NewPlayer.PlayerHealth);
        }


    }
}

