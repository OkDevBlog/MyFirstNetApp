# Copilot instructions for MyFirstNetApp

## Repository overview

This repository's main application is a cross-platform budgeting app built with .NET 10 and Avalonia UI. Its solution is `MyFirstApp/MyCrossApp/MyCrossApp.slnx`; shared application logic lives under `MyFirstApp/MyCrossApp/MyCrossApp/`, while platform entry points live in the sibling `MyCrossApp.Desktop`, `MyCrossApp.Browser`, `MyCrossApp.Android`, and `MyCrossApp.iOS` projects. `MyFirstApp/MyFirstApp.csproj` and `MyFirstApp/MyDesktopApp/` are separate starter projects, not part of this solution.

The important architecture split is:

- `MyCrossApp/Models/` defines the domain model (`Category`, `Transaction`).
- `MyCrossApp/Data/AppDbContext.cs` owns the EF Core SQLite setup, path selection, and seed data.
- `MyCrossApp/Services/` contains the data-access layer (`IBudgetService`, `BudgetService`).
- `MyCrossApp/ViewModels/MainViewModel.cs` owns screen state, filters, totals, and command handlers.
- `MyCrossApp/Views/` contains the Avalonia UI (`MainView.axaml`, `MainView.axaml.cs`).
- `MyCrossApp/Helpers/AppIcons.cs` holds the custom SVG path data used instead of emoji.

Each platform project references the shared library. Its entry point starts Avalonia; `MyCrossApp/App.axaml.cs` selects a desktop or single-view lifetime and creates the main view model. `MainViewModel` accepts `IBudgetService` in its constructor; its parameterless constructor supplies `BudgetService`, so tests or other callers can provide a service implementation without moving data access into the view model.

`BudgetService` creates and disposes an `AppDbContext` per operation. The context configures SQLite and seeds default categories; startup uses `EnsureCreatedAsync`, not EF Core migrations. Filtering and summary queries are performed by the service and surfaced through `MainViewModel`.

## Build, run, and validation

### Required tooling

- Install the .NET 10 SDK.
- For the browser/WASM target, install the browser workload:

```bash
dotnet workload install wasm-tools
```

### Restore and build

```bash
dotnet restore MyFirstApp/MyCrossApp/MyCrossApp.slnx
```

Build the shared library or an individual target:

```bash
dotnet build MyFirstApp/MyCrossApp/MyCrossApp/MyCrossApp.csproj
dotnet build MyFirstApp/MyCrossApp/MyCrossApp.Desktop/MyCrossApp.Desktop.csproj
dotnet build MyFirstApp/MyCrossApp/MyCrossApp.Browser/MyCrossApp.Browser.csproj
```

Run the desktop app:

```bash
dotnet run --project MyFirstApp/MyCrossApp/MyCrossApp.Desktop
```

Run the browser app:

```bash
dotnet run --project MyFirstApp/MyCrossApp/MyCrossApp.Browser
```

To build all targets in the solution:

```bash
dotnet build MyFirstApp/MyCrossApp/MyCrossApp.slnx
```

The solution includes Android and iOS projects, which require their platform workloads. In particular, iOS workloads are unavailable in many Linux/Codespaces environments. Build the specific target being changed rather than assuming a full solution build is supported.

### Test commands

There are currently no automated test projects or repository-specific lint commands/configuration. Validate code changes by building the affected project. If a test project is added, run one test with:

```bash
dotnet test <path-to-test-project.csproj> --filter "FullyQualifiedName~Namespace.Class.TestName"
```

## Key conventions in this repo

### Centralized package management

Package versions for the `MyCrossApp` solution are managed centrally in `MyFirstApp/MyCrossApp/Directory.Packages.props`; update it when changing a dependency used by those projects. The separate `MyDesktopApp` starter project declares package versions in its own project file.

### MVVM and command patterns

The app uses `CommunityToolkit.Mvvm` with `[ObservableProperty]` and `[RelayCommand]` patterns. Keep screen state and command behavior in the view model and data operations in `IBudgetService`/`BudgetService`. `MainView.axaml` declares its compiled binding type with `x:DataType`; preserve typed bindings when editing the view.

`ViewModelBase` is the shared base for view-model behavior. Commands use `[RelayCommand]`; database-backed commands are asynchronous.

### Database and platform-specific path logic

`AppDbContext` checks `OperatingSystem.IsBrowser()` before choosing a SQLite database path. Browser builds use `smartbudget.db`; desktop/native builds use the user-specific `LocalApplicationData/SmartBudget` folder. Preserve this distinction when changing storage or database initialization.

### Arabic RTL + custom icon strategy

This app is designed for Arabic-first usage with right-to-left layout. The project uses `FlowDirection="RightToLeft"` and embedded Arabic fonts in `Assets/Fonts`. Do not replace the app’s layout assumptions with a left-to-right default without checking the UI behavior.

The project uses vector paths via `AppIcons.cs` and Avalonia `PathIcon` rather than relying on emoji glyph availability. If adding a category icon, extend the existing icon mapping and preserve the category icon-key convention.

### Shared app state and screen behavior

`MainViewModel` is the central orchestrator for:

- loading categories and transactions
- filtering/searching the transaction list
- refreshing monthly income/expense and balance totals
- editing and deleting workflows
- form state transitions (`IsEditing`, `SelectedCategory`, etc.)

When adding new UI behavior, prefer extending the current view-model pattern rather than moving logic into the view layer.

`MainView.axaml.cs` adapts the layout to available width: the form and transaction list stack below 820 px, and statistics/search controls reflow below 600 px. Keep these breakpoints and the corresponding XAML grid element names in sync when changing responsive layout.
