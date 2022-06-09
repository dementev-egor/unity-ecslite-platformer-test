# unity-ecslite-platformer-test

##На разработку ушло ~6 часов

##Все системы и компоненты вынес отдельно, так что все их можно запустить вне Unity.

###Компоненты:
- ButtonComponent
- DoorComponent
- PlayerPositionComponent

###Системы:
- DoorsInitSystem
- PlayerInitSystem
- PlayerMovementSystem
- PLayerOnButtonSystem

###Для перемещения игрока нужно передавать в `SharedData.DestinationPlayerPosition` нужную позицию
###Основная точка входа `GameController.cs`

##Zenject не использовал, так как это первый опыт работы с ECS