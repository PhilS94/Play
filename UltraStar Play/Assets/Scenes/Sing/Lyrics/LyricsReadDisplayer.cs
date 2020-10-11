using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;

// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class LyricsReadDisplayer : MonoBehaviour, INeedInjection
{
    public Text currentSentenceText;
    public Text readSentenceText;

    public RectTransform lyricsIndicatorTransform;
    public RectMask2D mask;

    private float canvasWidth = 800;

    // Using LateUpdate to make sure the lyrics indicator already completed its calculations
    private void LateUpdate()
    {
        float lyricsRelativPosition = lyricsIndicatorTransform.position.x / Screen.width; // Between 0 and 1 (Left=0, Right=1)
        float maskPadding = canvasWidth * (1 - lyricsRelativPosition); // Calculate padding in pixels for mask
        mask.padding = new Vector4(0, 0, maskPadding, 0); // Apply to rightside padding

        readSentenceText.text = currentSentenceText.text;
    }
}
