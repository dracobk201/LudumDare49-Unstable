using ScriptableObjectArchitecture;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver = default(BoolReference);
    [SerializeField] private BoolReference isGameStarted = default(BoolReference);
    [SerializeField] private FloatReference currentTime = default(FloatReference);

    private void Awake()
    {
        currentTime.Value = 0;
    }

    private void Update()
    {
        if (!isGameOver.Value && isGameStarted.Value)
            currentTime.Value += Time.deltaTime;
    }
}
