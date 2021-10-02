using System.Collections;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ReactorController : MonoBehaviour
{
    [Header("Grown")]
    [SerializeField] private BoolReference isGrowing = default(BoolReference);
    [SerializeField] private FloatReference growFactor = default(FloatReference);
    [SerializeField] private FloatReference bounceAnimationFactor = default(FloatReference);
    [SerializeField] private FloatReference bounceAnimationTime = default(FloatReference);
    [SerializeField] private GameObject reactor = default(GameObject);

    [Header("Spawn")]
    [SerializeField] private FloatReference reactionSpawnTime = default(FloatReference);
    [SerializeField] private FloatReference reactionReduceTimeFactor = default(FloatReference);
    [SerializeField] private GameObjectCollection reactionCollection = default(GameObjectCollection);

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = reactor.transform.localScale;
        StartCoroutine(Grow());
        StartCoroutine(Spawn());
    }

    private IEnumerator Grow()
    {
        while (true)
        {
            if (!isGrowing.Value) yield return null;
            Vector3 scale = reactor.transform.localScale;
            scale = scale + (scale * growFactor.Value);
            Vector3 bouncyScale = scale - (scale * bounceAnimationFactor.Value);
            reactor.transform.localScale = scale;
            yield return new WaitForSeconds(bounceAnimationTime.Value);
            reactor.transform.localScale = bouncyScale;
            yield return new WaitForSeconds(bounceAnimationTime.Value);
            reactor.transform.localScale = scale;
        }
    }

    private IEnumerator Spawn()
    {
        float timeToWait = reactionSpawnTime.Value;
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            float angle = Random.Range(0,359);
            ShowReaction(Vector2.zero, angle);
            timeToWait = timeToWait - (timeToWait * reactionReduceTimeFactor.Value);
        }
    }

    public void ShowReaction(Vector2 initialPosition, float initialAngle)
    {
        for (int i = 0; i < reactionCollection.Count; i++)
        {
            if (!reactionCollection[i].activeInHierarchy)
            {
                reactionCollection[i].transform.localPosition = initialPosition;
                reactionCollection[i].transform.Rotate(Vector3.forward, initialAngle);
                reactionCollection[i].SetActive(true);
                break;
            }
        }
    }
}

