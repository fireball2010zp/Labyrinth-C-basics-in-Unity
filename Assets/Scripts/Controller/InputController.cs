using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    /* ������ ����� �� ������ � Unity */
    {
        private PlayerController _player;
        // ����� ������ �� �������� ������

        private float horizontal;
        private float vertical;
        // ���

        public InputController(PlayerController player)
        // ����������� � ������� �� Unit, ������������� � ����
        {
            _player = player;
        }

        public void Update()
        // Update - ��� ���������� �� MonoBehaviour, �� ������!
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            // ���������� ��� �� ������ Input

            _player.Move(horizontal, 0f, vertical);
            /* ��������� ����� ����������� ������
               ����� ����������� ����� ����������� ���,
               ����� ��� ���������� ������ ������ ���������� */


            if (Input.GetKeyDown(KeyCode.Q))
            {
                _player.SavePlayer();
            }

        }
    }
}

