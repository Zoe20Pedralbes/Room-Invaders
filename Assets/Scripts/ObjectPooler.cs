using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    public List<GameObject> objectPool;
    private GameObject prefab;
    private string tag;


    public ObjectPooler(int timesPerObject, GameObject objectPrefab, string tag)
    {
        objectPool = new List<GameObject>();
        prefab = objectPrefab;
        this.tag = tag;
        for (int i = 0; i < timesPerObject; i++)
        {
            GameObject go = GameObject.Instantiate(objectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.tag = tag;
            go.GetComponent<Bullet>().setPool(this);
            go.SetActive(false);
            objectPool.Add(go);
        }

    }

    public void ToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject go = GameObject.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        go.tag = this.tag;
        go.SetActive(true);
        go.GetComponent<Bullet>().setPool(this);
        objectPool.Add(go);
        return go;
    }
}
