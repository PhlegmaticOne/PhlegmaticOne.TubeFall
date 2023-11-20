using Game.Tun.Models;
using UnityEngine;

namespace Game.Tun.Segment {
    public class TunSegmentData {
        public Ring Top { get; private set; }
        public Ring Bottom { get; private set; }
        public int SidesCount { get; }
        public Material Material { get; }

        public TunSegmentData(Ring top, Ring bottom, int sidesCount, Material material) {
            Top = top;
            Bottom = bottom;
            SidesCount = sidesCount;
            Material = material;
        }

        public void EnsureRingsInRightPlacement() {
            if(Top.CenterY < Bottom.CenterY) {
                (Top, Bottom) = (Bottom, Top);
            }
        }
    }
}