using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Workshop.Core.EF
{
    public class DiagnosticObserver : IObserver<DiagnosticListener>
    {
        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == DbLoggerCategory.Name) // "Microsoft.EntityFrameworkCore"
            {
                
            }
        }
    }
}