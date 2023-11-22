using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    //variables for size and each object to place
    public int forestSize = 100;
    public int elementSpacing = 6; 

    //array for all objects
    public Element[] elements;

    //public int mHeight;

    public void Start()
    {
        //itterate through each prefab object
        for(int i = 0; i < forestSize; i += elementSpacing)
        {
            for (int j = 0; j < forestSize; j += elementSpacing)
            {
                for (int k = 0; k < elements.Length; k++)
                {
                    Element element = elements[k];

                    if (element.CanPlace()) //place the object
                    {
                        //create new random pos, offset, rotation, scale 
                        Vector3 position = new Vector3(i-100, 0f, j-100);
                        Vector3 offset = new Vector3(Random.Range(-elementSpacing / 2, elementSpacing / 2), 0f, Random.Range(-elementSpacing / 2, elementSpacing / 2));
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        //place the element at the generated vectors
                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        newElement.transform.eulerAngles = rotation;
                        newElement.transform.localScale = scale;
                        break;
                    }
                }
            }
        }
    }
}

//class to hold each object to be placed
[System.Serializable]
public class Element
{
    public string name;
    [Range(1, 10)]
    public int density;

    public GameObject[] prefabs;

    public bool CanPlace()
    {
        if(Random.Range(0,10) < density)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //method to get random object from list
    public GameObject GetRandom()
    {
        return prefabs[Random.RandomRange(0,prefabs.Length)];
    }
}


