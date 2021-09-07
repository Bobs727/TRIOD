using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackCometSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject blackComet;
    private Vector3 _blackCometSpawnPosition;

    void Start()
    {
        _blackCometSpawnPosition = new Vector3(blackComet.transform.position.x, blackComet.transform.position.y,blackComet.transform.position.z);
        Repeat();
    }

   void Repeat ()
   {
       StartCoroutine(cometSpawnCD());
   }
   IEnumerator cometSpawnCD()
   {
       yield return new WaitForSeconds(30f);
       float randomBias = Random.Range(-20f,-2f);
       GameObject newBlackComet= Instantiate(blackComet, new Vector3(_blackCometSpawnPosition.x +randomBias, _blackCometSpawnPosition.y, _blackCometSpawnPosition.z), Quaternion.identity);
       newBlackComet.transform.localScale = new Vector3(0.25f, 0.25f, 0);
       newBlackComet.transform.Rotate(new Vector3(0f, 0f, 46.5f));
       Destroy (newBlackComet, 7);
       Repeat();
   }

}
