
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runemark.DialogueSystem;

public class BotDeath : MonoBehaviour
{
    public GameObject[] prefabs;

    public float cubeSize = 0.7f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 100f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    DialogueInterface dialogue;

    private void Start()
    {
        dialogue = GetComponent<DialogueInterface>();
        CalculatePivot();
    }

    public void DeathSequence()
    {
        dialogue.DialogueClose();
        Explode();
    }

    void Explode()
    {
        gameObject.SetActive(false);

        //loop 3 times to create pieces in x, y, z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        //get explosion postion
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that sphere
        foreach (Collider hit in colliders)
        {
            //get rb from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosive force
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        int prefabChoice = Random.Range(0, prefabs.Length);
        piece = Instantiate(prefabs[prefabChoice]);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

    //for calculating cubes pivot distance
    void CalculatePivot()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }
}

