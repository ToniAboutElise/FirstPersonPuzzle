using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager instance;
    private Volume _volume;

    private DepthOfField _depthOfField;
    private ColorAdjustments _colorAdjustments;
    public enum FadeType
    {
        FADE_IN,
        FADE_OUT,
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (_volume == null)
            _volume = GetComponent<Volume>();
    }

    public void SetPostDepthOfField(bool active)
    {
        if (_volume.profile.TryGet<DepthOfField>(out _depthOfField))
        {
            _depthOfField.active = active;
        }
    }

    public void Fade(FadeType fadeType, float time = 8)
    {
        int fadeValue = 0;

        if (_volume.profile.TryGet<ColorAdjustments>(out _colorAdjustments))
        {
            switch (fadeType)
            {
                case FadeType.FADE_IN:
                    fadeValue = 0;
                    _colorAdjustments.postExposure.value = -30;
                    break;
                case FadeType.FADE_OUT:
                    fadeValue = -30;
                    _colorAdjustments.postExposure.value = 0;
                    break;
            }
            _colorAdjustments.active = true;
            LeanTween.value(_colorAdjustments.postExposure.value, fadeValue, time).setOnUpdate((float value) =>
            {
                _colorAdjustments.postExposure.value = value;
            });
        }
    }
}
