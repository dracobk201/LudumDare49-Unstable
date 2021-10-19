using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField] private FloatReference initialReactorDamage = default(FloatReference);
    [SerializeField] private FloatReference reactorDamage = default(FloatReference);
    [SerializeField] private FloatReference reactorMaxDamage = default(FloatReference);
    [SerializeField] private FloatReference currentTime = default(FloatReference);
    [SerializeField] private Image reactorDamageGauge = default(Image);
    [SerializeField] private TextMeshProUGUI timeLabel = default(TextMeshProUGUI);
    [SerializeField] private TextMeshProUGUI reactorDamagePercentageLabel = default(TextMeshProUGUI);

    private float stepToSecond = 0;

    private void Update()
    {
        stepToSecond -= Time.deltaTime;
        if (stepToSecond <= 0)
        {
            UpdateDamageGauge();
            timeLabel.text = Global.ReturnTimeToString(currentTime.Value);
            stepToSecond = 0.5f;
        }
    }

    public void UpdateDamageGauge()
    {
        reactorDamageGauge.fillAmount = (float)reactorDamage.Value / (float)reactorMaxDamage.Value;
        float firstPart = reactorDamage.Value - initialReactorDamage.Value;
        float secondPart = -initialReactorDamage.Value + reactorMaxDamage.Value;
        float percentage = (firstPart / secondPart) * 100;
        reactorDamagePercentageLabel.text = $"{(int)percentage + 100}%";
    }
}
