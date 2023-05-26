using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolvingControl : MonoBehaviour
{
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.0125f;
    public SkinnedMeshRenderer skinnedMesh;
    public float refreshrate = 0.025f;
    public Animator animator;
    private Material[] skinnedMaterials;

    private Material defaultMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;
    }
    

    IEnumerator DissolveCO()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }
        if (skinnedMaterials.Length >0)
        {
            float counter = 0;
            while (skinnedMaterials[0].GetFloat("_DissolveAmount") < 0.63f)
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshrate);
            }
            
            Debug.Log("SALGO");
            //skinnedMaterials[0].SetFloat("_DissolveAmount", 0f);
        }
    }

    private void OnDisable()
    {
        skinnedMaterials[0].SetFloat("_DissolveAmount", 0f);
    }
}
