using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
public class DynamicLoader : MonoBehaviour {
   
    GameObject[] go=new GameObject[20];
    string []numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    GameObject goImageTarget = null;
    public GameObject[] tmp = new GameObject[10];
    public GameObject RedMolecule;
    public GameObject BlueMolecule;
    GameObject spawn;
    public Transform target;
    //SortedDictionary<int, KeyValuePair<int, GameObject>> elements=new SortedDictionary<int,KeyValuePair<int,GameObject>>();
   // SortedList list = new SortedList();
    // specify these in Unity Inspector


   

    Camera cam;
    // Use this for initialization
    void Start () {
       
        //rot = GameObject.Find("H/blau");
        //blau = GameObject.Find("O/rot");
        //Material mat = (Material)Resources.Load("Connector");
       // line = rot.AddComponent<LineRenderer>();
        //line2 =blau.AddComponent<LineRenderer>();
        //line.material = mat;
        cam = GetComponent<Camera>();

        // line.SetColors(Color.white,Color.black);
        // Set the width of the Line Renderer
        //line.SetWidth(0.02F, 0.02F);
        // line2.SetWidth(0.02F, 0.02F);

        // Set the number of vertex fo the Line Renderer
        //line = rot.AddComponent<LineRenderer>();
        //line2 =blau.AddComponent<LineRenderer>();
        // line.SetVertexCount(2);
        //line2.SetVertexCount(2);
        // init();
        //elements = map(elements);
    }

    // Update is called once per frame
   public string  getMolekule(int numberTracked)
    {
        string molecule = "";
        int kk = 0;
        int numcnt = 0;
        SortedDictionary<float, TrackableBehaviour> dictionary = new SortedDictionary<float, TrackableBehaviour>();
        //SortedDictionary<float, TrackableBehaviour> ypos = new SortedDictionary<float, TrackableBehaviour>();
        string[] numname;
       // int cnt = 0;
       // GameObject[] objects = new GameObject[5];
        // Check if the GameObjects are not null

        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in tbs)
        {
           
            target = tb.transform;
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            dictionary[screenPos.x] = tb;

        }
       
       /* foreach (TrackableBehaviour tb in tbs)
        {
            target = tb.transform;
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            ypos[screenPos.y] = tb;
        }*/

        

        /*foreach (KeyValuePair<float, TrackableBehaviour> k in ypos)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
               
                if (k.Value.TrackableName.Equals(numbers[i]))
                {
                   
                    kk += Int32.Parse(k.Value.TrackableName);
                    //Debug.Log(kk);
                    ++numcnt;
                   
                }
            }
        }*/
        
        //numname = new string[kk];
        //int cc = 0;
        /*foreach (KeyValuePair<float, TrackableBehaviour> k in ypos)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                
                if (k.Value.TrackableName.Equals(numbers[i]))
                {
                    numname[cc] = k.Value.TrackableName;
                    cc++;
                    
                }
            }
        }*/


        foreach (KeyValuePair<float, TrackableBehaviour> k in dictionary)
        {
            molecule = molecule + k.Value.TrackableName;
            Debug.Log(molecule + "Molekül richtig?");
           
               
               
                if (k.Value.TrackableName.Equals(""+numberTracked))
                {
                   
                    for (int x = 0; x < dictionary.Count; ++x)
                    {
                        
                        if (dictionary.Keys.ElementAt(x).Equals(k.Key))
                        {
                            DrawBalls(numberTracked, dictionary.Values.ElementAt(x - 1).TrackableName, dictionary.Values.ElementAt(x).TrackableName);
                           
                        }

                    }
                
            }


        }
        return molecule;
    }
  
    void DrawBalls(int number, String name, String imagename)
    {
        String test = "";
        String after = "";
        for (int i = 0; i < number-1; ++i)
        {
            switch (name)
            {
                case "H":
                    GameObject H = GameObject.Find(imagename);
                    if (H.transform.childCount != number-1) {
                        GameObject obj = new GameObject();
                        Debug.Log("loader" + H.transform.childCount);
                        obj = Instantiate(BlueMolecule, new Vector3(transform.position.x, transform.position.y, 0.4F + 0.25F * i), Quaternion.identity);
                        
                    // GameObject goImageTarget = GameObject.Find(imagename);
                        obj.transform.parent = H.transform;
                        obj.transform.localPosition = new Vector3(0F, 0.15F,  0.25F * i);
                        obj.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                       // elements[i] = new KeyValuePair<int, GameObject>(1, obj);
                       // list.Add(1, obj);
                    }
                    break;
                case "O":
                    GameObject goImageTarget = GameObject.Find(imagename);
                    if (goImageTarget.transform.childCount != number-1)
                    {
                        GameObject obj = new GameObject();
                        Debug.Log("loader" + goImageTarget.transform.childCount);
                        obj = Instantiate(RedMolecule, new Vector3(transform.position.x, transform.position.y, 0.4F + 0.25F * i), Quaternion.identity);
                       // elements[i] = new KeyValuePair<int, GameObject>(8, obj);
                        // GameObject goImageTarget = GameObject.Find(imagename);
                        obj.transform.parent = goImageTarget.transform;
                        obj.transform.localPosition = new Vector3(0F, 0.15F,  0.25F * i);
                        obj.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                      // list.Add(8, obj);
                    }
                    break;
                case "C":
                    GameObject C = GameObject.Find(imagename);
                    if (C.transform.childCount != number-1)
                    {
                        GameObject obj = new GameObject();
                        Debug.Log("loader" + C.transform.childCount);
                        obj = Instantiate(BlueMolecule, new Vector3(transform.position.x, transform.position.y, 0.4F + 0.25F * i), Quaternion.identity);
                       // elements[i] = new KeyValuePair<int, GameObject>(6, obj);
                        // GameObject goImageTarget = GameObject.Find(imagename);
                        obj.transform.parent = C.transform;
                        obj.transform.localPosition = new Vector3(0F, 0.15F, 0.25F * i);
                        obj.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                       // list.Add(6, obj);
                    }
                    break;
            }

            
            }
        
       /* for(int i=1; i < elements.Count-1; ++i) {
            if(list.GetKey(i).Equals(list.GetKey(i-1)))
                {
                Debug.Log("hello world"+ list.GetByIndex(i));
                drawLine((GameObject)list.GetByIndex(i), (GameObject)list.GetByIndex(i-1));
            }
}*/
    }


    SortedDictionary<int, string> map(SortedDictionary<int, string> elements)
    {
        
        elements[1] = "H";
        elements[8] = "O";
        elements[6] = "C";
        return elements;
    }
    void drawLine(GameObject Start, GameObject Ziel)
    {
        Debug.Log("line" + Start + Ziel);
        LineRenderer line = Start.AddComponent<LineRenderer>();

        Debug.Log("DrawLine");
        line.SetVertexCount(2);
        line.SetPosition(0, Start.transform.position);
      
        line.SetPosition(1, Ziel.transform.position);
        line.SetWidth(0.5f, 0.5f);
        line.useWorldSpace = true;
        //line.material = LineMaterial;
    }


    void engine()
    {

    }
    void init()
    {
       
        
        
       // Destroy(goImageTarget);
       // Destroy(tmp);
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in tbs)
        {
            
            switch (tb.TrackableName){
                case "H":
               
                    if (tmp[0] == null)
                    {
                        tmp[0] = new GameObject();
                    
                
                    goImageTarget = GameObject.Find(tb.TrackableName);
                    tmp[0] = Instantiate(BlueMolecule, new Vector3(transform.position.x, transform.position.y, 0.4F), Quaternion.identity);
                        
                    tmp[0].transform.parent = goImageTarget.transform;
                        tmp[0].transform.localPosition = new Vector3(0F, 0.15F, 0F);
                    tmp[0].transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                    tmp[0].gameObject.active = true;
                        break;
                    }
                    break;
                case "O":
                    if (tmp[1] == null)
                    {
                        tmp[1] = new GameObject();
                       
                        goImageTarget = GameObject.Find(tb.TrackableName);
                        tmp[1] = Instantiate(RedMolecule, new Vector3(transform.position.x, transform.position.y, 0.4F), Quaternion.identity);
                        tmp[1].transform.parent = goImageTarget.transform;
                        tmp[1].transform.localPosition = new Vector3(0F, 0.15F, 0F);
                        tmp[1].transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                        break;
                    }break;
                default:
                    break;
            }
            

        }
    }
    
}
