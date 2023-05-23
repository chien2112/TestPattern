using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected float moveDistance = 1f;
    protected Transform obj;
    protected Command command;
    public abstract void ExeCmd();
    public virtual void UndoCmd() { }
    public virtual void MoveCmd() { }
}


#region CHILD_CLASS
public class MoveForward : Command
{
    public MoveForward(Transform _obj)
    {
        obj = _obj;
        command = this;
    }
    public override void ExeCmd()
    {
        MoveCmd();
        InputHandler.commands.Add(command);
    }

    public override void UndoCmd()
    {
        obj.Translate(-obj.up * moveDistance);
    }

    public override void MoveCmd()
    {
        obj.Translate(obj.up * moveDistance);
    }
}

public class MoveReverse : Command
{
    public MoveReverse(Transform _obj)
    {
        obj = _obj;
        command = this;
    }
    public override void ExeCmd()
    {
        MoveCmd();
        InputHandler.commands.Add(command);
    }

    public override void UndoCmd()
    {
        obj.Translate(obj.up * moveDistance);
    }

    public override void MoveCmd()
    {
        obj.Translate(-obj.up * moveDistance);
    }
}

public class MoveLeft : Command
{
    public MoveLeft(Transform _obj)
    {
        obj = _obj;
        command = this;
    }
    public override void ExeCmd()
    {
        MoveCmd();

        InputHandler.commands.Add(command);
    }

    public override void UndoCmd()
    {
        obj.Translate(obj.right * moveDistance);
    }

    public override void MoveCmd()
    {
        obj.Translate(-obj.right * moveDistance);
    }
}

public class MoveRight : Command
{
    public MoveRight(Transform _obj)
    {
        obj = _obj;
        command = this;
    }

    public override void ExeCmd()
    {
        MoveCmd();

        InputHandler.commands.Add(command);
    }

    public override void UndoCmd()
    {
        obj.Translate(-obj.right * moveDistance);
    }

    public override void MoveCmd()
    {
        obj.Translate(obj.right * moveDistance);
    }
}

public class UndoCommand : Command
{
    public override void ExeCmd()
    {
        List<Command> cmds = InputHandler.commands;

        if (cmds.Count > 0)
        {
            Command latestCommand = cmds[cmds.Count - 1];
            latestCommand.UndoCmd();
            cmds.RemoveAt(cmds.Count - 1);
        }
    }
}

public class ReplayCommand : Command
{
    public override void ExeCmd()
    {
        InputHandler.startReplay = true;
    }
}

public class ClearCommand : Command
{
    public override void ExeCmd()
    {
        InputHandler.commands.Clear();
    }
}

#endregion


