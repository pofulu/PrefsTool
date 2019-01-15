# PrefsTool
PrefsTool is PlayerPrefs' chain programming style implementation. Just like the usage of Linq.

## Example
The Following code will make an input field that will automatically save it's text and resume at Start.

```C#
[SerializeField] InputField inputField;

private void Start()
{
    PrefsTool.Bind("keyname", () => inputField.text)
        .OnLoaded(value => inputField.text = value)
        .AddEvent(inputField.onEndEdit.AddListener);
}
```
