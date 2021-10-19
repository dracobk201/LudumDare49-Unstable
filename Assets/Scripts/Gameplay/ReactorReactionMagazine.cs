using UnityEngine;
using ScriptableObjectArchitecture;

public class ReactorReactionMagazine : MonoBehaviour
{
    [SerializeField] private GameObjectCollection reactionCollection = default(GameObjectCollection);
    [SerializeField] private IntReference reactionsPool = default(IntReference);
    [SerializeField] private GameObject reactionPrefab = default(GameObject);

    private void Awake()
    {
        reactionCollection.Clear();
        InstantiateReactions();
    }

    private void InstantiateReactions()
    {
        for (int i = 0; i < reactionsPool.Value; i++)
        {
            GameObject reaction = Instantiate(reactionPrefab) as GameObject;
            reaction.GetComponent<Transform>().SetParent(transform);
            reactionCollection.Add(reaction);
            reaction.SetActive(false);
        }
    }
}
