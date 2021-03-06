﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;

// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

[RequireComponent(typeof(Button))]
public class SongEditorOpenInSingSceneButton : MonoBehaviour, INeedInjection
{
    [Inject]
    private SongEditorSceneController songEditorSceneController;

    void Start()
    {
        GetComponent<Button>().OnClickAsObservable()
            .Subscribe(_ => songEditorSceneController.ContinueToSingScene());
    }
}
