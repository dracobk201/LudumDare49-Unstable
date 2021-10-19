using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class ReactionController : MonoBehaviour
{
    [SerializeField] private BoolReference reactorIsGrowing = default(BoolReference);
    [SerializeField] private FloatReference reactionCooldownTime = default(FloatReference);
    [SerializeField] private FloatReference reactionGrowFactor = default(FloatReference);
    [SerializeField] private FloatReference reactionReduceGrowFactor = default(FloatReference);
    private bool isReactionGrowing;
    //private bool haveBirthCooldown;
    private bool leftHandPushing;
    private bool rightHandPushing;

    private void OnEnable()
    {
        isReactionGrowing = true;
        //haveBirthCooldown = true;
        transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
        //StartCoroutine(RemoveBirthCooldown());
    }

    private void Update()
    {
        if (isReactionGrowing)
        {
            float newX = transform.localScale.x + (transform.localScale.x * reactionGrowFactor.Value) * Time.deltaTime;
            transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            float newX = transform.localScale.x - (transform.localScale.x * reactionReduceGrowFactor.Value) * Time.deltaTime;
            if (leftHandPushing && rightHandPushing)
                newX = transform.localScale.x - (transform.localScale.x * reactionReduceGrowFactor.Value * 2) * Time.deltaTime;
            transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
        }

        if (transform.localScale.x > 0.6f && !reactorIsGrowing.Value)
            reactorIsGrowing.Value = true;
        else if (transform.localScale.x < 0.4f)
            DestroyReaction();
    }

    //private IEnumerator RemoveBirthCooldown()
    //{
    //    yield return new WaitForSeconds(reactionCooldownTime.Value);
    //    haveBirthCooldown = false;
    //}

    private void DestroyReaction()
    {
        transform.rotation = Quaternion.identity;
        reactorIsGrowing.Value = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (haveBirthCooldown) return;

        string targetTag = other.tag;
        if (targetTag.Equals(Global.HandTag))
        {
            isReactionGrowing = false;
            
            if (other.gameObject.name.Equals("Left"))
                leftHandPushing = true;
            if (other.gameObject.name.Equals("Right"))
                rightHandPushing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (haveBirthCooldown) return;

        string targetTag = other.tag;
        if (targetTag.Equals(Global.HandTag))
        {
            isReactionGrowing = true;

            if (other.gameObject.name.Equals("Left"))
                leftHandPushing = false;
            if (other.gameObject.name.Equals("Right"))
                rightHandPushing = false;
        }
    }
}
