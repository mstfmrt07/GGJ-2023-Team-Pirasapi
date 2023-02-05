using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pirasapi
{
    public class RecycleBin : MonoSingleton<RecycleBin>
    {
        [Header("References")]
        public Transform container;

        public void DisposeAll()
        {
            //Dispose everything in the recycle bin.
            var disposables = FindObjectsOfType<MonoBehaviour>(true).OfType<IDisposable>();
            foreach (var disposable in disposables)
                disposable.Dispose();

            //Reset all resettables.
            var resettables = FindObjectsOfType<MonoBehaviour>(true).OfType<IResettable>();
            foreach (var resettable in resettables)
                resettable.ApplyReset();
        }
    }
}
