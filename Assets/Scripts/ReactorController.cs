using System.Collections;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ReactorController : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver = default(BoolReference);
    [Header("Grown")]
    [SerializeField] private BoolReference isGrowing = default(BoolReference);
    [SerializeField] private FloatReference growFactor = default(FloatReference);
    [SerializeField] private FloatReference reduceGrowFactor = default(FloatReference);
    [SerializeField] private FloatReference bounceAnimationFactor = default(FloatReference);
    [SerializeField] private FloatReference bounceAnimationTime = default(FloatReference);
    [SerializeField] private GameObject reactor = default(GameObject);

    [Header("Spawn")]
    [SerializeField] private FloatReference reactionSpawnTime = default(FloatReference);
    [SerializeField] private FloatReference reactionReduceTimeFactor = default(FloatReference);
    [SerializeField] private GameObjectCollection reactionCollection = default(GameObjectCollection);

    private float timeToWait;
    private Vector3 originalScale;

    private void Awake()
    {
        isGrowing.Value = false;
    }

    private void Start()
    {
        originalScale = reactor.transform.localScale;
        StartCoroutine(Grow());
        StartCoroutine(Spawn());
    }

    private IEnumerator Grow()
    {
        while (!isGameOver.Value)
        {
            if (isGrowing.Value)
            {
                Vector3 scale = reactor.transform.localScale;
                scale = scale + (scale * growFactor.Value);
                Vector3 bouncyScale = scale - (scale * bounceAnimationFactor.Value);
                reactor.transform.localScale = scale;
                yield return new WaitForSeconds(bounceAnimationTime.Value);
                reactor.transform.localScale = bouncyScale;
                yield return new WaitForSeconds(bounceAnimationTime.Value);
                reactor.transform.localScale = scale;
            }
            else
            {
                Vector3 scale = reactor.transform.localScale;
                scale = scale - (scale * reduceGrowFactor.Value);
                if (scale.x <= originalScale.x && scale.y <= originalScale.y && scale.z <= originalScale.z)
                {
                    scale = originalScale;
                    Debug.Log("Es el original");
                }
                Vector3 bouncyScale = scale + (scale * bounceAnimationFactor.Value);
                reactor.transform.localScale = scale;
                yield return new WaitForSeconds(bounceAnimationTime.Value);
                reactor.transform.localScale = bouncyScale;
                yield return new WaitForSeconds(bounceAnimationTime.Value);
                reactor.transform.localScale = scale;
            }
        }
    }

    private IEnumerator Spawn()
    {
        timeToWait = reactionSpawnTime.Value;
        while (!isGameOver.Value)
        {
            yield return new WaitForSeconds(timeToWait);
            float angle = Random.Range(0,359);
            ShowReaction(Vector2.zero, angle);
            timeToWait = timeToWait - (timeToWait * reactionReduceTimeFactor.Value);
            if (timeToWait <= 0.5f)
                timeToWait = 1;
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

