using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ChargedProjectileEffectsHandler : MonoBehaviour
    {
        [Tooltip("Object that will be affected by charging scale & color changes")]
        public GameObject ChargingObject;

        [Tooltip("Scale of the charged object based on charge")]
        public MinMaxVector3 Scale;

        [Tooltip("Color of the charged object based on charge")]
        public MinMaxColor Color;

        MeshRenderer[] m_AffectedRenderers;

        void OnEnable()
        {
            m_AffectedRenderers = ChargingObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var ren in m_AffectedRenderers)
            {
                ren.sharedMaterial = Instantiate(ren.sharedMaterial);
            }
        }
        
    }
}