using System;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pirasapi
{
    public class WaterDrop : MonoBehaviour
    {
        [SerializeField] private Vector3 _size;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb2D;
        [SerializeField] private Collider2D _collider2D;

        public Vector3 Size => _size;
        public float Speed => _speed;
        public Rigidbody2D Rb2D => _rb2D;
        public Collider2D Collider2D => _collider2D;

        private void Start()
        {
            _size = transform.localScale;
            _speed = Random.Range(3, 6);
        }
    }
}