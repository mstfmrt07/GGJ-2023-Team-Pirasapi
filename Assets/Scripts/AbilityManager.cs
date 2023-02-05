using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pirasapi
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] SliceAbility sliceAbility;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (InputController.Instance.SliceAbilityInput)
            {
                sliceAbility.Perform();
            }
            
        }
    }
}
