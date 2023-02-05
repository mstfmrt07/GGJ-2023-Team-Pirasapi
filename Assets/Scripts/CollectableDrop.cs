using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pirasapi
{
    public class CollectableDrop : ExecuteOnCollision, Interactable
    {
        public float size;
        
        protected override void HandleCollisionEnter(Collider2D collider)
        {
            Debug.Log("Interact");
            Interact();
        }

        protected override void HandleCollisionExit(Collider2D collider)
        {
        }

        public void Interact()
        {
            Player.Instance.CollectDrop(this);
            Destroy(gameObject);
        }
    }
}
