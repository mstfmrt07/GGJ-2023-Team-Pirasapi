using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Pirasapi
{
    public class SliceAbility : MonoBehaviour, IAbility
    {
        public Player player;
        public int sliceCount;
        public float dropCount;
        public Vector3 scale;
        public WaterDrop dropPrefab;
        public Transform parentTransform;
        public GameObject originalWaterDrop;

        // Update is called once per frame
        void Update()
        {
            if (InputController.Instance.SliceAbilityInput)
            {
                Perform();
            }
            
        }
        
        public void Perform()
        {
            WaterDrop waterDrop;
            sliceCount = Random.Range(3, 6);
            for (int i = 0; i < sliceCount; i++)
            {
                Player.Instance.SlicePlayer();
                originalWaterDrop.transform.localScale /= sliceCount;
                if (originalWaterDrop.transform.localScale.x <= 0.8)
                {
                    originalWaterDrop.transform.localScale = Vector3.one * 0.8f;
                    waterDrop = Instantiate(dropPrefab, parentTransform);
                    waterDrop.transform.position = new Vector3(originalWaterDrop.transform.position.x + Random.Range(-1, 1),originalWaterDrop.transform.position.y, 1);
                    waterDrop.transform.localScale = originalWaterDrop.transform.localScale;
                }
                else
                {
                    waterDrop = Instantiate(dropPrefab, parentTransform);
                    waterDrop.transform.position = new Vector3(originalWaterDrop.transform.position.x + Random.Range(-1, 1),originalWaterDrop.transform.position.y, 1);
                    waterDrop.transform.localScale = originalWaterDrop.transform.localScale;
                }
                
            }
        }
    }
}
