using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{

    public interface GameSubject
    {
        void Attach(GameObserver observer);

        void Detach(GameObserver observer);

        void Notify();

    }

    public interface GameObserver
    {
        void Update(Game subject);
    }


    public interface ControllerSubject
    {
        void Attach(ControllerObserver observer);

        void Detach(ControllerObserver observer);

        void Notify();

    }

    public interface ControllerObserver
    {
        void Update(string input);
    }

}
