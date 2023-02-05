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
        private MergeAbility _mergeAbility;

        public void Perform()
        {
            WaterDrop waterDrop;
            sliceCount = Random.Range(3, 6);
            for (int i = 0; i < sliceCount; i++)
            {
                originalWaterDrop.transform.localScale /= sliceCount;
                if (originalWaterDrop.transform.localScale.x <= 0.3)
                {
                    originalWaterDrop.transform.localScale = Vector3.one * 0.3f;
                    waterDrop = Instantiate(dropPrefab, parentTransform);
                    waterDrop.transform.position = new Vector3(originalWaterDrop.transform.position.x + Random.Range(-1, 1),originalWaterDrop.transform.position.y, 1);
                    waterDrop.transform.localScale = originalWaterDrop.transform.localScale;
                    _mergeAbility.waterDrops.Add(waterDrop);
                }
                else
                {
                    waterDrop = Instantiate(dropPrefab, parentTransform);
                    waterDrop.transform.position = new Vector3(originalWaterDrop.transform.position.x + Random.Range(-1, 1),originalWaterDrop.transform.position.y, 1);
                    waterDrop.transform.localScale = originalWaterDrop.transform.localScale;
                    _mergeAbility.waterDrops.Add(waterDrop);
                }
                
            }
        }
    }
}
