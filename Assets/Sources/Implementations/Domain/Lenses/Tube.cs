using System;
using System.Collections.Generic;

namespace Game.Implementations.Domain.Lenses
{
    public class Tube
    {
        private readonly List<Lens> _lenses = new List<Lens>();

        public IEnumerable<Lens> Lenses => _lenses;

        public void InsertLens(Lens lens)
        {
            if (lens == null)
                throw new ArgumentNullException(nameof(lens));

            if (_lenses.Contains(lens))
                throw new InvalidOperationException();

            Insert(lens);
        }

        public void RemoveLens(Lens lens)
        {
            if (lens == null)
                throw new ArgumentNullException(nameof(lens));

            if (_lenses.Contains(lens) == false)
                throw new InvalidOperationException();

            _lenses.Remove(lens);
        }

        private void Insert(Lens lens)
        {
            for (int i = 0; i < _lenses.Count; i++)
            {
                if ((_lenses[i].Position.z > lens.Position.z) == false)
                    continue;

                _lenses.Insert(i, lens);
                return;
            }

            _lenses.Add(lens);
        }
    }
}