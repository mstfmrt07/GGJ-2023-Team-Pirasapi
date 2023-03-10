using UnityEngine;
using Cinemachine;

namespace Pirasapi
{
 
    /// <summary>
    /// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
    /// </summary>
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class CinemachineLockAxis : CinemachineExtension
    {
        [Tooltip("Lock the camera's Z position to this value")]
        public float m_YPosition = 0;
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.y = m_YPosition;
                state.RawPosition = pos;
            }
        }
    }

}
