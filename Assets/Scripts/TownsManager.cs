using System.Linq;
using UnityEngine;


public class TownsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] NotDestroyedTowns;

    public int NotDestroyedTownsCounter
    {
        get
        {
            return NotDestroyedTowns.Length;
        }
    }

    [SerializeField] private GameObject destroyedTownPrefab;

    public GameObject GetRandomNotDestroyedTown()
    {
        return NotDestroyedTowns[Random.Range(0, NotDestroyedTowns.Length)];
    }

    public void OnRocketReachedTown(object sender, GameObject townHitByRocket)
    {
        Instantiate(destroyedTownPrefab, townHitByRocket.transform.position, townHitByRocket.transform.rotation);
        NotDestroyedTowns = NotDestroyedTowns.Where(t => t.transform != townHitByRocket.transform).ToArray();

        Destroy(townHitByRocket);
    }
}
