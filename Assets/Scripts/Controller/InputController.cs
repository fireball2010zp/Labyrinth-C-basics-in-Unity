using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    /* ������ ����� �� ������ � Unity */
    {
        private readonly Unit _player;
        // ����� ������ �� �������� ������

        private float horizontal;
        private float vertical;
        // ���

        public InputController(Unit player)
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
        }
    }
}

