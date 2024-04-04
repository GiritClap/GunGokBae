using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnOre : MonoBehaviour
{
    public GameObject[] oreArray; //스폰 시킬 아이템
    public GameObject rangeObject; //스폰 할 위치 오브젝트
    BoxCollider rangeCollider; // 스폰할 위치 오브젝트 콜라이더
    public int oreCount; // 스폰할 아이템 갯수

    //시작하자마자 랜덤위치에 광석 생성
    void Start()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
        for(int i = 0; i<oreCount; i++){
            int randomInt = Random.Range(0,oreArray.Length);
            GameObject spawnOre = Instantiate(oreArray[randomInt],RandomPosition(), Quaternion.identity);
        }
    }

    //랜덤 위치 생성
    private Vector3 RandomPosition(){
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x; // bounds.size 콜라이더 사이즈 가져옴
        float range_Z = rangeCollider.bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 1.5f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }


}
