using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class LookAtPlayer : MonoBehaviour
{
    public Transform ghost1;
    public Transform ghost2;
    public Transform ghost3;
    public Transform ghost4;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost1.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
        ghost2.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
        ghost3.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
        ghost4.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
    }

    void rotateGhost(ref Transform player, Vector3 playerPos, ref Transform ghost, Vector3 ghostPos)
    {
        ghost.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
        Vector3 targetDir = (playerPos - ghostPos).normalized;
        float dotProduct = Vector3.Dot(ghost.forward, targetDir);
        bool ghostClose = dotProduct < 0.95f;
        if (ghostClose)
        {
            float sideDot = Vector3.Dot(ghost.right, targetDir);
            if (sideDot > 0)
            {
                ghost.Rotate(0, 50.0f * Time.deltaTime, 0);
            }
            else
            {
                ghost.Rotate(0, -50.0f * Time.deltaTime, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        Vector3 ghost1Pos = ghost1.position;
        Vector3 ghost2Pos = ghost2.position;
        Vector3 ghost3Pos = ghost3.position;
        Vector3 ghost4Pos = ghost4.position;
        if (Vector3.Distance(playerPos, ghost1Pos) < 5f)
        {
            rotateGhost(ref player, playerPos, ref ghost1, ghost1Pos);
        }
        else
        {
            ghost1.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = true;
        }
        if (Vector3.Distance(playerPos, ghost2Pos) < 5f)
        {
            rotateGhost(ref player, playerPos, ref ghost2, ghost2Pos);
        }
        else
        {
            ghost2.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = true;
        }
        if (Vector3.Distance(playerPos, ghost3Pos) < 5f)
        {
            rotateGhost(ref player, playerPos, ref ghost3, ghost3Pos);
        }
        else
        {
            ghost3.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = true;
        }
        if (Vector3.Distance(playerPos, ghost4Pos) < 5f)
        {
            rotateGhost(ref player, playerPos, ref ghost4, ghost4Pos);
        }
        else
        {
            ghost4.GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = true;
        }
    }
}
