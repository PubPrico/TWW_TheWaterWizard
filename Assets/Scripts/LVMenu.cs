using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVMenu : MonoBehaviour
{
    public Image arcSelection, lvSelection;
    public Sprite[] arcs, lvs;
    public Button arcButtonFoward, arcButtonBackward, lvButtonFoward, lvButtonBackward;
    int i, j;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        j = 0;
        arcSelection.sprite = arcs[i];
        lvSelection.sprite = lvs[j];
    }

    // Update is called once per frame
    void Update()
    {
        arcSelection.sprite = arcs[i];
        lvSelection.sprite = lvs[j];
    }

    public void ChangeLVFoward()
    {
        if(j >= lvs.Length-1)
        {
            lvButtonFoward.interactable = false;
        }
        else
        {
            lvButtonBackward.interactable = true;
            j++;
        }
        
    }

    public void ChangeLVBackward()
    {
        if(j <= 0)
        {
            lvButtonBackward.interactable = false;
        }
        else
        {
            lvButtonFoward.interactable = true;
            j--;
        }
    }

    public void SelectedLV()
    {
        if(arcSelection.sprite == arcs[0] && lvSelection.sprite == lvs[0])
        {
            SceneManager.LoadScene("RadicalForestLV1");
        }
        else if(arcSelection.sprite == arcs[0] && lvSelection.sprite == lvs[1])
        {
            SceneManager.LoadScene("RadicalForestLV2");
        }
        else if(arcSelection.sprite == arcs[0] && lvSelection.sprite == lvs[2])
        {
            SceneManager.LoadScene("RadicalForestLV3");
        }
    }
}
