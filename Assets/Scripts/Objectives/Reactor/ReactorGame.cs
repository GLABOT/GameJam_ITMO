using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorGame : MonoBehaviour
{
    public static ReactorGame instance = null;

    private ShowOrHideUI UIManager;

    private RectTransform StartPos;
    private RectTransform EndPos;
    private RectTransform SolveZone;

    private GameObject Pointer;
    private GameObject SmokeParticle;

    private bool infoShown;
    public bool miniGameStarted;
    private bool solveZoneGenerated;
    private bool canMovePointer;
    private bool gameOver;


    [SerializeField]
    private float speed;
    private bool worldPositionStays;

    private void Start()
    {
        if (instance == null)
            instance = this;

        canMovePointer = true;
        StartPos = transform.GetChild(0).GetComponent<RectTransform>(); 
        EndPos = transform.GetChild(1).GetComponent<RectTransform>(); 
        Pointer = transform.GetChild(2).gameObject;
        SolveZone = transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();

        UIManager = GetComponent<ShowOrHideUI>();

    }

    private void ShowInfo()
    {
        if (infoShown)
            return;

        Information.instance.ChangeText("Нажмите R когда указатель будет в зеленой области!");
        Information.instance.GetComponent<ShowOrHideUI>().Show();
        infoShown = true;


    }

    private void Update()
    {
        if (miniGameStarted)
        {


            ShowInfo();
            StopPointer();

            if (canMovePointer)
                StartCoroutine(MovePointerCoroutine());

            if (!solveZoneGenerated)
            {
                FirstPersonController.instance.cameraCanMove = false;

                UIManager.Show();
                GenerateSolveZone();
            }
        }
    }

    

    private void GenerateSolveZone()
    {
        int randnum = Random.Range(-250, 250);
        SolveZone.localPosition = new Vector2(randnum, SolveZone.transform.localPosition.y);
        solveZoneGenerated = true;
    }

    private IEnumerator MovePointerCoroutine()
    {
        canMovePointer = false;
        Pointer.LeanMoveLocal(EndPos.localPosition, speed);
        yield return new WaitForSeconds(speed);
        Pointer.LeanMoveLocal(StartPos.localPosition, speed);
        yield return new WaitForSeconds(speed);
        canMovePointer = true;
    }

    private void StopPointer()
    {
        if (gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameOver = true;
            GameObject newPointer = Instantiate(Pointer, Pointer.transform.localPosition, Quaternion.identity);
            newPointer.transform.SetParent(gameObject.transform, worldPositionStays);
            newPointer.transform.localPosition = Pointer.transform.localPosition;

            if (Pointer != null)
            Destroy(Pointer);

            CheckPointerPosition(newPointer);
        }
    }

    private void CheckPointerPosition(GameObject newPointer)
    {


        float distance = Vector3.Distance(newPointer.transform.localPosition, SolveZone.transform.localPosition);
        Debug.Log("Distance = " + distance);

        string result;

        if (distance > 300)
        {
            result = "Неудачно";
            GameObject reactor = GameObject.Find("Reactor");
            SmokeParticle = Instantiate(ParticleSpawner.instance.Smoke, reactor.transform.position, ParticleSpawner.instance.Smoke.transform.rotation);
            SoundsManager.instance.PlaySound("ReactorBad", true);
        }
        else
        {
            result = "Удачно!";
            CurrentQuest.instance.HideQuest();
            TimeForQuests.instance.StopTimer();
            SoundsManager.instance.PlaySound("Signal", false);
            SoundsManager.instance.PlaySound("Good", true);
            TimeForQuests.instance.StopTimer();
        }


        Information.instance.GetComponent<ShowOrHideUI>().Hide();

        FirstPersonController.instance.cameraCanMove = true;
        UIManager.Hide();
        Information.instance.ChangeText(result);
        StartCoroutine(Information.instance.GetComponent<ShowOrHideUI>().ShowAsMessage());

    }

    public void FixSmoke()
    {
        Destroy(SmokeParticle);
        CurrentQuest.instance.HideQuest();
        TimeForQuests.instance.StopTimer();
        SoundsManager.instance.PlaySound("Signal", false);
        SoundsManager.instance.PlaySound("Good", true);
    }
    
}
