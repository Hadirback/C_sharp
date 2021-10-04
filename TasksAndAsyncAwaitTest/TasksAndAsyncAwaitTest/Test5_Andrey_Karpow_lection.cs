using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Test5_Andrey_Karpow_lection
    {
    }

    public readonly struct Option<T>
    {
        public T Value { get; }
        public bool HasValue { get; }

        public Option(T value) => (Value, HasValue) = (value, true);
        public static readonly Option<T> None = default;
    }

    // Завернем Control-flow в Data-flow
    // Не использовать в продакшн коде
    public readonly struct Try<T>
    {
        public T Value { get; }
        public Exception Error { get; }

        public Try(T value) => (Value, Error) = (value, null);

        public Try(Exception error) => (Value, Error) = (default, error);
    }

    interface IPullable<T>
    {
        IPuller<T> GetPuller();

    }

    interface IPuller<T>
    {
        Try<Option<T>> Pull();
    }

    // Применим двойственность. Теория категорий
    // Меняем местами входы с выходами

    interface IPushable<T>
    {
        void SetPusher(IPusher<T> pusher);
    }

    interface IPusher<T>
    {
        void Push(Try<Option<T>> value);
    }

    // IObservable это двойственный интерфейс IEnumerable - пул пуш взаимодействие

    // еще один эффект - задержка. Latence. Как задержка влияет на эти интерфейсы
    /*
        1) проблема медленного производителя
        public void Provess<T>(IEnumerator<T> slowProducer)
        {
            while(slowProducer.MoveNext()) - блокирующий вызов!
            {
                Consume(slowProduce.Current)
            }
        }

        2) медленный потребитель
        public void NotifyNext<T>(IObserver<T> slowConsumer, T item)
        {
            slowConsumer.OnNext(item); - блокирующий вызов
        }
     
     */

    // Как мыв работаем с эффектом зарежки?
    // Использование Task

    /*
     Были добавлены новые интерфейсы
    interface IAsyncEnumerable<out T>
    {
        IAsyncEnumerator<T> GetAsyncEnumerator();
    }
     
    interface IAsyncEnumerator<out T>
    {
        Task<bool> MoveNextAsync();
        T Current { get; }
    }

    и асинхронный push
    interface IObservable<out T>
    {
	    Task<IAsyncDisposable> SubscribeAsync(IAsyncObserver<T> observer); 
    }

    interface IAsyncObserver<in T>
    {
	    void OnNextAsync(T value);
	    void OnCompletedAsync();
	    void OnErrorAsync(Exception error);
    }
     */
}
