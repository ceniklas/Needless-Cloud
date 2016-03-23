using UnityEngine;
using System.Collections;
using System;


    class Enemy : MonoBehaviour
    {
    public GameObject enemy;
    public Renderer rend;
    public Color altColor = Color.black;

    public Enemy()
        {
        enemy = new GameObject();
        enemy.name = "Enemy";

        enemy.AddComponent<Rigidbody>();
        EnemyController p = enemy.AddComponent<EnemyController>();

        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(enemy.transform);

        enemy.AddComponent<MeshRenderer>();
        
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        rend = enemy.GetComponent<Renderer>();
        rend.material.color = altColor;
        enemy.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 0);
    }

        public void setEnemyLocation(float x, float y)
        {
            enemy.transform.position = new Vector3(x, 0, y);
        }
    }
