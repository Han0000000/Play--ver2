using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;
    public static GameObject player;
    public GameObject cam_obj;
    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        Mission_Setting();

    }

    public static int mission_count = 0;
    public static bool mission_complicated = false;

    [Header("Stage1")]
    [Tooltip("Stage1의 변수들")]
    public int stage1_int;
    public Text stage1_text;

    [Header("Stage3")]
    [Tooltip("Stage3의 변수들")]
    public GameObject stage3_obj; // 소환할 오브젝트
    public Transform[] stage3_spots;

    [Header("Stage5")]
    [Tooltip("Stage5의 변수들")]
    float zoomSpeed = 2.0f;
    int stage3_space_count = 0;
    public GameObject stage5_charge;
    public Sprite[] stage5_spr_charge;
    public int stage5_need_count;

    [Header("Stage6")]
    [Tooltip("Stage6의 변수들")]
    public static int rythm_count = 0;
    public int[] stage6_btn = {0,1,2,3};
    public GameObject[] stage6_btns;

    [Header("Stage7")]
    [Tooltip("Stage7의 변수들")]
    public GameObject stage7_moved_box;
    public GameObject stage7_want_move_spot;
    public Transform stage7_spot;

    [Header("Stage8")]
    [Tooltip("Stage8의 변수들")]
    public GameObject[] stage8_texting_box;

    [Header("Stage9")]
    [Tooltip("Stage9의 변수들")]
    public GameObject stage9_enemy;

    [Header("Stage10")]
    [Tooltip("Stage10의 변수들")]
    Rigidbody2D player_rigid;
    public GameObject stage10_jump_map;
    public Transform stage10_spot;

    [Header("Stage11")]
    [Tooltip("Stage11의 변수들")]
    public GameObject stage11_exam;

    public static string[] str_mssion =
    {
        "화면에 글자를 확인하세요",
        "마우스를 클릭하세요",
        "목표지점으로 움직이세요",
        "ESC를 누르세요",
        "스페이스바를 연타하세요",
        "타이밍에 맞춰 클릭하세요",
        "박스를 Just Spot에 옮겨주세요",
        "Hello World를 빠르게 입력하세요",
        "다가오는 적을 향해서 살아남으세요",
        "Space A D를 눌러서 점프맵을 클리어 하세요",
        "정답을 맞추세요."
    };

    void Update()
    {
        Mission_Play();
    }
    public void Misson_End()
    {
        if (mission_complicated)
        {
            Timer.total_stage = mission_count;
            mission_count++;
            Mission_Setting();
        }
        else if (!mission_complicated)
        {
            GameManager.isGameEnd = true;
            SceneManager.LoadScene("EndScene");
        }
    }

    public void Mission_Setting()
    {
        cam_obj.GetComponent<Camera>().orthographicSize = 5;
        stage5_charge.SetActive(false);
        stage7_moved_box.SetActive(false);
        stage7_want_move_spot.SetActive(false);
        stage11_exam.SetActive(false);
        Timer.time = GameManager.mission_clear_time;
        mission_complicated = false;
        switch (mission_count)
        {
            case 0:
                stage1_text.text = "샷건은 절대 금지!\n중간에 연타는 키보드 안 망기지게 해주세요!\n클리어시 뽑기권을 받아가세요!";
                mission_complicated = true;
                break;
            case 1:
                stage1_text.text = " ";
                break;
            case 2:
                float maxDistance = float.NegativeInfinity;
                Transform furthestObject = null;

                foreach (Transform objTransform in stage3_spots)
                {
                    // Player와 오브젝트 간의 거리를 계산
                    float distance = Vector2.Distance(player.transform.position, objTransform.position);

                    // 현재 오브젝트가 가장 먼 오브젝트라면 갱신
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        furthestObject = objTransform;
                    }
                }

                Instantiate(stage3_obj, furthestObject.position, Quaternion.identity);
                break;
            case 3:
                GameObject stage2Spot = GameObject.FindGameObjectWithTag("Stage2_spot");
                Destroy(stage2Spot);
                break;
            case 4:
                cam_obj.GetComponent<Camera>().orthographicSize = 5;
                stage5_charge.SetActive(true);
                break;
            case 5:
                for (int i = 0; i < 8; i++)
                {
                    if (stage6_btns[i] != null)
                    {
                        stage6_btns[i].SetActive(true);
                    }
                }
                cam_obj.GetComponent<Camera>().orthographicSize = 5;
                stage5_charge.SetActive(false); 
                GameManager.instance.ShuffleArray(stage6_btn);
                stage6_btns[0].GetComponent<Stage5_rhythm>().temp = stage6_btn[0];
                Debug.Log(stage6_btns[0]);
                stage6_btns[1].GetComponent<Stage5_rhythm>().temp = stage6_btn[1];
                stage6_btns[2].GetComponent<Stage5_rhythm>().temp = stage6_btn[2];
                stage6_btns[3].GetComponent<Stage5_rhythm>().temp = stage6_btn[3];
                break;
            case 6:
                for(int i = 0; i<8; i++)
                {
                    if (stage6_btns[i] != null)
                    {
                        stage6_btns[i].SetActive(false);
                    }
                }
                stage7_moved_box.SetActive(true);
                stage7_want_move_spot.SetActive(true);
                player.transform.position = stage7_spot.position;
                break;
            case 7:
                stage7_moved_box.SetActive(false);
                stage7_want_move_spot.SetActive(false);

                for (int i = 0; i < 10; i++)
                {
                    if (stage8_texting_box[i] != null)
                    {
                        stage8_texting_box[i].SetActive(true);
                    }
                }
                break;

            case 8: //Stage8
                for (int i = 0; i < 10; i++)
                {
                    if (stage8_texting_box[i] != null)
                    {
                        stage8_texting_box[i].SetActive(false);
                    }
                }

                stage9_enemy.SetActive(true);
                mission_complicated = true;
                break;
            case 9:
                stage9_enemy.SetActive(false);

                stage10_jump_map.SetActive(true);
                player.transform.position = stage10_spot.position;
                player_rigid = player.GetComponent<Rigidbody2D>();
                player_rigid.gravityScale = 1;
                break;
            case 10:
                stage10_jump_map.SetActive(false);
                player_rigid = player.GetComponent<Rigidbody2D>();
                player_rigid.gravityScale = 0;
                stage11_exam.SetActive(true);
                break;
            case 11:
                stage11_exam.SetActive(false);
                GameManager.isGameEnd = true;
                SceneManager.LoadScene("EndScene");
                break;
        }
    }
    public void Mission_Play()
    {
        //Debug.Log("현재 스테이지 : "+mission_count);
        switch (mission_count)
        {
            case 1: 
                // 마우스를 클릭하세요
                if(Input.GetMouseButton(0) || Input.GetMouseButton(1) && (!GameManager.isEscPanel))
                {
                    mission_complicated = true;
                    Misson_End();
                } break;
            case 2: 
                // 목적지에 도달하세요
                //player코드에 작성
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    mission_complicated = true;
                    Misson_End();
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.Space) && (!GameManager.isEscPanel))
                {
                    stage3_space_count++;
                    ZoomCamera(stage3_space_count);
                    if(stage5_need_count <= stage3_space_count)
                    {
                        mission_complicated = true;
                    }
                }
                if(stage3_space_count >= stage5_need_count / 8 && stage3_space_count < stage5_need_count - 2)
                {
                    if (!(stage3_space_count / (stage5_need_count / 8) >= 8))
                    {
                        stage5_charge.GetComponent<SpriteRenderer>().sprite = stage5_spr_charge[stage3_space_count / (stage5_need_count / 8)];
                    }
                }
                if(stage3_space_count >= stage5_need_count)
                {
                    stage5_charge.GetComponent<SpriteRenderer>().sprite = stage5_spr_charge[8];
                    mission_complicated = true;
                    Misson_End();
                }
                break;

            case 5:
                if (rythm_count >= 4)
                {
                    mission_complicated = true;
                    Misson_End();
                }
                break;
        };
    }

    private void ZoomCamera(float zoomAmount)
    {
        if (zoomAmount <= 12)
        {
            cam_obj.GetComponent<Camera>().orthographicSize = 5 - zoomAmount * 0.3f;
        }
        // 카메라의 시야 값을 조정하여 확대/축소 효과를 만듭니다.
    }
}
