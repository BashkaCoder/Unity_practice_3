# Practicing interfaces😎 in Unity
## Task#2:
Добавить разные объекты на сцену (можно просто кубы с разным цветом), накинуть на них разные скрипты с которыми можно повзаимодействовать. 
Типа `Chest`, `Switch`, `Ammo`. Создать скрипт на персонаже типа `InteractFeature`, который будет взаимодействовать с ближайшим объектом на кнопку E (определять рейкастом / оверлапом). 
Скрипт не должен напрямую взаимодейстовать с `Chest`, `Switch`, `Ammo`. Все эти скрипты реализовывают интерфейс `IInteractable`.
Каждый скрипт выполняет разные действия при взаимодействии с ним (хотя бы пишет разные сообщения в консоль).

## Выполнение:
- [IInteractable.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_2/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/IInteractable.cs)
- [InteractFeature.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_2/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/InteractFeature.cs)
- [AmmoBox.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_2/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/AmmoBox.cs)
- [Chest.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_2/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/Chest.cs)
- [ColoredCube.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_2/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/ColoredCube.cs)

## Итог:
Таска была выполнена. Был создан ряд скриптов:
- `IInteractable.cs` - интерфейс, который должны реализовывать все классы взаимодействуемых объектов
- `InteractFeature.cs` - скрипт предназначем для взаимодействия с объектами. Висит на игроке.
- `AmmoBox.cs` - При взаимодействии восполняет игроку патроны в автомате.
- `Chest.cs` - При взаимодействии проигрывается анимация открытия сундука.
- `ColoredCube.cs` - При взаимодействии меняет цвет материал куба.

## Выполнение
В скрипте `InteractFeature` реализована система взаимодействия персонажа с объектами через интерфейс `IInteractable`. 

В методе `Update()` выполняется рейкаст из камеры персонажа вперёд на расстояние **__interactionRange_**. 
Рейкаст используется для того, чтобы определить, есть ли перед персонажем объект, с которым можно взаимодействовать.
Если рейкаст пересекается с объектом и этот объект реализует интерфейс `IInteractable`, то:
- Отображается текст подсказки с помощью UI-элемента **__text_**, который указывает игроку, какое действие можно выполнить (метод `GetInteractionText()`).
- Если игрок нажимает кнопку "E", вызывается метод `Interact()` этого объекта, который выполняет уникальное действие, присущее этому объекту (открытие сундука, изменение цвета куба или сбор боеприпасов).

По итогу, `InteractFeature` взаимодействует с объектами только через интерфейс `IInteractable`, не заботясь о том, какой конкретно это объект.
