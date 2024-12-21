using System;
using UnityEngine;

namespace AI
{
    public class AIPawn : MonoBehaviour
    {


        [SerializeField]
        private float moveSpeed  = 1;
        
        private Vector2 Destination { set; get; }


        private void Awake()
        {
            Destination = transform.position;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            float dis = Vector2.Distance(position, Destination);
            if (dis > 0.05f)
            {
                Vector3 dir = (Destination - new Vector2(position.x,position.y)).normalized;
                position += dir * moveSpeed * Time.deltaTime;
                transform.position = position;
            }
        }

        public void SetDestination(Vector2 dest)
        {
            Destination = dest;
        }
    }
}