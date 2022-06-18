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
    // sealed - ������������ (��������) �����, �� ���� �� ����� �������������
    {
        PlayerData SinglePlayerData = new PlayerData();

        private ISaveData _data;


        [Header("�����")]
        [SerializeField] Transform PlayerDot;


        private void Awake()
        {
            _transform = transform;
            /* �������� ������ �� transform (������� Player)
             ���� _transform = gameObject.transform;
             ���� _transform = GetComponent<Transform>();
             �� ���� � �� ��, �� ����� ����������� �������� 
             ���������� �� ������ ���� */

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
        /* �������������� (��������, ��������� �������� ����),
         ���� ����� ����������� ��� �����������,
         �� ����� override ����� ��� ��������� ��� ��������
         (��� � �����), ������ ����� ���������, ��� � �������� ������.
         ��� ����� ����� ���������� � InputController */
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3 (x, y, z) * Speed);
            }
            else
            {
                Debug.Log("NO Rigidbody!");
            }
            /* ������������ �� ������, ����� ������� */

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

