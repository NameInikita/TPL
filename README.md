### TPL_Action
Создан метод MyTask() для проверки синхронной и асинхронной работы в классе Task  
Создан экземпляр задачи через делегат Action и просто на классе Task  
Проведена проверка работы методов Start(), RunSynchronously(), Wait()  
Также извлечен ID потока через: Thread.CurrentThread.ManagedThreadId и Task.CurrentId  

**Вывод через** *taskAction.Start()* **и без** *taskAction.Wait()* **:**
> Main запущен в потоке 10  
> MyTask запущен в потоке 6, CurrentId 1  
> 0 MyTask запущен в потоке 11, CurrentId 2  
> 0  
> 0  
> 0 1 1  
> 0  
> 0 1 1 2 2  
> MyTask завершился в потоке 11, CurrentId 2
> MyTask завершился в потоке 6, CurrentId 1

**Вывод через** *taskAction.RunSynchronously()* **и с** *taskAction.Wait()* **:**
> Main запущен в потоке 10  
> MyTask запущен в потоке 10, CurrentId 1  
> 0  
> 0 1  
> 0 1 2  
> MyTask завершился в потоке 10, CurrentId 1  
> MyTask запущен в потоке 10, CurrentId 2  
> 0  
> 0 1  
> 0 1 2  
> MyTask завершился в потоке 10, CurrentId 2
