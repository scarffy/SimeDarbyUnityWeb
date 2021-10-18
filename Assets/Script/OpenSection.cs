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
    public bool RoofBool = false;
    public bool LeftWallBool = false;
    public bool RightWallBool = false;
    public bool OtherBuildingsBool = false;

    [Space]
    public GameObject[] GFloor;
    public GameObject[] FirstFloor;
    public GameObject[] SecondFloor;
  

    [Space]
    public bool GFloorBool = false;
    public bool FirstFloorBool = false;
    public bool SecondFloorBool = false;
    

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

    public void FirstFloorLogic()
    {
        if(FirstFloor.Length > 0)
        {
            if (FirstFloorBool)
            {
                for (int i = 0; i < FirstFloor.Length; i++)
                {
                    FirstFloor[i].SetActive(false);
                }
                FirstFloorBool = false;
            }
            else
            {
                for (int i = 0; i < FirstFloor.Length; i++)
                {
                    FirstFloor[i].SetActive(true);
                }
                FirstFloorBool = true;
            }
        }
    }

    public void SecondFloorLogic()
    {
        if (SecondFloorBool)
        {
            for (int i = 0; i < SecondFloor.Length; i++)
            {
                SecondFloor[i].SetActive(false);
            }
            SecondFloorBool = false;
        }
        else
        {
            for (int i = 0; i < SecondFloor.Length; i++)
            {
                SecondFloor[i].SetActive(true);
            }
            SecondFloorBool = true;
        }
    }

    public void ThirdFloorLogic()
    {
        if (GFloorBool)
        {
            for (int i = 0; i < GFloor.Length; i++)
            {
                GFloor[i].SetActive(false);
            }
            GFloorBool = false;
        }
        else
        {
            for (int i = 0; i < GFloor.Length; i++)
            {
                GFloor[i].SetActive(true);
            }
            GFloorBool = true;
        }
    }
}
