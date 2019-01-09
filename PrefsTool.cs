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

    /// <summary>
    /// 綁定PlayerPrefs
    /// </summary>
    /// <param name="prefsKey">PlayerPrefs的Key</param>
    /// <param name="onInit">如果該Key尚未被指定過，並賦予該Key起始值；如果該Key已經有值則不會做任何事</param>
    /// <returns></returns>
    public static PrefsTool Bind(string prefsKey, Func<string> onInit)
    {
        return new PrefsTool(prefsKey, onInit);
    }

    /// <summary>
    /// 更新數值的事件
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public PrefsTool AddEvent(Action<Action<string>> callback)
    {
        callback(value => PlayerPrefs.SetString(prefsKey, value));
        return this;
    }

    /// <summary>
    /// 更新數值的事件，例如 .AddEvnet(InputField.OnEndEdit.AddListener);
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public PrefsTool AddEvent(Action<UnityAction<string>> callback)
    {
        callback(value => PlayerPrefs.SetString(prefsKey, value));
        return this;
    }

    /// <summary>
    /// 在讀取到這個值之後觸發的事件
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public PrefsTool OnLoaded(Action<string> callback)
    {
        var value = PlayerPrefs.GetString(prefsKey);
        callback?.Invoke(value);
        return this;
    }
}