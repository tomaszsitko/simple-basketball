using UnityEngine;

public interface ICameraController
{
    void StartDrawShootLine();
    void StopShootDrawLine();

    Vector3 ToWorldCoordinates(Vector3 position);
}