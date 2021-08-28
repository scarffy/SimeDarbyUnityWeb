using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSection : MonoBehaviour
{
    public GameObject[] Roof;
    public GameObject[] LeftWall;
    public GameObject[] RightWall;
    public GameObject[] OtherBuildings;

    [Space(20)]
    [SerializeField] bool RoofBool = false;
    [SerializeField] bool LeftWallBool = false;
    [SerializeField] bool RightWallBool = false;
    [SerializeField] bool OtherBuildingsBool = false;

    public void RoofLogic()
    {
        if(Roof.Length > 0)
        {
            if (RoofBool)
            {
                for (int i = 0; i < Roof.Length; i++)
                {
                    Roof[i].SetActive(true);
                }
                RoofBool = false;
            }
            else
            {
                for (int i = 0; i < Roof.Length; i++)
                {
                    Roof[i].SetActive(false);
                }
                RoofBool = true;
            }
        }
    }

    public void LeftWallLogic()
    {
        if (LeftWall.Length > 0)
        {
            if (LeftWallBool)
            {
                for (int i = 0; i < LeftWall.Length; i++)
                {
                    LeftWall[i].SetActive(true);
                }
                LeftWallBool = false;
            }
            else
            {
                for (int i = 0; i < LeftWall.Length; i++)
                {
                    LeftWall[i].SetActive(false);
                }
                LeftWallBool = true;
            }
        }
    }

    public void RightWallLogic()
    {
        if (RightWall.Length > 0)
        {
            if (RightWallBool)
            {
                for (int i = 0; i < RightWall.Length; i++)
                {
                    RightWall[i].SetActive(true);
                }
                RightWallBool = false;
            }
            else
            {
                for (int i = 0; i < RightWall.Length; i++)
                {
                    RightWall[i].SetActive(false);
                }
                RightWallBool = true;
            }
        }
    }

    public void OtherBuildingLogic()
    {
        if (OtherBuildings.Length > 0)
        {
            if (OtherBuildingsBool)
            {
                for (int i = 0; i < OtherBuildings.Length; i++)
                {
                    OtherBuildings[i].SetActive(true);
                }
                OtherBuildingsBool = false;
            }
            else
            {
                for (int i = 0; i < OtherBuildings.Length; i++)
                {
                    OtherBuildings[i].SetActive(false);
                }
                OtherBuildingsBool = true;
            }
        }
    }
}
