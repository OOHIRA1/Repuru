using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopRobot : MonoBehaviour {

    public enum STOP_ROBOT_STATE
    {
        LOOKOUT, //見張り
        CHASE,   //追う
        RETURN,  //戻る
    }

    [SerializeField] private Transform _tarPos; //プレイヤー
    [SerializeField] private Transform _prePos; //元の場所

    public STOP_ROBOT_STATE _state;

    private NavMeshAgent _agent;

    private float yRotate = 0f;

    // Use this for initialization
    void Start () {
        _agent = GetComponent < NavMeshAgent > ();
        _state = STOP_ROBOT_STATE.LOOKOUT;
        StartCoroutine ("coRoutine");
    }

    //初期化
    void Initialization () {
        yRotate = 0f;
        StartCoroutine ("coRoutine");
    }

    //2秒ごとに90度回転させる
    IEnumerator coRoutine () {
        while (true) {
            yield return new WaitForSeconds (2f);
            yRotate += 90f;
        }
    }

    void Update () {
        switch (_state) {
            case STOP_ROBOT_STATE.LOOKOUT:  //見張り
            transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yRotate, transform.eulerAngles.z);
            break;

            case STOP_ROBOT_STATE.CHASE:    //追う
            StopCoroutine ("coRoutine");
            _agent.SetDestination (_tarPos.transform.position);
            break;

            case STOP_ROBOT_STATE.RETURN:   //戻る
            _agent.SetDestination (_prePos.transform.position);

            //見張りの場所に戻ったら
            if (transform.localPosition.x == _prePos.transform.localPosition.x) {
                _state = STOP_ROBOT_STATE.LOOKOUT;
                Initialization ();
            }
            break;
        }
    }

    void OnTriggerEnter (Collider other) {
        //プレイヤーを発見したら
        if (other.gameObject.tag == "Player") {
            Debug.Log ("動かないロボット：お前はもう死んでいる");
        }
    }
}
