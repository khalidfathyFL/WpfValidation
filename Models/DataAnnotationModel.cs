using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfValidation.Models;
internal class DataAnnotationModel :ObservableValidator
{

    private string? _dataAnnotationText;

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(12, ErrorMessage = "Maximum Length is 12 characters.")]
    public string? DataAnnotationText
    {
        get => _dataAnnotationText;
        set => SetProperty(ref _dataAnnotationText, value, true);
    }

}
