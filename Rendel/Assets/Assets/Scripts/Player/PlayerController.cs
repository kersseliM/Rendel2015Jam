using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    bool butLeftUpClicked;
    bool butLeftLowClicked;
    bool butRightUpClicked;
    bool butRightLowClicked;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void checkInput()
    {

    }

    public void ButtonLeftUpperClicked()
    {
        print("BLU clicked");
        butLeftUpClicked = true;
    }
    public void ButtonLeftLowerClicked()
    {
        print("BLL clicked");
        butLeftLowClicked = true;
    }
    public void ButtonRightUpperClicked()
    {
        print("BRU clicked");
        butRightUpClicked = true;
    }
    public void ButtonRightLowerClicked()
    {
        print("BRL clicked");
        butRightLowClicked = true;
    }

}
