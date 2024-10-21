# UTExLMS
```
UTExLMS
│
├── Models (Chứa các class, database)
│
├── Views (Chứa các giao diện)
│   └── UserControlView (folder)
│       └── CourseUC.xaml
│   └── StudentView.xaml
│       
├── ViewModels 
│   ├── MainViewModel.cs
│   ├── NavigationViewModel.cs (điều hướng các view)
│   └── BaseViewModel.cs (chức năng chung)
│
├── Commands
│   ├── RelayCommand.cs (Icommand)
│   └── BaseCommand.cs (ICommand, abstract)
│   └── NavigationCommand.cs (điều hướng giao diện bằng Icommand)
│
└── Assets (nguồn font, nuget...)
```
## Dependencies: Install Nuget
### 1. HandyControl
#####   https://handyorg.github.io/handycontrol/native_controls/
#####   https://github.com/HandyOrg/HandyControl
### 2. CommunityToolkit.Mvvm
#####   https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/

## Nguồn học WPF MVVM
#####   https://youtu.be/fZxZswmC_BY?si=uD-yWHl6U_su3xEE
