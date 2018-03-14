using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {
    Mesh myMesh;
    MeshRenderer mRender;
    //MeshCollider mCollider;
    public Material tMat;

    Vector3[] vertex;
    int[] myTriangles;
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>();
        mRender=gameObject.AddComponent<MeshRenderer>();

        mRender.material = tMat;

        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
        
        vertex = new[]
        {
            new Vector3(0,0,0),
            new Vector3(1,1,0),
            new Vector3(2,0,0)
        };
        myMesh.vertices = vertex;
        myTriangles = new[] {0, 1, 2 };
        myMesh.triangles = myTriangles;
        /*mCollider = new MeshCollider();
        mCollider = gameObject.AddComponent<MeshCollider>();
        mCollider.sharedMesh = myMesh;*/
        //GetComponent<MeshCollider>().sharedMesh = myMesh;
    }
   

    // Update is called once per frame
    void Update () {
		
	}
}
