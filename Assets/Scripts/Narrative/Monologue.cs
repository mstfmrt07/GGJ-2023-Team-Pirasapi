using System.Collections.Generic;
using UnityEngine;

namespace Pirasapi
{
    [CreateAssetMenu(fileName = "New Monologue", menuName = "Narrative/Monologue", order = 0)]
    public class Monologue : ScriptableObject
    {
        public new string name;
        public Sprite graphics;
        [TextArea(3, 10)] public List<string> speeches;
    }
}