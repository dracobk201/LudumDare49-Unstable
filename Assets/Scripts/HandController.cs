using ScriptableObjectArchitecture;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Vector2Reference leftStickAxis = default(Vector2Reference);
    [SerializeField] private Vector2Reference rightStickAxis = default(Vector2Reference);
    [SerializeField] private GameObject leftHand = default(GameObject);
    [SerializeField] private GameObject rightHand = default(GameObject);

    public void MoveLeftHand()
    {
        var angle = Mathf.Atan2(-leftStickAxis.Value.y, -leftStickAxis.Value.x) * Mathf.Rad2Deg;
        leftHand.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void MoveRightHand()
    {
        var angle = Mathf.Atan2(-rightStickAxis.Value.x, -rightStickAxis.Value.y) * Mathf.Rad2Deg;
        rightHand.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
