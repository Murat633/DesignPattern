using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            DeletedState deletedState = new DeletedState();
            modifiedState.DoAction(context);
            deletedState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();

        }
    }

    interface IState
    {
        void DoAction(Context context);

    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            context.SetState(this);
            Console.WriteLine("State : Modified");
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            context.SetState(this);
            Console.WriteLine("State : Modified");
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }

   
}
