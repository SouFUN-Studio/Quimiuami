using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InstantiateElements : MonoBehaviour
{
    public GameObject core;
    public GameObject electron;
    public GameObject card;
    public GameObject geometricCenter;
    public List<Transform> GeometricCenterList;
    //public TMP_Dropdown dropdown;
    public Canvas canvas;

    Elements elements;
    Element[] elementArray;


    private string gameDataFileName = "PeriodicTableJSON";
    public bool lastOrbit;
    GameObject info;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instanciando....");
        LoadGameData();
        Debug.Log("Información cargada....");
        info = canvas.transform.Find("Information").gameObject;
    }
    
    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        //string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        TextAsset file = Resources.Load(gameDataFileName) as TextAsset;
        if (file != null)
        {
            string dataAsJson ="";
            // Read the json from the file into a string
            dataAsJson = file.ToString();
            Debug.Log(dataAsJson);

            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            elements = JsonUtility.FromJson<Elements>(dataAsJson);
            elementArray = null;
            elementArray = elements.ElementList.ToArray();
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    public GameObject BuildAtom(string symbol)
    {
        Debug.Log("Creando elemento " + symbol);
        int i = 0;
        while(elementArray[i].symbol != symbol)
        {
            i++;
        }
        Debug.Log("Elemento encontrado: " + elementArray[i].name);
        int numberE = elementArray[i].number;
        info.transform.Find("electron_configuration").GetComponent<TextMeshProUGUI>().text = elementArray[i].electron_configuration;
        info.transform.Find("pahase").GetComponent<TextMeshProUGUI>().text = elementArray[i].pahase;
        info.transform.Find("atomic_mass").GetComponent<TextMeshProUGUI>().text = elementArray[i].atomic_mass.ToString();
        info.transform.Find("category").GetComponent<TextMeshProUGUI>().text = elementArray[i].category.ToString();
        info.transform.Find("discovered_by").GetComponent<TextMeshProUGUI>().text = elementArray[i].discovered_by;
        info.transform.Find("electronegativity_pauling").GetComponent<TextMeshProUGUI>().text = elementArray[i].electronetivity_pauling.ToString();

        GeometricCenterList.Clear();
        return DrawElectrons(numberE, i);
    }


    public GameObject DrawElectrons(int number, int i) {
        GameObject newCore = Instantiate(core, new Vector3(0, 0, 3f), new Quaternion(0, 0, 0, 0));
        newCore.name = elementArray[i].name;
        newCore.GetComponent<Renderer>().material.SetColor("_Color",   new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)));
        GameObject cardAux = Instantiate(card, new Vector3(0, 0, 0f), new Quaternion(0, 0, 0, 0));
        cardAux.transform.Find("Symbol").GetComponent<TextMesh>().text = elementArray[i].symbol;
        cardAux.transform.Find("Name").GetComponent<TextMesh>().text = elementArray[i].name;
        cardAux.transform.Find("Number").GetComponent<TextMesh>().text = elementArray[i].number.ToString();
        cardAux.name = "Card"+elementArray[i].name;
        if (lastOrbit)
        {
            switch (number)
            {
                case int n when (n <= 2 && n > 0):
                    DEO(elementArray[i].shells[0], i, .3f);
                    break;

                case int n when (n <= 10 && n > 2):
                    DEO(elementArray[i].shells[1], i, .3f);
                    break;

                case int n when (n <= 18 && n > 10):
                    DEO(elementArray[i].shells[2], i, .3f);
                    break;
                case int n when (n <= 36 && n > 18):
                    DEO(elementArray[i].shells[3], i, .3f);
                    break;
                case int n when (n <= 54 && n > 36):
                    DEO(elementArray[i].shells[4], i, .3f);
                    break;
                case int n when (n <= 86 && n > 54):
                    DEO(elementArray[i].shells[5], i, .3f);
                    break;
                case int n when (n <= 118 && n > 86):
                    DEO(elementArray[i].shells[6], i, .3f);
                    break;
            }
            newCore.transform.position = new Vector3(cardAux.transform.position.x, cardAux.transform.position.y, cardAux.transform.position.z - .5f);
            newCore.transform.parent = GameObject.Find("Card" + elementArray[i].name).transform;
            return cardAux;
        }
        else
        {
            switch (number)
            {
                
                case int n when (n <= 2 && n > 0):
                    DEO(elementArray[i].shells[0], i, .3f);
                    break;

                case int n when (n <= 10 && n > 2):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    break;

                case int n when (n <= 18 && n > 10):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    DEO(elementArray[i].shells[2], i, .7f);
                    break;
                case int n when (n <= 36 && n > 18):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    DEO(elementArray[i].shells[2], i, .7f);
                    DEO(elementArray[i].shells[3], i, .9f);
                    break;
                case int n when (n <= 54 && n > 36):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    DEO(elementArray[i].shells[2], i, .7f);
                    DEO(elementArray[i].shells[3], i, .9f);
                    DEO(elementArray[i].shells[4], i, 1.1f);
                    break;
                case int n when (n <= 86 && n > 54):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    DEO(elementArray[i].shells[2], i, .7f);
                    DEO(elementArray[i].shells[3], i, .9f);
                    DEO(elementArray[i].shells[4], i, 1.1f);
                    DEO(elementArray[i].shells[5], i, 1.3f);
                    break;
                case int n when (n <= 118 && n > 86):
                    DEO(elementArray[i].shells[0], i, .3f);
                    DEO(elementArray[i].shells[1], i, .5f);
                    DEO(elementArray[i].shells[2], i, .7f);
                    DEO(elementArray[i].shells[3], i, .9f);
                    DEO(elementArray[i].shells[4], i, 1.1f);
                    DEO(elementArray[i].shells[5], i, 1.3f);
                    DEO(elementArray[i].shells[6], i, 1.5f);
                    break;
            }
            newCore.transform.position = new Vector3(cardAux.transform.position.x, cardAux.transform.position.y, cardAux.transform.position.z - .5f);
            newCore.transform.parent = GameObject.Find("Card" + elementArray[i].name).transform;
            return cardAux;
        }
    }



    public void DEO(int e, int i, float r)
    {

        float alpha = Mathf.PI * 2 / e;
        float position = 0f;
        Transform coreAux = GameObject.Find(elementArray[i].name).transform;
        GameObject geoAux = Instantiate(geometricCenter, coreAux.transform.position, new Quaternion(0, 0, 0, 0));
        for (int j = 0; j < e; j++)
        {
            GameObject newElectron = Instantiate(electron, new Vector3(Mathf.Sin(position)*r, Mathf.Cos(position)*r, coreAux.position.z), transform.rotation);
            newElectron.transform.parent = geoAux.transform;
            geoAux.transform.parent = GameObject.Find(elementArray[i].name).transform;
            position = position + alpha;
        }
        GeometricCenterList.Add(geoAux.transform);
    }
    public int GetLastElectrons(string symbol)
    {
        int i = 0;
        while(symbol != elementArray[i].symbol)
        {
            i++;
        }
        int index = elementArray[i].shells.Length - 1;
        return elementArray[i].shells[index];
    }

    public void EnableLastOrbit(bool orbit)
    {
        lastOrbit = orbit;
        /*foreach(Transform t in GeometricCenterList)
            Destroy(t.gameObject);
            */
    }

}

public class Elements
{
    public List<Element> ElementList;
}
[Serializable]
public class Element
{
    public string name;
    public string symbol;
    public int number;
    public int period;
    public string category;
    public float atomic_mass;
    public string color;
    public string appearance;
    public string pahase;
    public float melt;
    public float boil;
    public float density;
    public string discovered_by;
    public float molar_heat;
    public string source;
    public string named_by;
    public string spectral_img;
    public string summary;
    public float ypos;
    public float xpos;
    public int[] shells;
    public string electron_configuration;
    public float electron_affinity;
    public float electronetivity_pauling;
    public float[] ionization_energies;

}
