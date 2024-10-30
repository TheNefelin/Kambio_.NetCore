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
<img src="\Requerimiento\Docs_Img\App.png" alt="App" height="40px"/>
<img src="\Requerimiento\Docs_Img\LoadingApp.jpg" alt="Loading app"/>
<img src="\Requerimiento\Docs_Img\Login.jpg" alt="Login"/>
