using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateMatrix : MonoBehaviour
{

  //  public GameObject manager;
    public GameObject prefab;
    public GameObject clone;
    int row = 7;
    int col = 5;
    public List<int> patternTarget = new List<int>();
    public List<int> patternSource = new List<int>();


    // Start is called before the first frame update
    private void Start()
    {
        initPatternSource();
    //    manager = GameObject.Find("GameManager");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                clone = Instantiate(prefab);
                clone.transform.position =  new Vector3((i + 1)*2,0,(j + 1)*2);
                clone.name = "cylinder"+i+j;
                clone.tag = "Pattern";

                //Debug.Log("Creating enemy number: " + i);
            }
            //Debug.Log("Creating enemy number: " + i);
        }

    }

    void initPatternSource () {

        patternSource.Add(3);
        patternSource.Add(12);
        patternSource.Add(21);
        patternSource.Add(32);
        patternSource.Add(40);
        patternSource.Add(54);
        patternSource.Add(63);
    
    }

    public bool checkMatch(List<int> pS,List<int> pT)
    
    {
        //Debug.Log(pS.Count);
        //for(int i =0; i< pS.Count; i++)
        //{
        //    Debug.Log("PS:: "+pS[i]);
        //}
        //for (int i = 0; i < pT.Count; i++)
        //{
        //    Debug.Log("PT:: " + pT[i]);
        //}


        if (pS.Count != pT.Count)
            return false;
        else 
        {
            Debug.Log("same count");
            pS.Sort();
            pT.Sort();
            for(int i=0; i< pT.Count; i++)
            {
                if(!(pT[i] == pS[i]))
                {
                    return false;
                }
            }

           // Debug.Log("SAME");
            return true;
           
        }
     

    }




}

