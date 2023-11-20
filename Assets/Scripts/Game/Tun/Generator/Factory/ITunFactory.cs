using Game.Tun.Models;
using Game.Tun.Segment;

namespace Game.Tun.Generator.Factory {
    public interface ITunFactory {
        TunSegment CreateTun(Ring top, Ring bottom);
    }
}