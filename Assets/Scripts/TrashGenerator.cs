using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to randomly generate trash across the map

public class TrashGenerator : MonoBehaviour
{
    //variables for amount of trash and spacing
    public int trashSize = 20;
    public int trashSpacing = 10; //element is anything we place in the forest

    public TElement[] trashElements; //array of trash elements

    private void Start()
    {
        //itterate through array of elements
        for (int i = 0; i < trashSize; i += trashSpacing)
        {
            for (int j = 0; j < trashSize; j += trashSpacing)
            {
                for (int k = 0; k < trashElements.Length; k++)
                {
                    TElement element = trashElements[k];

                    //place the trash at random position
                    if (element.CanPlaceTrash())
                    {
                        Vector3 position = new Vector3(i-100, 0.1f, j-100);
                        Vector3 offset = new Vector3(Random.Range(-trashSpacing / 2, trashSpacing / 2), 0f, Random.Range(-trashSpacing / 2, trashSpacing / 2));

                        GameObject newElement = Instantiate(element.GetRandomTrash());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        break;
                    }
                }
            }
        }
    }
}

//class to hold all prefabs / elements
[System.Serializable]
public class TElement
{
    public string name;
    [Range(1, 10)]
    public int tDensity;

    public GameObject[] tPrefabs;

    //check if trash can be placed in that spot
    public bool CanPlaceTrash()
    {
        if (Random.Range(0, 10) < tDensity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //pick a random trash from list
    public GameObject GetRandomTrash()
    {
        return tPrefabs[Random.RandomRange(0, tPrefabs.Length)];
    }
}