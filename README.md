# Practicing interfaces😎 in Unity
## Task#1:
Отрефакторить в [Projectile.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/main/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/Projectile.cs) `OnCollisionEnter`. 
Вместо сравнения коллизии по тэгу проверять содержит ли коллизия интерфейс `IHaveProjectileReaction`
в случае если содержит вызывать метод интерфейса `.React()`

## Выполнение:
- [IHaveProjectileReaction.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_1/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/IHaveProjectileReaction.cs)
- [IHaveProjectileReactionSurface.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_1/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/IHaveProjectileReactionSurface.cs)
- [SurfaceProjectileImpact .cs](https://github.com/BashkaCoder/Unity_practice_3/blob/Task1_1/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/SurfaceProjectileImpact.cs)
- [Projectile.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/6100811c07a400f732deb549868d8ace35490c6f/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/Projectile.cs#L69-L80)
- [GasTankScript.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/6100811c07a400f732deb549868d8ace35490c6f/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/GasTankScript.cs#L153-L160)
- [ExplosiveBarrelScript.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/6100811c07a400f732deb549868d8ace35490c6f/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/ExplosiveBarrelScript.cs#L70-L78)
- [TargetScript.cs](https://github.com/BashkaCoder/Unity_practice_3/blob/6100811c07a400f732deb549868d8ace35490c6f/Assets/Infima%20Games/Low%20Poly%20Shooter%20Pack%20-%20Free%20Sample/Code/Legacy/TargetScript.cs#L45-L63)

## Итог:
Таска была выполнена. 

Логика взаимодествия пули раньше:
```
- OnCollsionEnter() пули => проверяем тег объекта, с которым взаимодействует пуля.
- В зависимости от тега объекта пуля изменяет состяние разных полей у этого объекта.
- Объект в Update() проверяет состояние полей. При выполнение условий - запускает частицы, звуки и тд.
```

Логика взаимодествия пули теперь:
```
- OnCollsionEnter() пули => проверяем объект на наличие интерфейса IHaveProjectileReaction.
- Вызываем React() если интерфейс присутсвует.
```

## Преимущество решения
- ### Снижение связности и соблюдение принципа единственной ответственности (SRP):
  - Логика взаимодействия пули с объектами больше не находится в коде пули. 
    Каждый объект сам отвечает за реакцию на столкновение через реализацию интерфейса IHaveProjectileReaction. 
    Это способствует соблюдению принципа единственной ответственности.

- ### Повышение гибкости и расширяемости:
  - Добавление новых объектов, реагирующих на пулю, не требует изменений в коде пули. 
    Достаточно, чтобы новый объект реализовал интерфейс IHaveProjectileReaction, что упрощает расширение системы.

- ### Уменьшение дублирования кода:
  - Устраняются избыточные проверки по тэгам, что сокращает дублирование кода и улучшает его поддержку.

- ### Повышение читаемости и поддержки кода:
  - Код пули становится более компактным и понятным, так как он просто вызывает метод React() у объекта, поддерживающего интерфейс IHaveProjectileReaction.

- ### Снижение риска ошибок при модификациях:
  - Изменения в поведении реакции на пулю можно делать непосредственно в соответствующих объектах без изменения кода пули.

- ### Оптимизация производительности:
    - Во-первых, объект реагирует на столкновение сразу же, минуя задержку до следующего вызова `Update()`. Это приводит к более быстрой и предсказуемой реакции на события.
    - Во-вторых, мы избавились от лишних вызово `Update()`. Unity Profiler гласит, что затрачиваемое время на `MonoBehaviour.Update()` уменьшилось вдвое(0.1ms => 0.05ms). 
      При масштабировании проекта преимущество данного решения будет более очевидным.