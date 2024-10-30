# Trueke App .NET Core 8

### Projects
* [Mobil App](https://github.com/TheNefelin/Kambio_.NetCore/tree/master/MauiKambio)
* [Web API](*)
* [Class Library](https://github.com/TheNefelin/Kambio_.NetCore/tree/master/ClassLibraryModels)
* [Requirement](https://github.com/TheNefelin/Kambio_.NetCore/tree/master/Requerimiento)

## App
```mermaid
graph TD;
    Mobile_APP --> Login_Page 
    Login_Page --> AppMenu_Page
  
    AppMenu_Page --> Logout
    Logout --> Login_Page

    AppMenu_Page --> Explorer_Page
    AppMenu_Page --> Barter_Page
    AppMenu_Page --> Favorite_Page
    AppMenu_Page --> Notification_Page
    AppMenu_Page --> Profile_Page;
```

## View
<img src="\Requerimiento\Docs\App.png" alt="App" width="100px"/>

<div>
    <img src="\Requerimiento\Docs\LoadingApp.jpg" alt="Loading app" width="250px"/>
    <img src="\Requerimiento\Docs\Login.jpg" alt="Login" width="250px"/>    
</div>

