# WpfValidation# WpfValidation

## Validation Types in WPF

WPF (Windows Presentation Foundation) provides several mechanisms for validating user input in data-bound applications. Here are the main validation types:

### 1. Data Annotations
- **Description:** Use attributes in your data model (e.g., `[Required]`, `[StringLength]`, `[Range]`) to specify validation rules.
- **Usage:** Works well with `IDataErrorInfo` or `INotifyDataErrorInfo` for automatic validation in the UI.

### 2. Exception Validation
- **Description:** If a binding throws an exception during an update (e.g., type conversion errors), WPF can catch and display the error.
- **Usage:** Set `ValidatesOnExceptions=True` in your binding.

### 3. IDataErrorInfo
- **Description:** Implement the `IDataErrorInfo` interface in your data model to provide custom error messages for properties.
- **Usage:** WPF bindings can automatically display these errors in the UI.

### 4. INotifyDataErrorInfo
- **Description:** A more modern interface than `IDataErrorInfo`, supporting asynchronous and multiple errors per property.
- **Usage:** Implement `INotifyDataErrorInfo` for richer validation scenarios.

### 5. Validation Rules
- **Description:** Create custom validation logic by subclassing `ValidationRule` and attaching it to a binding.
- **Usage:** Add your rule to the `Binding.ValidationRules` collection.

---

## Summary Table

| Validation Type         | Synchronous | Asynchronous | Multiple Errors | UI Integration |
|------------------------|:-----------:|:------------:|:---------------:|:--------------:|
| Data Annotations       |     ✔️      |      ❌      |       ❌        |      ✔️        |
| Exception Validation   |     ✔️      |      ❌      |       ❌        |      ✔️        |
| IDataErrorInfo         |     ✔️      |      ❌      |       ❌        |      ✔️        |
| INotifyDataErrorInfo   |     ✔️      |      ✔️      |       ✔️        |      ✔️        |
| Validation Rules       |     ✔️      |      ❌      |       ❌        |      ✔️        |

---


