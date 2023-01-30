using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [SerializeField] private List<GameObject> _possibleDrops;

    private GameObject GetRandomItem()
    {
        var randomPercentage = Random.Range(0, 100);
        List<GameObject> possibleDropsPercentageBased = new List<GameObject>();

        foreach (GameObject item in _possibleDrops)
        {
            var itemLootData = item.GetComponent<LootData>();   
            // check if item dropchance percentage is greater than randomPercentage
            if (itemLootData._dropChance >= randomPercentage)
            {
                possibleDropsPercentageBased.Add(item);
            }
        }

        if(possibleDropsPercentageBased.Count > 0)
        {
            GameObject item = possibleDropsPercentageBased[Random.Range(0, possibleDropsPercentageBased.Count)];
            return item;
        }
        Debug.Log("No item dropped");
        return null;
    }

    public void DropLoot()
    {
        GameObject LootItem = GetRandomItem();
        if(LootItem != null)
        {
            var instantiatedItem = Instantiate(LootItem, transform.position, Quaternion.identity);

            // Add some physics to the item when instantiated (You could also add Some particle effects, sounds, etc..)
            //float force = 300f;
            //Vector2 direction = new Vector2(Random.Range(1f, -1f), Random.Range(1f, -1f));
            //instantiatedItem.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
