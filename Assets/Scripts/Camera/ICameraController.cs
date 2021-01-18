using UnityEngine;

namespace SimpleBasketball.Camera
{
    public interface ICameraController
    {
        void StartDrawShootLine(Vector3 position);
        void StopShootDrawLine();

        Vector3 ToWorldCoordinates(Vector3 position);
    }
}