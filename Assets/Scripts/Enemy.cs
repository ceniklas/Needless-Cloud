using UnityEngine;
using System.Collections;
using System;


    class Enemy : MonoBehaviour
    {
    public GameObject enemy;

        public Enemy()
        {
        enemy = new GameObject();
        enemy.name = "Enemy";


        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(enemy.transform);

        enemy.AddComponent<MeshRenderer>();
        Material runtimeMaterial = new Material(Shader.Find("Standard"));
        runtimeMaterial.color = new Color(1.0f, 0, 0);
        enemy.GetComponent<Renderer>().material = runtimeMaterial;
        enemy.transform.position = new Vector3(1.5f, 0, 0);
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    }
