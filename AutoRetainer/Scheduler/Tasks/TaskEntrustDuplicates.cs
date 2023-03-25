﻿using AutoRetainer.Scheduler.Handlers;

namespace AutoRetainer.Scheduler.Tasks;

internal static class TaskEntrustDuplicates
{
    internal static bool NoDuplicates = false;
    internal static void Enqueue()
    {
        P.TaskManager.Enqueue(() => { NoDuplicates = false; return true; }) ;
        P.TaskManager.Enqueue(YesAlready.WaitForYesAlreadyDisabledTask);
        if (P.config.RetainerMenuDelay > 0)
        {
            TaskWaitSelectString.Enqueue(P.config.RetainerMenuDelay);
        }
        P.TaskManager.Enqueue(RetainerHandlers.SelectEntrustItems);
        P.TaskManager.Enqueue(RetainerHandlers.ClickEntrustDuplicates);
        TaskWait.Enqueue(500);
        P.TaskManager.Enqueue(() => { if (NoDuplicates) return true; return RetainerHandlers.ClickEntrustDuplicatesConfirm(); }, 600 * 1000, false);
        TaskWait.Enqueue(500);
        P.TaskManager.Enqueue(() => { if (NoDuplicates) return true; return RetainerHandlers.ClickCloseEntrustWindow(); }, false);
        P.TaskManager.Enqueue(RetainerHandlers.CloseAgentRetainer);
    }
}
