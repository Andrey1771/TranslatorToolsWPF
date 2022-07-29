using DocumentBuilderLibrary.PositionUtil;

namespace DocumentBuilderLibrary
{
    public interface IDocumentBuilder
    {
        void AddPartToPos(IPart part, Position pos);
        void AddPartRight(IPart part, YPosition y);
        void AddPartLeft(IPart part, YPosition y);
        void AddPartDown(IPart part, XPosition x);
        void AddPartUp(IPart part, XPosition x);
    }
}
