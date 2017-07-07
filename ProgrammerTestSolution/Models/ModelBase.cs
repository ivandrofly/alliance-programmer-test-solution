using System;
using System.Collections.Generic;

namespace ProgrammertSolution.Models
{
    public abstract class ModelBase<TValue>
    {
        protected static Dictionary<string, TValue> _dictionary = new Dictionary<string, TValue>();

        public static TValue Find(string id)
        {
            TValue model = default(TValue);
            if (string.IsNullOrWhiteSpace(id))
            {
                return model;
            }
            _dictionary.TryGetValue(id, out model);

            // return found model or default.
            return model;
        }

        // Returns true if this user has been deleted.
        protected bool _isDeleted = false;

        public string Id { get; protected set; }

        public ModelBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public abstract void Save();

        public abstract void Delete();
    }
}
