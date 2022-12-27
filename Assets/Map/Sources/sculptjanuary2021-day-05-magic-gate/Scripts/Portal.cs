using UnityStandardAssets.Water;
using Map.Airplane.Scripts;
using UnityEngine;
using RenderSettings = UnityEngine.RenderSettings;

public class Portal : MonoBehaviour
{
    [SerializeField] private Water _water;
    [SerializeField] private Ship _ship;
    [SerializeField] private Material[] _skyboxes;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent(out Airplane airplane)) return;
        ChangeEnvironment();
    }

    private void ChangeEnvironment()
    {
        RenderSettings.skybox = RenderSettings.skybox == _skyboxes[0] ? _skyboxes[1] : _skyboxes[0];
        
        _water.gameObject.SetActive(!_water.isActiveAndEnabled);
        _ship.gameObject.SetActive(!_ship.isActiveAndEnabled);
    }
}