using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LayerSuperType.Model
{
    public abstract class EntityBase<T>
    {        
        private T _Id;
        private bool _idHasBeenSet = false;
        private IList<string> _brokenRules = new List<string>();

        public EntityBase()
        { }

        public EntityBase(T Id)
        {
            this.Id = Id;
        }

        public T Id
        {
            get { return _Id; }
            set
            {
                if (_idHasBeenSet)
                    ThrowExceptionIfOverwritingAnId();

                _Id = value;
                _idHasBeenSet = true;
            }
        }

        private void ThrowExceptionIfOverwritingAnId()
        {
            throw new ApplicationException("You cannot change the id of an entity.");
        }

        public bool IsValid()
        {
            ClearCollectionOfBrokenRules();
            CheckForBrokenRules();
            return _brokenRules.Count() == 0;
        }

        protected abstract void CheckForBrokenRules();        

        private void ClearCollectionOfBrokenRules()
        {
            _brokenRules.Clear(); 
        }

        public IEnumerable<string> GetBrokenBusinessRules()
        {
            return _brokenRules;
        }

        protected void AddBrokenRule(string brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }
    }
}
