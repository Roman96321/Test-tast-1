using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    [SerializeField] private Vector2 ReferenceResolution = new Vector2(720, 1280);
    [SerializeField][Range(0,1)] private float MatchWidthOrHeight = 0.5f;

    private Camera _componentCamera;
    private float _targetAspect;
    private float _initialSize;
    private float _initialFov;
    private float _horizontalFov;

    private void Awake()
    {
        _componentCamera = GetComponent<Camera>();
        _initialSize = _componentCamera.orthographicSize;
        _targetAspect = ReferenceResolution.x / ReferenceResolution.y;
        _initialFov = _componentCamera.fieldOfView;
        _horizontalFov = CalcVerticalFov(_initialFov, 1 / _targetAspect);

        UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (_componentCamera.orthographic)
            _componentCamera.orthographicSize = _initialSize * (_targetAspect / _componentCamera.aspect);
        else
            _componentCamera.fieldOfView = CalcVerticalFov(_horizontalFov, _componentCamera.aspect);
    }

    private static float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }
}