using System.Collections.Generic;
using UnityEngine;

public class BumperSetter : MonoBehaviour
{
    public GameObject bumperPrefab;
    public GameObject[] bumperSlots;
    public int maxBumpers;
    private int currentBumperCount;
    
    public void setBumpers(List<int> bumperScores)
    {
        currentBumperCount = 0;

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
