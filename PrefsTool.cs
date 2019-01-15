using System;
using UnityEngine;
using UnityEngine.Events;

public class PrefsTool
{
    string prefsKey;

    private PrefsTool(string prefsKey, Func<string> onInit)
    {
        this.prefsKey = prefsKey;

        if (!PlayerPrefs.HasKey(prefsKey))
        {
            PlayerPrefs.SetString(prefsKey, onInit());
        }
    }
    private PrefsTool(string prefsKey, Func<float> onInit)
    {
        this.prefsKey = prefsKey;

        if (!PlayerPrefs.HasKey(prefsKey))
        {
            PlayerPrefs.SetFloat(prefsKey, onInit());
        }
    }
    private PrefsTool(string prefsKey, Func<int> onInit)
    {
        this.prefsKey = prefsKey;

        if (!PlayerPrefs.HasKey(prefsKey))
        {
            PlayerPrefs.SetInt(prefsKey, onInit());
        }
    }

    public static void Update(string prefsKey, string value)
    {
        PlayerPrefs.SetString(prefsKey, value);
    }
    public static void Update(string prefsKey, float value)
    {
        PlayerPrefs.SetFloat(prefsKey, value);
    }
    public static void Update(string prefsKey, int value)
    {
        PlayerPrefs.SetInt(prefsKey, value);
    }

    public static PrefsTool Bind(string prefsKey, Func<string> onInit)
    {
        return new PrefsTool(prefsKey, onInit);
    }
    public static PrefsTool Bind(float prefsKey, Func<float> onInit)
    {
        return new PrefsTool(prefsKey, onInit);
    }
    public static PrefsTool Bind(int prefsKey, Func<int> onInit)
    {
        return new PrefsTool(prefsKey, onInit);
    }

    public PrefsTool AddEvent(Action<Action<string>> callback)
    {
        callback(value => PlayerPrefs.SetString(prefsKey, value));
        return this;
    }
    public PrefsTool AddEvent(Action<Action<float>> callback)
    {
        callback(value => PlayerPrefs.SetFloat(prefsKey, value));
        return this;
    }
    public PrefsTool AddEvent(Action<Action<int>> callback)
    {
        callback(value => PlayerPrefs.SetInt(prefsKey, value));
        return this;
    }

    public PrefsTool AddEvent(Action<UnityAction<string>> callback)
    {
        callback(value => PlayerPrefs.SetString(prefsKey, value));
        return this;
    }

    public PrefsTool OnLoaded(Action<string> callback)
    {
        var value = PlayerPrefs.GetString(prefsKey);
        callback?.Invoke(value);
        return this;
    }
    public PrefsTool OnLoaded(Action<float> callback)
    {
        var value = PlayerPrefs.GetFloat(prefsKey);
        callback?.Invoke(value);
        return this;
    }
    public PrefsTool OnLoaded(Action<int> callback)
    {
        var value = PlayerPrefs.GetInt(prefsKey);
        callback?.Invoke(value);
        return this;
    }
}