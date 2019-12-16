using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementLoaded : MonoBehaviour
{
    string symbol;
    int lastElectrons;
    float electroNegativity;
    // Start is called before the first frame update
    void Start()
    {
        symbol = transform.Find("Symbol").GetComponent<TextMesh>().text;
        int aux = GameObject.Find("GameController").GetComponent<InstantiateElements>().GetLastElectrons(symbol);
        SetLastElectrons(aux);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetElectroNegativity()
    {
        return electroNegativity;
    }

    public void SetElectroNegativity(float electroNegativity)
    {
        this.electroNegativity = electroNegativity;
    }
    public int GetLastElectrons()
    {
        return lastElectrons;
    }

    public void SetLastElectrons(int lastElectrons)
    {
        this.lastElectrons = lastElectrons;
    }

    private void OnTriggerEnter(Collider other)
    {
        int completeO = 0;
        if (other.GetComponent<ElementLoaded>().electroNegativity < electroNegativity)
        {
            completeO = lastElectrons + other.GetComponent<ElementLoaded>().GetLastElectrons();
            if(completeO == 8)
            {
                other.transform.Find(other.transform.Find("Name").GetComponent<TextMesh>().text).transform.parent = transform.Find(transform.Find("Name").GetComponent<TextMesh>().text);
            }
        }
    }
}
