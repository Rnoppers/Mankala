using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{

    public interface Subject
    {
        void Attach(Observer observer);

        void Detach(Observer observer);

        void Notify();

    }


    public interface Observer
    {
        void Update(Subject subject);
    }

}
