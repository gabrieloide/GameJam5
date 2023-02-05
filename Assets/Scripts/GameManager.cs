using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FamilyState
{
    Dad,
    Mom,
    Son
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController playerController;
    public FamilyState familyState = FamilyState.Dad;
    Dictionary<int, FamilyState> tableFamily = new Dictionary<int, FamilyState>();
    public GameObject[] Players;
    public GameObject currentPlayer;
    public int indexFamilyState;
    public bool hasKey;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerController = FindObjectOfType<PlayerController>();
        currentPlayer = Instantiate(Players[indexFamilyState], transform.position, Quaternion.identity);
        tableFamily.Add(0, FamilyState.Dad );
        tableFamily.Add(1,FamilyState.Mom );
        tableFamily.Add(2,FamilyState.Son );
    }
    private void Update()
    {
        ChangeFamilyMember();
    }
    void ChangeFamilyMember()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (indexFamilyState < 2)
            {
                indexFamilyState++;
                instantiateFamilyMember();
            }
            else
            {
                indexFamilyState = 0;
                instantiateFamilyMember();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (indexFamilyState > 0)
            {
                indexFamilyState--;
                instantiateFamilyMember();
            }
            else
            {
                indexFamilyState = 2;
                instantiateFamilyMember();
            }
        }
    }
    void instantiateFamilyMember()
    {
        Vector3 lastPos = currentPlayer.transform.position;
        Destroy(currentPlayer);
        familyState = tableFamily[indexFamilyState];
        currentPlayer = Instantiate(Players[indexFamilyState], lastPos, Quaternion.identity);
    }

}
