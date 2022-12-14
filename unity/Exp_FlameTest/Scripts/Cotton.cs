using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotton : MonoBehaviour
{
    public bool isBurning = false;
    public bool isBurned = false;
    public string type = null;
    
    public GameObject grains;
    public GameObject fire;

    private Grains grainsComp;
    private Fire fireComp;

    float burnTime;

    private void Awake()
    {
        grainsComp = grains.GetComponent<Grains>();
        fireComp = fire.GetComponent<Fire>();
    }

    private void Update()
    {
        if (isBurning)
        {
            grainsComp.onFire();
            fire.transform.LookAt(Vector3.up);

            burnTime += Time.deltaTime;
            if (burnTime >= 60)
            {
                fire.SetActive(false);
                isBurning = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flame")
        {
            if (!isBurned)
            {
                isBurned = true;
                isBurning = true;
                fire.SetActive(true);
                if (type == "Na")
                {
                    fireComp.setFireColor(Color.yellow);
                }else if (type == "Cu")
                {
                    fireComp.setFireColor(new Color(8f / 255f, 64f / 255f, 57f / 255f));
                }
                else if (type == "Sr")
                {
                    fireComp.setFireColor(Color.red);
                }
                else if (type == "Ba")
                {
                    fireComp.setFireColor(new Color(60f / 255f, 66f / 255f, 23f / 255f));
                }
                else if (type == "K")
                {
                    fireComp.setFireColor(new Color(1f, 51f / 255f, 1f));
                }
            }
        }
    }
}
