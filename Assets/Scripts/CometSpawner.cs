using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    
    
    [SerializeField] 
    private GameObject whiteComet;
    private Vector3 _whiteCometSpawnPosition;

    void Start()
    {
        _whiteCometSpawnPosition = new Vector3(whiteComet.transform.position.x, whiteComet.transform.position.y,whiteComet.transform.position.z);
        Repeat();
    }

   void Repeat ()
   {
       StartCoroutine(cometSpawnCD());
   }
   IEnumerator cometSpawnCD()
   {
       yield return new WaitForSeconds(10f);
       float randomBias = Random.Range(2f,20f);
       GameObject newWhiteComet= Instantiate(whiteComet, new Vector3(_whiteCometSpawnPosition.x +randomBias, _whiteCometSpawnPosition.y, _whiteCometSpawnPosition.z), Quaternion.identity);
       newWhiteComet.transform.localScale = new Vector3(0.2f, 0.2f, 0);
       newWhiteComet.transform.Rotate(new Vector3(0f, 0f, 46.5f));
       Destroy (newWhiteComet, 7);
       Repeat();

   }
}