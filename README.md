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
## I. Dependencies: Install Nuget
### 1. HandyControl
#####   https://handyorg.github.io/handycontrol/native_controls/
#####   https://github.com/HandyOrg/HandyControl


## II. Figma
#####   https://www.figma.com/design/LdiBMGbzy0crsmWN0ebeqv/UTExLMS?node-id=0-1&t=r2Vy5b9lVrbc8Dth-1

## III. Nguồn học WPF MVVM
#####   https://youtu.be/fZxZswmC_BY?si=uD-yWHl6U_su3xEE

## IV. NOTE!!!!!!
```
    You will need to install the following packages from NuGet:

    Microsoft.EntityFrameworkCore.Design
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools 

    After that run the following command in the Package Manager Console: (Tools>Nuget Package Manager>Package Manager Console)
    Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=UTExLMS;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

    In case you need to update the DB, you can update your models by adding -Force  at the end.
    Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=UTExLMS;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
```
