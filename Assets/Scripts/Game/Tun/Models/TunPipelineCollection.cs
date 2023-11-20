using System.Collections;
using System.Collections.Generic;
using Game.Tun.Segment;

namespace Game.Tun.Models {
    public class TunPipelineCollection : IEnumerable<TunSegment> {
        private readonly List<TunSegment> _tunSegments;
        
        public TunPipelineCollection() => _tunSegments = new List<TunSegment>();

        public int TunsCount => _tunSegments.Count;

        public void AddTun(TunSegment segment) {
            _tunSegments.Add(segment);
        }

        public void RemoveTun(TunSegment tunSegment) {
            _tunSegments.Remove(tunSegment);
        }

        public TunSegment Get(int i) {
            return _tunSegments[i];
        }

        public IEnumerator<TunSegment> GetEnumerator() {
            return _tunSegments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_tunSegments).GetEnumerator();
        }
    }
}