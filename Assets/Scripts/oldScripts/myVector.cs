using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector
{
    private float temp1;
    private float temp2;

    // ����������� ������
    public MyVector(float x)
    {
        Temp1 = x;
    }

    // ������������ ������
    //public float Temp1 { get => temp1; set => temp1 = value; }
    // =>

    public float Temp1
    {
        get
        {
            return temp1;
        }
        set 
        {
            if (value > 0)
            {
                temp1 = value;
            }
            else
            {
                Debug.Log("������������ ��������!");
            }
        }
    }

    public float Temp2 { get => temp2; set => temp2 = value; }

    // �������� ����� ���� ����� ��� ����������, ��� ����
    // ����� ����������� �������� �������� ������ � temp1 (������� private )

    public void Test()
    {
        Debug.Log("MyVector");
        Debug.Log(Temp1);
    }
}
