using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAllBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset inpuntActions;

    public void ResetBindings() {
        foreach (InputActionMap map in inpuntActions.actionMaps) {
            map.RemoveAllBindingOverrides();
        }
    }
}