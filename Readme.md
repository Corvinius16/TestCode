Эта часть кода, разработанная мной для созданий пользовательский сценариев в нодовом редакторе. Scenario Player запускает сценарий. Примеры нод сценария описаны в папке Nodes. Когда выполнение сценария доходит до ноды, то вызывается Action ноды. Примеры Action приведены в папке Actions. Поиск объектов сцены осуществляется через MainManager, который хранит ссылки на ReferenceObject.  ReferenceObject эта реальзация хранения ссылок на объектов из сцены внутри файлов, благодаря сериализации Guid. Таким образом работая в редакторе юнити и моем нодовом редакторе можно настраивать зависимости и хранить их в самом проекте.