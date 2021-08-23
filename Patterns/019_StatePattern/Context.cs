using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_StatePattern
{
    class Context
    {
        private State state = null;

        public Context(State state)
        {
            TransitionTo(state);
        }

        // контекс позволяет изменять объект состояния во время выполнения

        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            this.state = state;
            this.state.SetContext(this);
        }

        // Контекст делегирует часть своего поведения текущему объекту состояния.
        public void Request1()
        {
            state.Handle1();
        }

        public void Request2()
        {
            state.Handle2();
        }
    }
}
