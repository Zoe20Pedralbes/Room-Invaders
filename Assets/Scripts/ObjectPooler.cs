using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    public List<GameObject> objectPool;
    public GameObject objectPrefab;
    private int NoActives;


    public ObjectPooler(int timesPerObject, GameObject objectPrefab, string tag)
    {
        objectPool = new List<GameObject>();
        this.objectPrefab = objectPrefab;

        foreach (GameObject obj in objectPool)
        {
            for (int i = 0; i < timesPerObject; i++)
            {
                GameObject go = GameObject.Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
                go.tag = tag;
                Debug.Log(go.tag);
                obj.GetComponent<Bullet>().setPool(this);
                go.SetActive(false);
                NoActives++;
                objectPool.Add(go);
            }
        }
    }

    public void ToPool(GameObject obj)
    {
        obj.SetActive(false);
        NoActives++;
    }

    public GameObject GetObject()
    {
        int whichNoActive = Random.Range(1, NoActives);
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                if (--whichNoActive == 0)
                {
                    NoActives--;
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        GameObject go = GameObject.Instantiate(objectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        objectPool.Add(go);
        return go;
    }
}
