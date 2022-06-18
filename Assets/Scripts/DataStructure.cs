using System;
using UnityEngine;

namespace Maze
{
    [Serializable]
    public struct SVect3
    {
        public float X;
        public float Y;
        public float Z;

        public SVect3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // метод преобразования типов (из Vector3 в SVect3) 
        public static implicit operator SVect3(Vector3 val)
        {
            return new SVect3(val.x, val.y, val.z);
        }

        // метод преобразования типов (из SVect3 в Vector3)
        public static implicit operator Vector3(SVect3 val)
        {
            return new Vector3(val.X, val.Y, val.Z);
        }

    }


    [Serializable]
    public struct SQuater
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public SQuater(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        // метод преобразования типов (из Quaternion в SQuater) 
        public static implicit operator SQuater(Quaternion val)
        {
            return new SQuater(val.x, val.y, val.z, val.w);
        }

        // метод преобразования типов (из Svect3 в (Quaternion)
        public static implicit operator Quaternion(SQuater val)
        {
            return new Quaternion(val.X, val.Y, val.Z, val.W);
        }

    }

    [Serializable]
    public struct SObject
    {
        public string Name;
        public SVect3 Position;
        public SQuater Rotation;
        public SVect3 Scale;
    }
}
