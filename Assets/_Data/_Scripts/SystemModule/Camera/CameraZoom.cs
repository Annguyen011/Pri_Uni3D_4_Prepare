using Cinemachine;
using System;
using UnityEngine;

namespace Gyu_
{

    public class CameraZoom : MonoBehaviour
    {
        #region [Elements]

        [Header("# Settings")]
        [SerializeField, Range(1, 6)] private float defaultDistance = 6f;
        [SerializeField, Range(1, 6)] private float minDistance = 6f;
        [SerializeField, Range(1, 6)] private float maxDistance = 6f;
        private float currentTargetDistance;

        [Header("# Mouse data")]
        [SerializeField] private float smoothing = 4f;
        [SerializeField] private float zoomSensitivity = 1f;

        private CinemachineFramingTransposer framing;
        private CinemachineInputProvider inputProvider;

        #endregion

        #region [Unity Methods]

        private void Awake()
        {
            framing = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();
        }

        private void Start()
        {
            currentTargetDistance = defaultDistance;
        }

        private void Update()
        {
            Zoom();
        }

        #endregion

        private void Zoom()
        {
            currentTargetDistance = Mathf.Clamp(currentTargetDistance + 
                inputProvider.GetAxisValue(2) * zoomSensitivity, minDistance, maxDistance);

            if(framing.m_CameraDistance.Equals(currentTargetDistance))
                return;

            framing.m_CameraDistance = Mathf.Lerp(framing.m_CameraDistance, 
                currentTargetDistance, smoothing * Time.deltaTime);
        }
    }
}
