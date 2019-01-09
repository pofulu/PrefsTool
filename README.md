# PlayerPrefsChain
PlayerPrefs' chain programming style implementation

## Example
```C#
[SerializeField] InputField inputField;

private void Start()
{
    PrefsTool.Bind("keyname", () => inputField.text)
        .OnLoaded(value => inputField.text = value)
        .AddEvent(inputField.onEndEdit.AddListener);
}
```

## Limitation
It is now only available for string types.
