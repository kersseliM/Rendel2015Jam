using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{

    public void goLevel()
    {

        Application.LoadLevel(1);

    }


    public void quit()
    {
        Application.Quit();

    }

}
