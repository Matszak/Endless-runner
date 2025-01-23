using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] private int seed;
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private GameObject lastTile;
    [SerializeField] private float tileOffset;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 rotation;
    private void Start()
    {
        Random.InitState(seed);
        Instantiate(tiles[0], Vector3.zero, tiles[0].transform.rotation);
        lastTile = Instantiate(tiles[0], Vector3.forward * tileOffset, tiles[0].transform.rotation);
        direction = -lastTile.transform.right;
        rotation = lastTile.transform.eulerAngles;
        StartCoroutine(DEBUG_Generate());
    }

    public void GenerateNewTile()
    {
        int tileNum = Random.Range(0, 10);
        switch (tileNum)
        {
            case 1:
            case 2:
                lastTile = SpawnTile(tileNum);

                direction = tileNum == 1 ? lastTile.transform.forward : -lastTile.transform.forward;
                rotation.y += tileNum == 1 ? 90f : -90f;
                break;
            default:
                lastTile = SpawnTile(0);

                direction = -lastTile.transform.right;
                break;
        }
    }

    private GameObject SpawnTile(int num)
    {
        GameObject newTile = Instantiate(tiles[num]);

        newTile.transform.position = lastTile.transform.position + (direction * tileOffset);
        newTile.transform.eulerAngles = rotation;

        return newTile;
    }

    private IEnumerator DEBUG_Generate()
    {
        while (true)
        {
            GenerateNewTile();
            yield return new WaitForSeconds(1f);
        }
    }
}
