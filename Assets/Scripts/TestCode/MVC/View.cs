using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class View : MonoBehaviour
    {
        // ������ ���������� ����� ����
        [SerializeField] public Transform _transform; // ����������� � ������������
        [SerializeField] public Collider _collider; // ��� �������������� �� �����
        [SerializeField] public Rigidbody _rb; // ���������� ����

        /* �.�. ����� ������� ����� ���� ������ ����, ������� ���������� ���������� 
        ����� ����� ������� Action, �.�. ������������� ��������� ���� Action � 3-�� 
        ����������� � ������������ (������ � ������, ����� OnLevelObjectContact ���
        �����)        
         */
        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }

        /* ����� ����� �� ����� ���������� ��������, ����� ������������� �� ����� 
        (������ ������������� � ������������ ���������) ���� ������� � ������� 
        ����� OnTriggerEnter */
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name); // ������ ��� �������
            Collider LevelObject = other; // ��������� ������

            /* ����� �������� ������� OnLevelObjectContact, � ������� ������� 
            ��������� (other), �����-�� ����� � ��������� ���������� */
            OnLevelObjectContact?.Invoke(LevelObject, 12, LevelObject.transform);       
        }

    }
}


/*
������ ����������� ������ �������� (3 ��) � ������������ �� ��� ������� �� ����� 
(Player � Trigger, ����� �������� ����� (������ Ground)).

������ � ���������� Unity ����������� � ������ ��� ������� ������� (Player � Trigger
- � ������� ���� Transform, Collider � Rigidbody (������ � Player)).

 */

