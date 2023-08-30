## Initialization

Simple Localizer is as it says. It's a simple language localization system, that handles all the logic you need for switching languages and getting the correct definitions for you, so that you can focus on the localizing. The setup is simple, and just requires 3 things. First setting which languages you want to localize. Inside of `Localized.cs` exists an enum, with some base languages. Adding your own enums will tell the system which languages you'd like to localize.

```csharp
public enum Languages
{
    [DisplayName("Keys")] Keys_Doc,
    [DisplayName("English NA")] English_NA,
    [DisplayName("Spanish")] Spanish,
}
```

Step two is the language validation. This step ensures that you have all of the correct language files, and keys generated.
```csharp
Localized.Instance.ValidateAndCreateLanguages();
```

Lastly is setting the language you'd like to use, which can be done by calling the following:
```csharp
Localized.Languages language;
...
Localized.Instance.SetLanguage(language);
```
Setting the language at any time will load that language. From there you will need to re-request any definitions that have been requested before.

## Creating new keys

The process of creating new keys for text you'd like to look up is fairly easy, it can be done by simple creating an enum with the Key you'd like to make inside of the Partial class Localized, inside the correct name space `namespace Utilities.Localization`
```csharp
    public partial class Localized
    {
        public enum Animals
        {
            Dog,
        }

        public enum Questions
        {
            WhereIsMy_X
        }
    }
```

## Creating new Definitions

Inside the folder `Assets/Resources/Localization/Languages` you'll find all of the languages your system supports. To set a definition open up one of the files, and input the definition next to the key. 
```json
{
  "Dog": "Dog",
  "English_NA": "English",
  "Keys_Doc": "",
  "Spanish": "Spanish",
  "WhereIsMy_X": "Where is my {0}?"
}
```
in the above example, we set Dog to Dog, and WhereIsMy_X to Where is my {0}. This means that WhereIsMy_X can take an argument when you search up its definitions.

## Getting the localized Text.

To Get the localized text simple call the function GetDefinition
```csharp
        languageText.text = Localized.Instance.GetDefinition(language);
        text.text = Localized.Instance.GetDefinition(Questions.WhereIsMy_X, Animals.Dog);
```

The above example will produce the following result.

![Capture1](https://github.com/Nova-Ardent/SimpleLocalizer/assets/40727151/7304b481-dbb9-4601-ac76-d791a4a651f5)
![Capture](https://github.com/Nova-Ardent/SimpleLocalizer/assets/40727151/54db5ae9-4054-4ea5-a92b-5daf650229cf)
