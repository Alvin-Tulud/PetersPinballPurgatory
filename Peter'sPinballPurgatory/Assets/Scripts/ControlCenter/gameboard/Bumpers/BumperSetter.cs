using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BumperSetter : MonoBehaviour
{
    public GameObject bumperPrefab;
    public GameObject[] bumperSlots;
    public int maxBumpers;
    private int currentBumperCount;
    
    public void setBumpers(List<BigInteger> bumperScores)
    {
        currentBumperCount = 0;

        foreach(GameObject bumper in bumperSlots)
        {
            if (bumper.transform.childCount > 0)
            {
                //Debug.Log(bumper.transform.childCount);
                //Debug.Log("Check Destroy");
                Destroy(bumper.transform.GetChild(0).gameObject);
            }
        }

        for (int i = 0; i < bumperSlots.Length; i++)
        {
            if (currentBumperCount < maxBumpers)
            {
                if (maxBumpers - currentBumperCount == bumperSlots.Length - i)
                {
                    GameObject g;
                    g = Instantiate(bumperPrefab, bumperSlots[i].transform.position, bumperSlots[i].transform.rotation, bumperSlots[i].transform);

                    g.GetComponent<BumperStats>().setScore(bumperScores[currentBumperCount]);

                    currentBumperCount++;
                }
                else
                {
                    float rand = Random.Range(0f, 1f);

                    //Debug.Log("rand float chance: " +  rand);

                    if (rand > 0.5f)
                    {
                        GameObject g;
                        g = Instantiate(bumperPrefab, bumperSlots[i].transform.position, bumperSlots[i].transform.rotation, bumperSlots[i].transform);

                        g.GetComponent<BumperStats>().setScore(bumperScores[currentBumperCount]);

                        currentBumperCount++;
                    }
                }
            }
        }
    }
}
