using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.ComponentModel;
using WpfValidation.Models;

namespace WpfValidation.ViewModel;
internal sealed partial class MainViewModel : ObservableObject, IDataErrorInfo, INotifyDataErrorInfo
{




    /// <summary>
    /// Gets or sets the text to display when a validation exception occurs.
    /// </summary>
    [ObservableProperty] private string _validationOnExceptionText;

    /// <summary>
    /// Handles changes to the validation exception text.
    /// </summary>
    /// <param name="value">The new validation exception text. Must not be null, empty, or consist only of whitespace.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is null, empty, or consists only of whitespace.</exception>
    partial void OnValidationOnExceptionTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Text1 cannot be null or whitespace.");
        }

        SetProperty(ref _validationOnExceptionText, value);
    }

    /// <summary>
    /// Gets or sets the text of the validation rule.
    /// </summary>
    [ObservableProperty] private string _validationRuleText = string.Empty;


    [ObservableProperty] private string _iDataErrorInfoText1 = string.Empty;

    [ObservableProperty] private string _iDataErrorInfoText2 = string.Empty;
    [ObservableProperty] private DataAnnotationModel _input = new ();



    [ObservableProperty] private string _iNotifyDataErrorInfoText = string.Empty;
    partial void OnINotifyDataErrorInfoTextChanged(string value)
    {
        GetErrorsAsync().ContinueWith((errorsTask) =>
        {
            lock (_propertyErrors)
            {
                _propertyErrors[nameof(INotifyDataErrorInfoText)] = errorsTask.Result;
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(INotifyDataErrorInfoText)));
            }
        });
    }

    public string Error { get; }

    public string this[string propertyName] => GetErrorForProperty(propertyName);

    private string GetErrorForProperty(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(IDataErrorInfoText1):

                if (string.IsNullOrWhiteSpace(IDataErrorInfoText1))
                    return "error from I DataErrorInfo text 1";

                return string.Empty;

            case nameof(IDataErrorInfoText2):
                if (string.IsNullOrWhiteSpace(IDataErrorInfoText2))
                    return "error from I DataErrorInfo text 2";
                return string.Empty;

            default:
                return string.Empty;

        }
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        lock (_propertyErrors)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                return _propertyErrors[propertyName];
            }
        }
        return Array.Empty<string>();
    }

    public bool HasErrors => PropertyErrorsPresent();

    private bool PropertyErrorsPresent()
    {
        bool errors = false;
        foreach (var key in _propertyErrors.Keys)
        {
            if (_propertyErrors[key].Count > 0)
            {
                errors = true;
                break;
            }
        }
        return errors;
    }

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = delegate { };

    private Dictionary<string, List<string>> _propertyErrors = [];


    private Task<List<string>> GetErrorsAsync()
    {
        return Task.Run(() =>
        {
            Task.Delay(10000);

            if (string.IsNullOrWhiteSpace(INotifyDataErrorInfoText))
            {
                return new List<string> { "Value can not be empty" };
            }
            return new List<string>();

        });
    }

}

