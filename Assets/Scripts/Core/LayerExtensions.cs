using UnityEngine;
namespace Pirasapi
{

    public static class LayerExtensions
    {
        public static bool Contains(this LayerMask mask, int layer)
        {
            return (mask.value & 1 << layer) > 0;
        }
    }
}