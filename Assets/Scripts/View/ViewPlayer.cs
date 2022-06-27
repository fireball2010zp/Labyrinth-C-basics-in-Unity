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

    public abstract class ViewPlayer : MonoBehaviour
    {

        [SerializeField] public Rigidbody _rb;
        public Transform _transform;

        public static float Speed = 5;
        public static int Health = 100;
        public static bool isDead;

        [Header("�����")]
        [SerializeField] Transform PlayerDot;

        private ISaveData _data;

        PlayerData SinglePlayerData = new PlayerData();

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

        public abstract void Move(float x, float y, float z);
        /* ����������� ����� ��� ����, ���������������� � �����������
         � ����������� ������, �� ��������� � ������������� virtual,
         ������� ������ �������� ����� */

        public abstract void SavePlayer();

    }
}


