using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    public GameObject StreetIntercetion;
    public GameObject MainSt;

    public Transform StTransform;
    public Transform RightStreet;

    public GameObject SiteHolder;

    public GameObject[] Cars;
    public Transform[] CarSpawns;

    public Transform SiteLoc;
    public Transform[] BuildStite;

    public GameObject buildingRandom;

    public float age = 34;
    
    public float cents = 2.30f;

    private float sitePosX = 570;       
    private float sitePosY = 1;
    private float sitePosZ = -410;
  
    private float StForwardX = 515f;
    private float StForwardY = 1f;
    private float StForwardZ = -1985f;

    private float StSideX = 515f;
    private float StSideY = 1f;
    private float StSideZ = -1930f;

    public bool LeftBuild = true;
    public bool RightBuild = false;

    private float X;
    private float Y;
    private float Z;

    public float P;

    public bool buildNow = true;

    void Start()
    {     
        for (int i=0; i<30; i++)
        {
            SiteBuilder();
            StreetForward();
            SideStreet();
        }
    }
    public void BuildingInstantiate()
    {
        P = RandomBuildingDivide(age);
        print(P);

        for (int i = 0; i < 12; i++)
        {
            Instantiate(Cars[Random.Range(0, Cars.Length)], CarSpawns[i].position, CarSpawns[i].rotation);
        }
        for (int i = 0; i < 16; i++)
        {
            buildingRandom.transform.localScale = new Vector3(Random.Range(10, 25f), Random.Range(30, 150f), Random.Range(10, 30f));
            Y = buildingRandom.transform.localScale.y;
            Y = RandomBuildingDivide(Y);
            X = BuildStite[i].position.x;
            Z = BuildStite[i].position.z;
            BuildStite[i].position = new Vector3(X, Y, Z);
            Instantiate(buildingRandom, BuildStite[i].position, BuildStite[i].rotation);
        }
    }

    public float RandomBuildingDivide(float number) => number / 2;
    public float StMathADD(float number) => number + 55;
    public float BuildingAdd(float number, float diff) => number + diff;
    public void SiteBuilder()
    {
        for (int i = 0; i < 5; i++)
        {
            if (sitePosZ >= 1270 && LeftBuild == true)
            {
                sitePosZ = -620;
                RightBuild = true;
                LeftBuild = false;
            }
            else if (sitePosX >= 1560 && LeftBuild == true)
            {
                sitePosZ += 210;
                sitePosX = 570;
            }
            else if (sitePosX >= 1560 && RightBuild == true)
            {
                sitePosZ = BuildingAdd(sitePosZ,-210);
                sitePosX = 570;
            }
            else if (sitePosZ <= -2000 && RightBuild == true)
            {
                i = 6;
            }
            else
            {
                SiteLoc.position = new Vector3(sitePosX, sitePosY, sitePosZ);
                Instantiate(SiteHolder, SiteLoc.position, SiteLoc.rotation);//this makes the platform for the building to go onto.
                sitePosX = BuildingAdd(sitePosX,110);
                BuildingInstantiate();//this calls the cars and building placer function.
            }
        }
    }
    public void StreetForward() //this handles forward streets and intersetions 
    {
        for (int i = 0; i < 5; i++)
        {
            if ( StForwardX > 1506)//this controls hight 1 of 2
            {
                StForwardZ = BuildingAdd(StForwardZ,210);
                StForwardX = 515f;
            }
            if(StForwardZ >= 1184)//this controls length
            {
                i = 6; //this makes it stop
            }
            else 
            {
                StTransform.position = new Vector3(StForwardX, StForwardY, StForwardZ);
                Instantiate(StreetIntercetion, StTransform.position, StTransform.rotation);
                StForwardX = StMathADD(StForwardX);
                if (StForwardX > 1506)//this controls hight 2 of 2
                {
                    i = 6;
                }
                else
                {
                    StTransform.position = new Vector3(StForwardX, StForwardY, StForwardZ);
                    Instantiate(MainSt, StTransform.position, StTransform.rotation);
                    StForwardX = StMathADD(StForwardX);
                }
            }
        }
    }
    public void SideStreet()
    {
        for (int i = 0; i < 5; i++)
        {
            if (StSideZ >= 1165)//this controls length
            {
                StSideX = BuildingAdd(StSideX,110);
                StSideZ = -1930; 
            }
            if(StSideX >= 1510)//this controls hight
            {
               // i = 6; //this is not needed in the for loop
            }
            else
            {
                RightStreet.rotation = Quaternion.Euler(0, 90, 0);
                RightStreet.position = new Vector3(StSideX, StSideY, StSideZ);
                Instantiate(MainSt, RightStreet.position, RightStreet.rotation);
                StSideZ = BuildingAdd(StSideZ, 100);
                RightStreet.rotation = Quaternion.Euler(0, 90, 0);
                RightStreet.position = new Vector3(StSideX, StSideY, StSideZ);
                Instantiate(MainSt, RightStreet.position, RightStreet.rotation);
                StSideZ = BuildingAdd(StSideZ,110);
            }
        }
    }
}
