using UnityEngine;

public interface ICameraController
{
    void StartDrawShootLine(Vector3 position);
    void StopShootDrawLine();

    Vector3 ToWorldCoordinates(Vector3 position);
}