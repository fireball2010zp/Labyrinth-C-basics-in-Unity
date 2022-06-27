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
        /* �������������� (��������, ��������� �������� ����),
         ���� ����� ����������� ��� �����������,
         �� ����� override ����� ��� ��������� ��� ��������
         (��� � �����), ������ ����� ���������, ��� � �������� ������.
         ��� ����� ����� ���������� � InputController */
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }
            /* ������������ �� ������, ����� ������� */

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

