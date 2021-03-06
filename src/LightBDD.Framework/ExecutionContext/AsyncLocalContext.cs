﻿#if NET45
using System;
using System.Runtime.Remoting.Messaging;
#else
using System.Threading;

#endif

namespace LightBDD.Framework.ExecutionContext
{
    /// <summary>
    /// Class offering async local storage
    /// </summary>
    /// <typeparam name="T">Stored value</typeparam>
    public class AsyncLocalContext<T>
    {
#if NET45
        class Wrapper : MarshalByRefObject
        {
            public Wrapper(T value)
            {
                Value = value;
            }
            public T Value { get; }
        }
        private readonly string _id = Guid.NewGuid().ToString();
#else
        private readonly AsyncLocal<T> _context = new AsyncLocal<T>();
#endif
        /// <summary>
        /// Allows to get and set value to store.
        /// </summary>
        public T Value
        {
            get
            {
#if NET45
                var wrapper = (Wrapper)CallContext.LogicalGetData(_id);
                return wrapper != null ? wrapper.Value : default(T);
#else
                return _context.Value;
#endif
            }
            set
            {
#if NET45
                if (Equals(value, default(T)))
                    CallContext.FreeNamedDataSlot(_id);
                else
                    CallContext.LogicalSetData(_id, new Wrapper(value));
#else
                _context.Value = value;
#endif
            }
        }
    }
}
