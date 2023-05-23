using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Transform player;
    public Vector3 playerPosStart;

    private Command btnW, btnS, btnA, btnD, btnB, btnZ, btnR, btnC;
    public static List<Command> commands = new List<Command>();

    public Coroutine replayCor;
    public static bool startReplay;
    public bool replaying;

    void Start()
    {
        btnW = new MoveForward(player);
        btnS = new MoveReverse(player);
        btnA = new MoveLeft(player);
        btnD = new MoveRight(player);
        btnZ = new UndoCommand();
        btnR = new ReplayCommand();
        btnC = new ClearCommand();

        UpdatePlayerPosStart();
    }

    void Update()
    {
        if (!replaying) HandleInput();
        if (startReplay) StartReplay();
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            btnA.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            btnD.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            btnR.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            btnS.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            btnW.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            btnZ.ExeCmd();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            btnC.ExeCmd();
            UpdatePlayerPosStart();
        }
        else
        {
        }
    }

    void StartReplay()
    {
        if (commands.Count > 0)
        {
            startReplay = false;

            if (replayCor != null)
            {
                StopCoroutine(replayCor);
            }

            replayCor = StartCoroutine(ReplayCommands(player));
        }
    }

    IEnumerator ReplayCommands(Transform obj)
    {
        replaying = true;

        obj.position = playerPosStart;
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < commands.Count; i++)
        {
            commands[i].MoveCmd();

            yield return new WaitForSeconds(0.3f);
        }

        replaying = false;
    }

    public void UpdatePlayerPosStart()
    {
        playerPosStart = player.position;
    }
}
