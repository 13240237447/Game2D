using System;
using UnityEngine;

namespace Manager
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField]
        private Material unitOutLineMat;

        private void Awake()
        {
            Game.Res = this;
        }

        public Material GetOutLineShader(Unit unit)
        {
            return unitOutLineMat;
        }
    }
}