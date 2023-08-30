using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Localization;
using static Utilities.Localization.Localized;

namespace Utilities.Localization
{
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
}

public class ExampleRunner : MonoBehaviour
{
    [SerializeField] Localized.Languages language;
    
    [SerializeField] UnityEngine.UI.Text languageText;
    [SerializeField] UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        Localized.Instance.ValidateAndCreateLanguages();
        Localized.Instance.SetLanguage(language);

        languageText.text = Localized.Instance.GetDefinition(language);
        text.text = Localized.Instance.GetDefinition(Questions.WhereIsMy_X, Animals.Dog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
